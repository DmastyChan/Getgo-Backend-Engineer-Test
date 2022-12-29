using Microsoft.EntityFrameworkCore;
using TT.GetGo.Core.Domain;
using TT.GetGo.Services.Helper;
using TT.GetGo.Services.Records;
using TT.GetGo.Web.Mapping;

namespace TT.GetGo.Web.Services
{
    public class LocationServices : ILocationServices
    {
        private readonly GetGoDBContext _objectContext;
        private readonly IWebHelper _webHelper;

        /// <summary>Initializes a new instance of the <see cref="T:System.Object" /> class.</summary>
        public LocationServices(GetGoDBContext objectContext, IWebHelper webHelper)
        {
            _objectContext = objectContext;
            _webHelper = webHelper;
        }

        /// <summary>
        /// Deletes a Location
        /// </summary>
        /// <param name="loc">Location</param>
        /// <returns>A task that represents the asynchronous operation</returns>
        public virtual async Task DeleteAsync(Location loc)
        {
            loc.UpdatedBy = 1; // Temporary 
            loc.UpdatedIP = _webHelper.GetCurrentIpAddress();
            loc.UpdatedUTCDate = DateTime.UtcNow;
            loc.Deleted = false;

            _objectContext.Locations.Update(loc);
            await _objectContext.SaveChangesAsync();
        }

        /// <summary>
        /// Gets all locations By Car Ids
        /// </summary>
        /// <returns>
        /// A task that represents the asynchronous operation
        /// The task result contains the locations
        /// <param name="carids">Array of Cars identifier</param>
        /// </returns>
        public virtual async  Task<IList<Location>> GetAllAsync(int[]? carids = null)
        {
            var query = _objectContext.Locations.AsNoTracking().Where(z => z.Deleted == false);
            if (carids != null)
                query = query.Where(z => carids.Contains(z.CarId));

            return await query.ToListAsync();
        }

        /// <summary>
        /// Gets a location
        /// </summary>
        /// <param name="id">locations identifier</param>
        /// <returns>
        /// A task that represents the asynchronous operation
        /// The task result contains the locations
        /// </returns>
        public virtual async Task<Location> GetByIdAsync(int id)
        {
            return await _objectContext.Locations.AsTracking().FirstOrDefaultAsync(z => z.Deleted == false && z.Id == id) ?? throw new KeyNotFoundException("locations not found");;
        }

        /// <summary>
        /// Inserts a location
        /// </summary>
        /// <param name="loc">Location</param>
        /// <returns>A task that represents the asynchronous operation</returns>
        public virtual async  Task InsertAsync(Location loc)
        {
            loc.CreatedBy = 1; // Temporary
            loc.CreatedIP  = _webHelper.GetCurrentIpAddress();
            loc.CreatedUTCDate = DateTime.UtcNow;
            loc.UpdatedBy = 1; // Temporary
            loc.UpdatedIP = _webHelper.GetCurrentIpAddress();
            loc.UpdatedUTCDate = DateTime.UtcNow;
            _objectContext.Locations.Add(loc);
            await _objectContext.SaveChangesAsync();
        }

        /// <summary>
        /// Updates a location
        /// </summary>
        /// <param name="loc">Location</param>
        /// <returns>A task that represents the asynchronous operation</returns>
        public virtual async Task UpdateAsync(Location loc)
        {
            loc.UpdatedBy = 1; // Temporary
            loc.UpdatedIP = _webHelper.GetCurrentIpAddress();
            loc.UpdatedUTCDate = DateTime.UtcNow;
            _objectContext.Locations.Update(loc);
            await _objectContext.SaveChangesAsync();
        }
    }
}
