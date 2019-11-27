using AutoFixture;
using Microsoft.AspNetCore.Mvc;
using Moq;
using OdeToFood.Core;
using OdeToFood.DAL;
using OdeToFood.Services.Controllers;
using System;
using System.Threading.Tasks;
using Xunit;

namespace OdeToFood.Services.Tests
{
    [Trait("Category", nameof(RestaurantController))]
    public class RestaurantControllerTests
    {
        [Fact]
        public void Get_RestaurantExist_ReturnRestaurant()
        {
            //Arrange
            var fixture = new Fixture();
            var restaurant = fixture.Create<Restaurant>();

            var restaurantData = new Mock<IRestaurantData>();
            restaurantData.Setup(r => r.GetRestaurantByIdAsync(restaurant.Id)).Returns(Task.FromResult(restaurant));

            var controller = new RestaurantController(restaurantData.Object);

            //Act
            var result = controller.GetAsync(restaurant.Id).Result;

            //Assert
            var okObjectResult = Assert.IsType<OkObjectResult>(result);
            var returnedRestaurant = Assert.IsType<Restaurant>(okObjectResult.Value);
            Assert.Equal(restaurant.Id, 0);

        }
    }
}
