using Microsoft.EntityFrameworkCore;
using TT.GetGo.Core.Domain;
using TT.GetGo.Services.Helper;
using TT.GetGo.Services.Logging;
using TT.GetGo.Web.Mapping;
using LogLevel = TT.GetGo.Core.Domain.LogLevel;

namespace TT.GetGo.Web.Services
{
    public class LogServices: ILogServices
    {
        private readonly GetGoDBContext _objectContext;
        private readonly IWebHelper _webHelper;

        /// <summary>Initializes a new instance of the <see cref="T:System.Object" /> class.</summary>
        public LogServices(
            GetGoDBContext objectContext, 
            IWebHelper webHelper)
        {
            _objectContext = objectContext;
            _webHelper = webHelper;
        }

        /// <summary>
        /// Get log items by identifiers
        /// </summary>
        /// <param name="ids">Log item identifiers</param>
        /// <returns>Log items</returns>
        public virtual async Task<IList<Log>> GetByIdsAsync(int[]? ids = null)
        {
            var query = _objectContext.Logs.AsNoTracking();
            if (ids != null)
                query = query.Where(z => ids.Contains(z.Id));

            return await query.ToListAsync();
        }

        /// <summary>
        /// Deletes a log item
        /// </summary>
        /// <param name="ids">Log item identifiers</param>
        public virtual async Task DeleteAsync(int[]? ids = null)
        {
            var query = _objectContext.Logs.AsTracking();
            if (ids != null)
                query = query.Where(z => ids.Contains(z.Id));

            await query.ExecuteDeleteAsync();
        }

        /// <summary>
        /// Inserts a log item
        /// </summary>
        /// <param name="logLevel">Log level</param>
        /// <param name="shortMessage">The short message</param>
        /// <param name="fullMessage">The full message</param>
        /// <returns>A log item</returns>
        public virtual async Task<Log> InsertAsync(LogLevel logLevel, string shortMessage, string fullMessage = "")
        {
            var log = new Log
            {
                LogLevelId = logLevel,
                ShortMessage = shortMessage,
                FullMessage = fullMessage,
                IpAddress = _webHelper.GetCurrentIpAddress(),
                UserId = 1, // Temporary for testing
                PageUrl = _webHelper.GetThisPageUrl(true),
                ReferrerUrl = _webHelper.GetUrlReferrer(),
                CreatedUTCDate = DateTime.UtcNow 
            };

            _objectContext.Logs.Add(log);
            await _objectContext.SaveChangesAsync();

            return log;
        }
    }
}
