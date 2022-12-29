using Microsoft.EntityFrameworkCore;
using TT.GetGo.Core.Domain;
using TT.GetGo.Services.Helper;
using TT.GetGo.Services.Records;
using TT.GetGo.Web.Mapping;

namespace TT.GetGo.Web.Services
{
    public class RecordServices: IRecordServices
    {
        private readonly GetGoDBContext _objectContext;
        private readonly IWebHelper _webHelper;

        /// <summary>Initializes a new instance of the <see cref="T:System.Object" /> class.</summary>
        public RecordServices(GetGoDBContext objectContext, IWebHelper webHelper)
        {
            _objectContext = objectContext;
            _webHelper = webHelper;
        }

        /// <summary>
        /// Deletes a records
        /// </summary>
        /// <param name="record">Record</param>
        /// <returns>A task that represents the asynchronous operation</returns>
        public virtual async Task DeleteAsync(Record record)
        {
            record.UpdatedBy = 1; // Temporary 
            record.UpdatedIP = _webHelper.GetCurrentIpAddress();
            record.UpdatedUTCDate = DateTime.UtcNow;
            record.Deleted = false;

            _objectContext.Records.Update(record);
            await _objectContext.SaveChangesAsync();
        }

        /// <summary>
        /// Gets all record By Car Ids
        /// </summary>
        /// <returns>
        /// A task that represents the asynchronous operation
        /// The task result contains the record
        /// <param name="carids">Array of Cars identifier</param>
        /// </returns>
        public virtual async Task<IList<Record>> GetAllAsync(int[]? carids = null)
        {
            var query = _objectContext.Records.AsNoTracking().Where(z => z.Deleted == false);
            if (carids != null)
                query = query.Where(z => carids.Contains(z.CarId));

            return await query.ToListAsync();
        }

        /// <summary>
        /// Gets a record
        /// </summary>
        /// <param name="id">record identifier</param>
        /// <returns>
        /// A task that represents the asynchronous operation
        /// The task result contains the record
        /// </returns>
        public virtual async Task<Record> GetByIdAsync(int id)
        {
            return await _objectContext.Records.AsTracking().FirstOrDefaultAsync(z => z.Deleted == false && z.Id == id) ?? throw new KeyNotFoundException("records not found");;
        }

        /// <summary>
        /// Inserts a record
        /// </summary>
        /// <param name="record">Record</param>
        /// <returns>A task that represents the asynchronous operation</returns>
        public virtual async Task InsertAsync(Record record)
        {
            record.CreatedBy = 1; // Temporary
            record.CreatedIP  = _webHelper.GetCurrentIpAddress();
            record.CreatedUTCDate = DateTime.UtcNow;
            record.UpdatedBy = 1; // Temporary
            record.UpdatedIP = _webHelper.GetCurrentIpAddress();
            record.UpdatedUTCDate = DateTime.UtcNow;
            _objectContext.Records.Add(record);
            await _objectContext.SaveChangesAsync();
        }

        /// <summary>
        /// Updates a record
        /// </summary>
        /// <param name="record">Record</param>
        /// <returns>A task that represents the asynchronous operation</returns>
        public virtual async Task UpdateAsync(Record record)
        {
            record.UpdatedBy = 1; // Temporary
            record.UpdatedIP = _webHelper.GetCurrentIpAddress();
            record.UpdatedUTCDate = DateTime.UtcNow;
            _objectContext.Records.Update(record);
            await _objectContext.SaveChangesAsync();
        }
    }
}
