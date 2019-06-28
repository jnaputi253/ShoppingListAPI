using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using ShoppingListAPI.Models;
using ShoppingListAPI.Services;

namespace ShoppingListAPI.Controllers
{
    [ApiController]
    [Route("/api/v1/[controller]")]
    public class CategoriesController
    {
        private readonly IService<Category> _service;

        public CategoriesController(IService<Category> service)
        {
            _service = service;
        }

        [HttpGet]
        public async Task<IActionResult> FetchAllCategories()
        {
            IEnumerable<Category> categories = await _service.FetchAll();

            return new ObjectResult(categories);
        }
    }
}
