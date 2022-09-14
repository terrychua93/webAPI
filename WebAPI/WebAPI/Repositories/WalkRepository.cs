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
        public IEnumerable<Walk> GetAll()
        {
            return webAPIDbContext.Walks.ToList();
        }
    }
}
