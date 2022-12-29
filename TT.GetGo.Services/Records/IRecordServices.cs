using TT.GetGo.Core.Domain;

namespace TT.GetGo.Services.Records
{
    public interface IRecordServices
    {
        /// <summary>
        /// Deletes a records
        /// </summary>
        /// <param name="record">Record</param>
        /// <returns>A task that represents the asynchronous operation</returns>
        Task DeleteAsync(Record record);

        /// <summary>
        /// Gets all record By Car Ids
        /// </summary>
        /// <returns>
        /// A task that represents the asynchronous operation
        /// The task result contains the record
        /// <param name="carids">Array of Cars identifier</param>
        /// </returns>
        Task<IList<Record>> GetAllAsync(int[]? carids = null);

        /// <summary>
        /// Gets a record
        /// </summary>
        /// <param name="id">record identifier</param>
        /// <returns>
        /// A task that represents the asynchronous operation
        /// The task result contains the record
        /// </returns>
        Task<Record> GetByIdAsync(int id);

        /// <summary>
        /// Inserts a record
        /// </summary>
        /// <param name="record">Record</param>
        /// <returns>A task that represents the asynchronous operation</returns>
        Task InsertAsync(Record record);

        /// <summary>
        /// Updates a record
        /// </summary>
        /// <param name="record">Record</param>
        /// <returns>A task that represents the asynchronous operation</returns>
        Task UpdateAsync(Record record);
    }
}
