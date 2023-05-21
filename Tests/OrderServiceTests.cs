using FluentAssertions;
using Refactoring.Web.Controllers;
using Refactoring.Web.DomainModels;
using Refactoring.Web.Services;

namespace Tests;

public class OrderServiceTests
{
    [Fact]
    public async Task ProcessOrder_WhenCalledWithCambridge_UpdatesOrderAsExpected()
    {
        //Arrange
        var selectedDistrict = "Cambridge";
        var order = new Order {District = selectedDistrict};
            
        //Act
        await new OrderService(order).ProcessOrder();
        
        //Assert
        order.Status.Should().Be("Complete");
        order.District.Should().Be(selectedDistrict);
        order.Advert.Content.Should().Be("Custom Birthday and Wedding Cakes");
        order.Advert.Heading.Should().Be("Cambridge Bakery");
        order.Advert.ImageUrl.Should().Be(null);
    }
    
    [Fact]
    public async Task ProcessOrder_WhenCalledWithDowntown_UpdatesOrderAsExpected()
    {
        //Arrange
        var selectedDistrict = "Downtown";
        var order = new Order {District = selectedDistrict};
            
        //Act
        await new OrderService(order).ProcessOrder();
        
        //Assert
        order.Status.Should().Be("Complete");
        order.District.Should().Be(selectedDistrict);
        order.Advert.Content.Should().Be("Get a free coffee drink when you buy 1lb of coffee beans");
        order.Advert.Heading.Should().Be("Downtown Coffee Roasters");
        order.Advert.ImageUrl.Should().Be(null);
    }
    
    [Fact]
    public async Task ProcessOrder_WhenCalledWithCounty_UpdatesOrderAsExpected()
    {
        //Arrange
        var selectedDistrict = "County";
        var order = new Order {District = selectedDistrict};
            
        //Act
        await new OrderService(order).ProcessOrder();
        
        //Assert
        order.Status.Should().Be("Complete");
        order.District.Should().Be(selectedDistrict);
        order.Advert.Content.Should().Be("Kids eat free every Thursday night");
        order.Advert.Heading.Should().Be("County Diner");
        order.Advert.ImageUrl.Should().Be(null);
    }
    
    [Fact]
    public async Task ProcessOrder_WhenCalledWithMiddleton_UpdatesOrderAsExpected()
    {
        //Arrange
        var selectedDistrict = "Middleton";
        var order = new Order {District = selectedDistrict};
            
        //Act
        await new OrderService(order).ProcessOrder();
        
        //Assert
        order.Status.Should().Be("Complete");
        order.District.Should().Be(selectedDistrict);
        order.Advert.Content.Should().ContainAll("Percent off your next purchase!");
        order.Advert.Heading.Should().ContainAll(selectedDistrict);
        order.Advert.ImageUrl.Should().Be("https://via.placeholder.com/150/1fe46f");
    }
}