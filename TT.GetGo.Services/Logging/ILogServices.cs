using TT.GetGo.Core.Domain;

namespace TT.GetGo.Services.Logging
{
    public interface ILogServices
    {
        /// <summary>
        /// Get log items by identifiers
        /// </summary>
        /// <param name="ids">Log item identifiers</param>
        /// <returns>Log items</returns>
        Task<IList<Log>> GetByIdsAsync(int[]? ids = null);

        /// <summary>
        /// Deletes a log item
        /// </summary>
        /// <param name="ids">Log item identifiers</param>
        Task DeleteAsync(int[]? ids = null);

        /// <summary>
        /// Inserts a log item
        /// </summary>
        /// <param name="logLevel">Log level</param>
        /// <param name="shortMessage">The short message</param>
        /// <param name="fullMessage">The full message</param>
        /// <returns>A log item</returns>
        Task<Log> InsertAsync(LogLevel logLevel, string shortMessage, string fullMessage = "");
    }
}
