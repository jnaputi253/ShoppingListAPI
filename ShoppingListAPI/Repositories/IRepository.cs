using System.Collections.Generic;
using System.Threading.Tasks;

namespace ShoppingListAPI.Repositories
{
    public interface IRepository<TModel> where TModel : class
    {
        Task<IEnumerable<TModel>> FetchAll();
    }
}
