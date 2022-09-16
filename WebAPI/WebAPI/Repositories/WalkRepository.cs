using Microsoft.EntityFrameworkCore;
using WebAPI.Data;
using WebAPI.Models.Domain;

namespace WebAPI.Repositories
{
    public class WalkRepository : IWalkRepository
    {
        private readonly WebAPIDbContext webAPIDbContext;
        public WalkRepository(WebAPIDbContext webAPIDbContext)
        {
            this.webAPIDbContext = webAPIDbContext;
        }

        public async Task<Walk> AddAsync(Walk walk)
        {
            walk.Id = Guid.NewGuid();
            await webAPIDbContext.AddAsync(walk);
            await webAPIDbContext.SaveChangesAsync();
            return walk;
        }

        public async Task<IEnumerable<Walk>> GetAllAsync()
        {
            
            return await webAPIDbContext.Walks.ToListAsync();
        }

        public async Task<Walk> GetAsync(Guid id)
        {
           var walks = await webAPIDbContext.Walks.FirstOrDefaultAsync(x => x.Id == id);
            return walks;
        }
    }
}
