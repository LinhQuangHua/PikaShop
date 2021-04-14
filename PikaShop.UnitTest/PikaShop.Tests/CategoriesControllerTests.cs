using System.Threading.Tasks;
using Xunit;
using PikaShop.Controllers;
using PikaShop.ViewModels;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using PikaShop.Models;
using PikaShop.Shared;

namespace PikaShop.UnitTest.PikaShop.Tests
{
    public class CategoriesControllerTests : IClassFixture<SqliteInMemoryFixture>
    {
        private readonly SqliteInMemoryFixture _fixture;
        public CategoriesControllerTests(SqliteInMemoryFixture fixture)
        {
            _fixture = fixture;
            _fixture.CreateDatabase();
        }

        [Fact]
        public async Task PostCategory_Success()
        {
            var dbContext = _fixture.Context;
            var category = new CategoryCreateRequest { name_category = "Test category" };

            var controller = new CategoryController(dbContext);
            var result = await controller.PostCategory(category);

            var createdAtActionResult = Assert.IsType<CreatedAtActionResult>(result.Result);
            var returnValue = Assert.IsType<CategoryVm>(createdAtActionResult.Value);
            Assert.Equal("Test category", returnValue.name_category);
        }

        [Fact]
        public async Task GetCategory_Success()
        {
            var dbContext = _fixture.Context;
            dbContext.Categories.Add(new Category { name_category = "Test brand" });
            await dbContext.SaveChangesAsync();

            var controller = new CategoryController(dbContext);
            var result = await controller.GetCategories();

            var actionResult = Assert.IsType<ActionResult<IEnumerable<CategoryVm>>>(result);
            Assert.NotEmpty(actionResult.Value);
        }

        [Theory]
        [InlineData(2)]
        public async Task GetCategoryById_Success(int id)
        {
            var dbContext = _fixture.Context;
            dbContext.Categories.Add(new Category { id_category = 2});
            await dbContext.SaveChangesAsync();

            var controller = new CategoryController(dbContext);
            var result = await controller.GetCategories(id);

            var actionResult = Assert.IsType<ActionResult<CategoryVm>>(result);
            Assert.NotNull(actionResult.Value);
        }
    }
}
