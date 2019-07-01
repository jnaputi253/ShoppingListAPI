using System.Threading.Tasks;
using ShoppingListAPI.Entities;

namespace ShoppingListAPI.Repositories
{
    public interface ICategoryRepository : IRepository<Category>
    {
        Task<Category> FindByName(string categoryName);
    }
}