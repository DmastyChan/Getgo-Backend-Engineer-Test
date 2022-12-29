using TT.GetGo.Core.Domain;

namespace TT.GetGo.Services.Records
{
    public interface ICarWorkflow
    {
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
        IList<CarInfo> GetAll(int[]? ids = null, string? filterCar = null, int? x = null, int? y = null, CarStatus[]? filterStatus = null);

        /// <summary>
        /// Book a Car
        /// </summary>
        /// <remarks>For Distance Validation,Users Geo's X And Y must not null else will skip the validation</remarks>
        /// <param name="car">Car Identity</param>
        /// <param name="x">User Geo X</param>
        /// <param name="y">User Geo Y</param>
        Task<BookingReturnStatus> Book(int car, int? x = null, int? y = null);

        /// <summary>
        /// Reach a Car which already been booked
        /// </summary>
        /// <param name="car">Car Identity</param>
        /// <param name="x">User starting Geo X</param>
        /// <param name="y">User starting GeoY</param>
        ReachReturnDTO Reach(int car, int x, int y);
    }
}
