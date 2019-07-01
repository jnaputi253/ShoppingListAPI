using ShoppingListAPI.Repositories;
using System.Collections.Generic;
using System.Linq;
using FluentAssertions;
using Microsoft.AspNetCore.Mvc;
using Moq;
using ShoppingListAPI.Controllers;
using ShoppingListAPI.Entities;
using ShoppingListAPI.Services;
using Xunit;

namespace ShoppingListAPI.Tests.Controllers
{
    public class CategoriesControllerTests
    {
        private IRepository<Category> _repository;
        private IService<Category> _service;
        private CategoriesController _controller;

        [Fact]
        public async void ShouldReturnNoCategories()
        {
            var mockRepository = new Mock<IRepository<Category>>();
            mockRepository.Setup(mock => mock.FetchAll())
                .ReturnsAsync(new List<Category>());

            _repository = mockRepository.Object;
            _service = new CategoryService(_repository);
            _controller = new CategoriesController(_service);


            IActionResult result = await _controller.FetchAllCategories();


            result.Should().BeOfType<ObjectResult>()
                .Which.Value.Should().BeAssignableTo<IEnumerable<Category>>()
                .Which.Count().Should().Be(0);
        }

        [Fact]
        public async void ShouldReturnTheCorrectAmountOfCategories()
        {
            var categories = new List<Category>
            {
                Mock.Of<Category>(),
                Mock.Of<Category>(),
                Mock.Of<Category>()
            };

            var mockRepository = new Mock<IRepository<Category>>();
            mockRepository.Setup(mock => mock.FetchAll())
                .ReturnsAsync(categories);

            _repository = mockRepository.Object;
            _service = new CategoryService(_repository);
            _controller = new CategoriesController(_service);


            IActionResult result = await _controller.FetchAllCategories();


            result.Should().BeOfType<ObjectResult>()
                .Which.Value.Should().BeAssignableTo<IEnumerable<Category>>()
                .Which.Count().Should().Be(3);
        }
    }
}
