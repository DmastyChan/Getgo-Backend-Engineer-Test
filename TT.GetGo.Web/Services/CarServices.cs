using Microsoft.EntityFrameworkCore;
using TT.GetGo.Core.Domain;
using TT.GetGo.Services.Helper;
using TT.GetGo.Services.Records;
using TT.GetGo.Web.Mapping;

namespace TT.GetGo.Web.Services
{
    public class CarServices:ICarServices
    {
        private readonly GetGoDBContext _objectContext;
        private readonly IWebHelper _webHelper;

        /// <summary>Initializes a new instance of the <see cref="T:System.Object" /> class.</summary>
        public CarServices(GetGoDBContext objectContext, IWebHelper webHelper)
        {
            _objectContext = objectContext;
            _webHelper = webHelper;
        }

        /// <summary>
        /// Deletes a Car
        /// </summary>
        /// <param name="car">Car</param>
        /// <returns>A task that represents the asynchronous operation</returns>
        public virtual async Task DeleteAsync(Car car)
        {
            car.UpdatedBy = 1; // Temporary 
            car.UpdatedIP = _webHelper.GetCurrentIpAddress();
            car.UpdatedUTCDate = DateTime.UtcNow;
            car.Deleted = false;

            _objectContext.Cars.Update(car);
            await _objectContext.SaveChangesAsync();
        }

        /// <summary>
        /// Gets all cars
        /// </summary>
        /// <returns>
        /// A task that represents the asynchronous operation
        /// The task result contains the car
        /// <param name="ids">Array of identifier</param>
        /// </returns>
        public virtual async Task<IList<Car>> GetAllAsync(int[]? ids = null)
        {
            var query = _objectContext.Cars.AsNoTracking().Where(z => z.Deleted == false);
            if (ids != null)
                query = query.Where(z => ids.Contains(z.Id));

            return await query.ToListAsync();
        }

        /// <summary>
        /// Gets a car
        /// </summary>
        /// <param name="id">Car identifier</param>
        /// <returns>
        /// A task that represents the asynchronous operation 
        /// The task result contains the car
        /// </returns>
        public virtual async Task<Car> GetByIdAsync(int id)
        {
            return await _objectContext.Cars.AsTracking().FirstOrDefaultAsync(z => z.Deleted == false && z.Id == id) ?? throw new KeyNotFoundException("Car not found");;
        }

        /// <summary>
        /// Inserts a car
        /// </summary>
        /// <param name="car">Car</param>
        /// <returns>A task that represents the asynchronous operation</returns>
        public virtual async Task InsertAsync(Car car)
        {
            car.CreatedBy = 1; // Temporary
            car.CreatedIP  = _webHelper.GetCurrentIpAddress();
            car.CreatedUTCDate = DateTime.UtcNow;
            car.UpdatedBy = 1; // Temporary
            car.UpdatedIP = _webHelper.GetCurrentIpAddress();
            car.UpdatedUTCDate = DateTime.UtcNow;
            _objectContext.Cars.Add(car);
            await _objectContext.SaveChangesAsync();
        }

        /// <summary>
        /// Updates a car
        /// </summary>
        /// <param name="car">Car</param>
        /// <returns>A task that represents the asynchronous operation</returns>
        public virtual async Task UpdateAsync(Car car)
        {
            car.UpdatedBy = 1; // Temporary
            car.UpdatedIP = _webHelper.GetCurrentIpAddress();
            car.UpdatedUTCDate = DateTime.UtcNow;
            _objectContext.Cars.Update(car);
            await _objectContext.SaveChangesAsync();
        }
    }
}
