using CodeBridgeTestTask.Core.Entities;
using CodeBridgeTestTask.DAL.Helpers;
using System.Threading.Tasks;

namespace CodeBridgeTestTask.Infrastructure.Data.Repositories
{
    public interface IDogsRepository
    {
        Task<PagedList<Dog>> GetDogsAsync(SortingParams sortingParams, PagingParams pagingParams);
        Task<Dog> GetDogAsync(int id);
        Task AddDogAsync(Dog dog);
        Task<bool> IsExists(string name);
        Task<int> SaveChangesAsync();
    }
}
