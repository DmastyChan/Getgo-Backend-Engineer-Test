using TT.GetGo.Core.Domain;

namespace TT.GetGo.Services.Records
{
    public interface ILocationServices
    {
        /// <summary>
        /// Deletes a Location
        /// </summary>
        /// <param name="loc">Location</param>
        /// <returns>A task that represents the asynchronous operation</returns>
        Task DeleteAsync(Location loc);

        /// <summary>
        /// Gets all locations By Car Ids
        /// </summary>
        /// <returns>
        /// A task that represents the asynchronous operation
        /// The task result contains the locations
        /// <param name="carids">Array of Cars identifier</param>
        /// </returns>
        Task<IList<Location>> GetAllAsync(int[]? carids = null);

        /// <summary>
        /// Gets a location
        /// </summary>
        /// <param name="id">locations identifier</param>
        /// <returns>
        /// A task that represents the asynchronous operation
        /// The task result contains the locations
        /// </returns>
        Task<Location> GetByIdAsync(int id);

        /// <summary>
        /// Inserts a location
        /// </summary>
        /// <param name="loc">Location</param>
        /// <returns>A task that represents the asynchronous operation</returns>
        Task InsertAsync(Location loc);

        /// <summary>
        /// Updates a location
        /// </summary>
        /// <param name="loc">Location</param>
        /// <returns>A task that represents the asynchronous operation</returns>
        Task UpdateAsync(Location loc);
    }
}
