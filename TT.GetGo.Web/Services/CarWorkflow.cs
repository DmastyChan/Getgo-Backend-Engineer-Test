using Microsoft.EntityFrameworkCore;
using TT.GetGo.Core.Domain;
using TT.GetGo.Services.Helper;
using TT.GetGo.Services.Logging;
using TT.GetGo.Services.Records;
using TT.GetGo.Web.Mapping;
using TT.GetGo.Web.Settings;
using LogLevel = TT.GetGo.Core.Domain.LogLevel;

namespace TT.GetGo.Web.Services
{
    public class CarWorkflow : ICarWorkflow
    {
        private readonly GetGoDBContext _objectContext;
        private readonly ILogServices _logServices;
        private readonly IWebHelper _webHelper;

        /// <summary>Initializes a new instance of the <see cref="T:System.Object" /> class.</summary>
        public CarWorkflow(
            GetGoDBContext objectContext, 
            ILogServices logServices, 
            IWebHelper webHelper)
        {
            _objectContext = objectContext;
            _logServices = logServices;
            _webHelper = webHelper;
        }

        /// <summary>
        /// Get all cards with the last location / home lot
        /// </summary>
        /// <returns>
        /// A task that represents the asynchronous operation
        /// The task result contains the car
        /// <param name="ids">Array of identifier</param>
        /// <param name="x">Filter Location X</param>
        /// <param name="y">Filter Location Y</param>
        /// <param name="filterCar">Filter Car Info</param>
        /// <param name="filterStatus">status accept</param>
        /// </returns>
        public virtual IList<CarInfo> GetAll(int[]? ids = null, string? filterCar = null, int? x = null, int? y = null, CarStatus[]? filterStatus = null)
        {
            var query = _objectContext.Cars.AsNoTracking().Where(z => z.Deleted == false);

            if (ids != null)
                query = query.Where(z => ids.Contains(z.Id));

            if (filterStatus != null)
                query = query.Where(z => filterStatus.Contains(z.Status));

            if (!query.Any())
                return new List<CarInfo>();

            var groupQuery = query
                .Select(z => new
                {
                    car = z,
                    LastLocation = z.LocationHistory.Where(w => w.Deleted == false).OrderByDescending(w => w.CreatedUTCDate).First(),
                });

            if (!string.IsNullOrWhiteSpace(filterCar))
                groupQuery = groupQuery.Where(z =>
                    z.car.Brand.Contains(filterCar) || z.car.Model.Contains(filterCar) ||
                    z.car.CarName.Contains(filterCar) || z.car.NoPlate.Contains(filterCar) ||
                    z.car.Color.Contains(filterCar));

            if (x.HasValue || y.HasValue)
            {
                var tempX = x ?? 0;
                var tempY = y ?? 0;

                groupQuery = groupQuery.Where(z =>
                    ((z.LastLocation.GeoX - x) + (z.LastLocation.GeoY - y)) <= SystemInfo.WITHIN_UNIT && 
                    ((z.LastLocation.GeoX - x) + (z.LastLocation.GeoY - y)) >= (SystemInfo.WITHIN_UNIT *-1));
            }

            return groupQuery.AsEnumerable()
                .Select(z => new CarInfo()
                {
                    Car = z.car,
                    LastGeoX = z.LastLocation.GeoX,
                    LastGeoY = z.LastLocation.GeoY
                }).ToList();
        }

