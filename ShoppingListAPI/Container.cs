using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Options;
using ShoppingListAPI.Entities;
using ShoppingListAPI.Entities.Configuration;
using ShoppingListAPI.Repositories;
using ShoppingListAPI.Services;

namespace ShoppingListAPI
{
    public sealed class Container
    {
        private readonly IServiceCollection _serviceCollection;
        private readonly IConfiguration _configuration;

        public Container(IServiceCollection serviceCollection, IConfiguration configuration)
        {
            _serviceCollection = serviceCollection;
            _configuration = configuration;
        }

        public void RegisterDependencies()
        {
            ConfigureMongo();
            ConfigureGeneralDependencies();
        }

        private void ConfigureMongo()
        {
            _serviceCollection.Configure<ShoppingListDatabaseConfiguration>(
                _configuration.GetSection(nameof(ShoppingListDatabaseConfiguration)));
            _serviceCollection.AddSingleton(serviceProvider =>
                serviceProvider.GetRequiredService<IOptions<ShoppingListDatabaseConfiguration>>().Value);
        }

        private void ConfigureGeneralDependencies()
        {
            _serviceCollection.AddSingleton<IRepository<Category>, CategoryRepository>();
            _serviceCollection.AddSingleton<IService<Category>, CategoryService>();
        }
    }
}
