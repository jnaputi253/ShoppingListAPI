using System.Collections.Generic;
using System.Threading.Tasks;
using MongoDB.Driver;
using ShoppingListAPI.Models;
using ShoppingListAPI.Models.Configuration;

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

        public async Task<IEnumerable<Category>> FetchAll()
        {
            IAsyncCursor<Category> fetchedCategories = await _categories.FindAsync(filter => true);
            IEnumerable<Category> categories = await fetchedCategories.ToListAsync();

            return categories;
        }
    }
}
