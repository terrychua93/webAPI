using AutoMapper;
using Microsoft.EntityFrameworkCore;
using WebAPI.Data;
using WebAPI.Models.Domain;

namespace WebAPI.Repositories
{

    public class WalkRepository : IWalkRepository
    {
        private readonly WebAPIDbContext webAPIDbContext;
        private readonly IMapper mapper;

        public WalkRepository(WebAPIDbContext webAPIDbContext, IMapper mapper)
        {
            this.webAPIDbContext = webAPIDbContext;
            this.mapper = mapper;
        }

        public async Task<Walk> AddAsync(Walk walk)
        {
            walk.Id = Guid.NewGuid();
            await webAPIDbContext.AddAsync(walk);
            await webAPIDbContext.SaveChangesAsync();
            return walk;
        }

        public async Task<Walk> DeleteAsync(Guid id)
        {
            var existedWalk =await webAPIDbContext.Walks.FirstAsync(x => x.Id == id);

            if(existedWalk == null)
            {
                return null;
            }

            webAPIDbContext.Walks.Remove(existedWalk);
            await webAPIDbContext.SaveChangesAsync();
            return existedWalk;


        }

        public async Task<IEnumerable<Walk>> GetAllAsync()
        {
            
            return await webAPIDbContext.Walks.Include(x => x.Region).Include(x => x.WalkDifficulty).ToListAsync();
        }

        public async Task<Walk> GetAsync(Guid id)
        {
           var walks = await webAPIDbContext.Walks.FirstOrDefaultAsync<Walk>(x => x.Id == id);
            return walks;
        }

        public async Task<Walk> UpdateAsync(Guid id, Walk walk)
        {
            /*var existedWalk2 =  await webAPIDbContext.FindAsync<Walk>(id);*/
            var existedWalk = await webAPIDbContext.Walks.FindAsync(id);

            if (existedWalk == null)
            {
                return null;
            }
            
            existedWalk = mapper.Map(walk, existedWalk);
            existedWalk.Id = id;
            /*            existedWalk.Name = walk.Name;
                        existedWalk.Length = walk.Length;
                        existedWalk.WalkDifficultyId = walk.WalkDifficultyId;
                        existedWalk.RegionId = walk.RegionId;*/

            await webAPIDbContext.SaveChangesAsync();
            return existedWalk;


        }
    }
}
