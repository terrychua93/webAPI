using Microsoft.EntityFrameworkCore;
using WebAPI.Models.Domain;

namespace WebAPI.Data
{
    public class WebAPIDbContext: DbContext
    {
        public WebAPIDbContext(DbContextOptions<WebAPIDbContext> opt): base(opt)
        {

        }

        public DbSet<Region> Regions { get; set; }
        public DbSet<Walk> Walks { get; set; }
        public DbSet<WalkDifficulty> WalkDifficulty { get; set; }

    }
}