        /// <summary>
        /// Book a Car
        /// </summary>
        /// <remarks>For Distance Validation,Users Geo's X And Y must not null else will skip the validation</remarks>
        /// <param name="car">Car Identity</param>
        /// <param name="x">Filter Location X</param>
        /// <param name="y">Filter Location Y</param>
        public virtual async Task<BookingReturnStatus> Book(int car, int? x = null, int? y = null)
        {
            // Data Validation
            var query = _objectContext.Cars.AsTracking().Where(z => z.Id == car);
            if (!query.Any())
                return BookingReturnStatus.InvalidCar;

            // Status Validation
            var carDt = query.FirstOrDefault();
            if (carDt.Status != CarStatus.None)
                return BookingReturnStatus.InvalidCarStatus;

            // User Validation 
            if (x.HasValue && y.HasValue)
            {
                var checkQuery = query
                    .Select(z => new
                    {
                        car = z,
                        LastLocation = z.LocationHistory.Where(w => w.Deleted == false)
                            .OrderByDescending(w => w.CreatedUTCDate).First(),
                    })
                    .Where(z => ((z.LastLocation.GeoX - x) + (z.LastLocation.GeoY - y)) <= SystemInfo.WITHIN_UNIT &&
                                ((z.LastLocation.GeoX - x) + (z.LastLocation.GeoY - y)) >=
                                (SystemInfo.WITHIN_UNIT * -1));

                // For Testing Purpose
                //_logServices.InsertAsync(logLevel: LogLevel.Information, "Car location status",
                //    fullMessage: $" Status : { checkQuery.Any() }");

                if (!checkQuery.Any())
                    return BookingReturnStatus.InvalidDistance;

            }

            var carLastLocation = _objectContext.Locations.Where(z => z.Deleted == false && z.CarId == car)
                .OrderByDescending(z => z.CreatedUTCDate).FirstOrDefault();

            if (carLastLocation == null)
            {
                _logServices.InsertAsync(logLevel: LogLevel.Error, shortMessage: "Invalid Car Location", fullMessage:$"Car Id : { carDt.Id } Invalid Car Location ");
                return BookingReturnStatus.FatalError;
            }

            _objectContext.Records.Add(new Record()
            {
                CarId = carDt.Id,
                BookDate = DateTime.Now,
                GeoX = carLastLocation.GeoX,
                GeoY = carLastLocation.GeoY,
                CreatedBy = 1, // Temporary
                CreatedIP  = _webHelper.GetCurrentIpAddress(),
                CreatedUTCDate = DateTime.UtcNow,
                UpdatedBy = 1, // Temporary
                UpdatedIP = _webHelper.GetCurrentIpAddress(),
                UpdatedUTCDate = DateTime.UtcNow,
            });

            carDt.Status = CarStatus.Booked;
            _objectContext.Cars.Update(carDt);
            await _objectContext.SaveChangesAsync();

            return BookingReturnStatus.Complete;
        }

        /// <summary>
        /// Reach a Car which already been booked
        /// </summary>
        /// <param name="car">Car Identity</param>
        /// <param name="x">User starting Geo X</param>
        /// <param name="y">User starting GeoY</param>
        public virtual ReachReturnDTO Reach(int car, int x, int y)
        {
            var returnObj = new ReachReturnDTO();
            var query = _objectContext.Cars.AsTracking().Where(z => z.Id == car);
            if (!query.Any())
            {
                returnObj.Status = ReachReturnStatus.InvalidCar;
                return returnObj;
            }

            var carDt = query.FirstOrDefault();

            if (carDt.Status != CarStatus.Booked)
            {
                returnObj.Status = ReachReturnStatus.InvalidCarStatus;
                return returnObj;
            }

            var bookQuery = _objectContext.Records.AsNoTracking().Where(z => z.Deleted == false && z.isComplete == false && z.CarId == car);

            if (!bookQuery.Any())
            {
                returnObj.Status = ReachReturnStatus.InvalidBookingRecord;
                return returnObj;
            }

            var bookRecord = bookQuery.OrderByDescending(z => z.CreatedUTCDate).FirstOrDefault();

            var homeLotX = bookRecord.GeoX;
            var homeLotY = bookRecord.GeoY;

            var directionX = homeLotX - x;
            var directionY = homeLotY - y;

            if (directionX != 0)
            {
                if (directionX < 0)
                    returnObj.Direction.Add($" Move { Math.Abs(directionX) } step(s) to your right. Reach : { homeLotX }, { y }");
                else 
                    returnObj.Direction.Add($" Move { directionX } step(s) to your left. Reach : { homeLotX }, { y }");
            }

            if (directionY != 0)
            {
                if (directionY < 0)
                    returnObj.Direction.Add($" Move backward / South { Math.Abs(directionY) } step(s). Reach : {homeLotX }, { homeLotY } ");
                else 
                    returnObj.Direction.Add($" Move forward / north { directionY } step(s). Reach : {homeLotX }, { homeLotY } ");
            }

            returnObj.Status = ReachReturnStatus.Complete;
            return returnObj;
        }
    }
}
