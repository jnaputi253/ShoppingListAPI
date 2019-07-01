using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using MongoDB.Driver;
using ShoppingListAPI.Entities;
using ShoppingListAPI.Entities.Configuration;

namespace ShoppingListAPI.Repositories
{
    public class CategoryRepository : ICategoryRepository
    {
        private readonly IMongoCollection<Category> _categories;

        public CategoryRepository(ShoppingListDatabaseConfiguration databaseConfiguration)
        {
            var client = new MongoClient(databaseConfiguration.ConnectionString);
            var database = client.GetDatabase(databaseConfiguration.DatabaseName);

            _categories = database.GetCollection<Category>(DatabaseNames.Categories);
        }

        public async Task<IEnumerable<Category>> FetchAll()
        {
            IAsyncCursor<Category> fetchedCategories = await _categories.FindAsync(filter => true);
            IEnumerable<Category> categories = await fetchedCategories.ToListAsync();

            return categories;
        }

        public async Task Create(Category newEntity)
        {
            await _categories.InsertOneAsync(newEntity);
        }

        public async Task<Category> FindByName(string categoryName)
        {
            IAsyncCursor<Category> fetchedCategories = await _categories.FindAsync(
                category => category.Name.Equals(categoryName, StringComparison.CurrentCultureIgnoreCase));

            return await fetchedCategories.FirstOrDefaultAsync();
        }
    }
}
