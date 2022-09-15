using Microsoft.EntityFrameworkCore;
using WebAPI.Data;
using WebAPI.Models.Domain;

namespace WebAPI.Repositories
{
    public class RegionRepository : IRegionRepository
    {
        private readonly WebAPIDbContext webAPIDbContext;
        public RegionRepository(WebAPIDbContext webAPIDbContext)
        {
            this.webAPIDbContext = webAPIDbContext;
        }

        public async Task<Region> AddAsync(Region region)
        {
            region.Id = Guid.NewGuid();
            await webAPIDbContext.AddAsync(region);
            await webAPIDbContext.SaveChangesAsync();
            return region;
        }

        public async Task<Region> DeleteAsync(Guid id)
        {
            var region = await webAPIDbContext.Regions.FirstOrDefaultAsync(x => x.Id == id);

            if(region == null)
            {
                return null;
            }

            /* DeleteAsync the region */
            webAPIDbContext.Regions.Remove(region);
            await webAPIDbContext.SaveChangesAsync();
            return region;



        }

        public async Task<IEnumerable<Region>> GetAllAsync()
        {
            return await webAPIDbContext.Regions.ToListAsync();
        }

        public async Task<Region> GetAsync(Guid id)
        {
            return await webAPIDbContext.Regions.FirstOrDefaultAsync(x => x.Id == id);
        }

        public async Task<Region> UpdateAsync(Guid id, Region region)
        {
            var existingRegion = await webAPIDbContext.Regions.FirstOrDefaultAsync(x => x.Id == id);

            if(existingRegion == null)
            {
                return null;
            }

            existingRegion.Area = region.Area;
            existingRegion.Code = region.Code;
            existingRegion.Lat = region.Lat;
            existingRegion.Long = region.Long;
            existingRegion.Name = region.Name;
            existingRegion.Population = region.Population;

            await webAPIDbContext.SaveChangesAsync();
            return existingRegion;

        }
    }
}
