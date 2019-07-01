using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using MongoDB.Driver;
using ShoppingListAPI.Entities;
using ShoppingListAPI.Entities.Configuration;

namespace ShoppingListAPI.Repositories
{
    public class CategoryRepository : IRepository<Category>
    {
        private readonly IMongoCollection<Category> _categories;

        public CategoryRepository(ShoppingListDatabaseConfiguration databaseConfiguration)
        {
            var client = new MongoClient(databaseConfiguration.ConnectionString);
            var database = client.GetDatabase(databaseConfiguration.DatabaseName);

            _categories = database.GetCollection<Category>(DatabaseNames.Categories);
        }

        public async Task<IEnumerable<Category>> FetchAllAsync()
        {
            IAsyncCursor<Category> fetchedCategories = await _categories.FindAsync(filter => true);
            IEnumerable<Category> categories = await fetchedCategories.ToListAsync();

            return categories;
        }

        public async Task CreateAsync(Category newEntity)
        {
            await _categories.InsertOneAsync(newEntity);
        }

        public async Task<bool> ExistsAsync(Category entityToCheck)
        {
            IAsyncCursor<Category> fetchedCategories = await _categories.FindAsync(
                category => category.Name.Equals(entityToCheck.Name, StringComparison.CurrentCultureIgnoreCase));

            return await fetchedCategories.FirstOrDefaultAsync() == null;
        }
    }
}
