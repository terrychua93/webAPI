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
        public async Task<IEnumerable<Region>> GetAllAsync()
        {
            return await webAPIDbContext.Regions.ToListAsync();
        }


    }
}
