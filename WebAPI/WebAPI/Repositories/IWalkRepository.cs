using WebAPI.Models.Domain;

namespace WebAPI.Repositories
{
    public interface IWalkRepository
    {
        IEnumerable<Walk> GetAll();
    }
}
