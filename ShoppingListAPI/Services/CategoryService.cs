using System.Collections.Generic;
using System.Threading.Tasks;
using ShoppingListAPI.Entities;
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

        public async Task<IEnumerable<Category>> FetchAllAsync()
        {
            IEnumerable<Category> categories = await _repository.FetchAllAsync();

            return categories;
        }

        public async Task CreateAsync(Category newEntity)
        {
            if (await _repository.ExistsAsync(newEntity))
            {
                return;
            }

            await _repository.CreateAsync(newEntity);
        }
    }
}
