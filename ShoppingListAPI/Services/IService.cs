using System.Collections.Generic;
using System.Threading.Tasks;

namespace ShoppingListAPI.Services
{
    public interface IService<TModel> where TModel : class
    {
        Task<IEnumerable<TModel>> FetchAll();
    }
}
