using System.Collections.Generic;
using System.Threading.Tasks;
using ShoppingListAPI.Models;
using ShoppingListAPI.Repositories;

namespace ShoppingListAPI.Services
{
    public class CategoryService : IService<Category>
    {
        private readonly IRepository<Category> _repository;

        public CategoryService(IRepository<Category> repository)
        {
            _repository = repository;
        }

        public async Task<IEnumerable<Category>> FetchAll()
        {
            IEnumerable<Category> categories = await _repository.FetchAll();

            return categories;
        }
    }
}
