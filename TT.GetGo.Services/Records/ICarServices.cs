using TT.GetGo.Core.Domain;

namespace TT.GetGo.Services.Records
{
    public interface ICarServices
    {
        /// <summary>
        /// Deletes a Car
        /// </summary>
        /// <param name="car">Car</param>
        /// <returns>A task that represents the asynchronous operation</returns>
        Task DeleteAsync(Car car);

        /// <summary>
        /// Gets all cars
        /// </summary>
        /// <returns>
        /// A task that represents the asynchronous operation
        /// The task result contains the car
        /// <param name="ids">Array of identifier</param>
        /// </returns>
        Task<IList<Car>> GetAllAsync(int[]? ids = null);

        /// <summary>
        /// Gets a car
        /// </summary>
        /// <param name="id">Car identifier</param>
        /// <returns>
        /// A task that represents the asynchronous operation
        /// The task result contains the car
        /// </returns>
        Task<Car> GetByIdAsync(int id);

        /// <summary>
        /// Inserts a car
        /// </summary>
        /// <param name="car">Car</param>
        /// <returns>A task that represents the asynchronous operation</returns>
        Task InsertAsync(Car car);

        /// <summary>
        /// Updates a car
        /// </summary>
        /// <param name="car">Car</param>
        /// <returns>A task that represents the asynchronous operation</returns>
        Task UpdateAsync(Car car);
    }
}
