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
    public class BrandsControllerTests : IClassFixture<SqliteInMemoryFixture>
    {
        private readonly SqliteInMemoryFixture _fixture;
        public BrandsControllerTests(SqliteInMemoryFixture fixture)
        {
            _fixture = fixture;
            _fixture.CreateDatabase();
        }

        [Fact]
        public async Task PostBrand_Success()
        {
            var dbContext = _fixture.Context;
            var brand = new BrandCreateRequest { Name = "Test brand" };

            var controller = new BrandsController(dbContext);
            var result = await controller.PostBrand(brand);

            var createdAtActionResult = Assert.IsType<CreatedAtActionResult>(result.Result);
            var returnValue = Assert.IsType<BrandVm>(createdAtActionResult.Value);
            Assert.Equal("Test brand", returnValue.Name);
        }

        [Fact]
        public async Task GetBrand_Success()
        {
            var dbContext = _fixture.Context;
            dbContext.Brands.Add(new Brand { Name = "Test brand" });
            await dbContext.SaveChangesAsync();

            var controller = new BrandsController(dbContext);
            var result = await controller.GetBrands();

            var actionResult = Assert.IsType<ActionResult<IEnumerable<BrandVm>>>(result);
            Assert.NotEmpty(actionResult.Value);
        }

        [Theory]
        [InlineData(2)]
        public async Task GetBrandById_Success(int id)
        {
            var dbContext = _fixture.Context;
            dbContext.Brands.Add(new Brand {Id = 2, Name = "Test brand" });
            await dbContext.SaveChangesAsync();

            var controller = new BrandsController(dbContext);
            var result = await controller.GetBrand(id);

            var actionResult = Assert.IsType<ActionResult<BrandVm>>(result);
            Assert.NotNull(actionResult.Value);
        }

        //[Theory]
        //[InlineData(1)]
        //public async Task PutBrand_Success(int id)
        //{
        //    var dbContext = _fixture.Context;
        //    Brand brand = new Brand { Id = 1, Name = "Test brand" };
        //    await dbContext.SaveChangesAsync();

        //    var controller = new BrandsController(dbContext);
        //    var result = await controller.DeleteBrand(id);

        //    var actionResult = Assert.IsType<ActionResult<Brand>>(result);
        //    Assert.True(brand == actionResult.Value);
        //}
    }
}
