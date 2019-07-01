using System.Collections.Generic;
using System.Threading.Tasks;

namespace ShoppingListAPI.Services
{
    public interface IService<TEntity> where TEntity : class
    {
        Task<IEnumerable<TEntity>> FetchAllAsync();
        Task CreateAsync(TEntity newEntity);
    }
}
