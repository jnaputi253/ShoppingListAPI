using System.Collections.Generic;
using System.Threading.Tasks;

namespace ShoppingListAPI.Repositories
{
    public interface IRepository<TEntity> where TEntity : class
    {
        Task<IEnumerable<TEntity>> FetchAll();
        Task Create(TEntity newEntity);
    }
}
