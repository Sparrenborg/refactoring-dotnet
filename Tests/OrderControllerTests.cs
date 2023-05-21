using FluentAssertions;
using Moq;
using Refactoring.Web.Controllers;
using Refactoring.Web.DomainModels;
using Refactoring.Web.Services;

namespace Tests;

public class OrderControllerTests
{
    [Fact]
    public async Task CompleteOrder_WhenCalledWithCambridge_ReturnsExpectedDistrict()
    {
        //Arrange
        var selectedDistrict = "Cambridge";
        var orderAmount = 10;
        var order = new Order
        {
            District = selectedDistrict,
            Total = orderAmount
        };
        var mockOrderService = new Mock<IOrderService>();
        mockOrderService.Setup(service => service.GetOrder()).Returns(order);
        var sut = new OrderController(mockOrderService.Object);
        

        //Act
        var completedOrder = await sut.CompletedOrder(order);

        //Assert
        completedOrder.District.Should().Be(selectedDistrict);

    }
    
    [Fact]
    public async Task CompleteOrder_WhenCalledWithCambridge_ReturnsExpectedAdvert()
    {
        //Arrange
        var selectedDistrict = "Cambridge";
        var orderAmount = 10;
        var advert = new Advert
        {
            Content = "Custom Birthday and Wedding Cakes",
            Heading = "Cambridge Bakery"
        };
        var order = new Order
        {
            District = selectedDistrict,
            Total = orderAmount
        };
        var mockOrderService = new Mock<IOrderService>();
        mockOrderService.Setup(service => service.CreateAdvert(selectedDistrict)).ReturnsAsync(advert);
        mockOrderService.Setup(service => service.GetOrder()).Returns(order);
        var sut = new OrderController(mockOrderService.Object);
        

        //Act
        var completedOrder = (Order) await sut.CompletedOrder(order);

        //Assert
        completedOrder.Advert.Content.Should().Be("Custom Birthday and Wedding Cakes");
    }
    
    
    
    [Fact]
    public async Task CompleteOrder_WhenCalledWithDowntown_ReturnsExpectedDistrict()
    {
        //Arrange
        var selectedDistrict = "Downtown";
        var orderAmount = 10;
        var advert = new Advert();
        var mockOrderService = new Mock<IOrderService>();
        mockOrderService.Setup(service => service.CreateAdvert(selectedDistrict)).ReturnsAsync(advert);
        var sut = new OrderController(mockOrderService.Object);

        var order = new Order
        {
            District = selectedDistrict,
            Total = orderAmount,
        };

        //Act
        var completedOrder = await sut.CompletedOrder(order);

        //Assert
        completedOrder.District.Should().Be(selectedDistrict);
        
    }
    
    
    [Fact]
    public async Task CompleteOrder_WhenCalledWithDowntown_ReturnsExpectedAdvert()
    {
        //Arrange
        var selectedDistrict = "Downtown";
        var orderAmount = 10;
        var advert = new Advert();
        var mockOrderService = new Mock<IOrderService>();
        mockOrderService.Setup(service => service.CreateAdvert(selectedDistrict)).ReturnsAsync(advert);
        var sut = new OrderController(mockOrderService.Object);

        var order = new Order
        {
            District = selectedDistrict,
            Total = orderAmount,
        };
        
        //Act
        var completedOrder = await sut.CompletedOrder(order);

        //Assert
        completedOrder.Advert.Heading.Should().Be("Downtown Coffee Roasters");
        completedOrder.Advert.Content.Should().Be("");
        completedOrder.Advert.ImageUrl.Should().Be(null);
    }
    
 
    [Fact]
    public async Task CompleteOrder_WhenCalledWithCounty_ReturnsExpectedDistrict()
    {
        //Arrange
        var selectedDistrict = "County";
        var orderAmount = 10;
        var advert = new Advert();
        var mockOrderService = new Mock<IOrderService>();
        mockOrderService.Setup(service => service.CreateAdvert(selectedDistrict)).ReturnsAsync(advert);
        var sut = new OrderController(mockOrderService.Object);

        var order = new Order
        {
            District = selectedDistrict,
            Total = orderAmount
        };

        //Act
        var completedOrder = await sut.CompletedOrder(order);

        //Assert
        completedOrder.District.Should().Be(selectedDistrict);
    }
    
    [Fact]
    public async Task CompleteOrder_WhenCalledWithCounty_ReturnsExpectedAdvert()
    {
        //Arrange
        var selectedDistrict = "County";
        var orderAmount = 10;
        var advert = new Advert();
        var mockOrderService = new Mock<IOrderService>();
        mockOrderService.Setup(service => service.CreateAdvert(selectedDistrict)).ReturnsAsync(advert);
        var sut = new OrderController(mockOrderService.Object);
        var order = new Order
        {
            District = selectedDistrict,
            Total = orderAmount
        };

        //Act
        var completedOrder = await sut.CompletedOrder(order);

        //Assert
        completedOrder.Advert.Content.Should().Be("Kids eat free every Thursday night");
        completedOrder.Advert.Heading.Should().Be("County Diner");
        completedOrder.Advert.ImageUrl.Should().Be(null);
    }

    
    [Fact]
    public async Task CompleteOrder_WhenCalledWithMiddleton_ReturnsExpectedDistrict()
    {
        //Arrange
        var selectedDistrict = "Middleton";
        var orderAmount = 10;
        var advert = new Advert();
        var mockOrderService = new Mock<IOrderService>();
        mockOrderService.Setup(service => service.CreateAdvert(selectedDistrict)).ReturnsAsync(advert);
        var sut = new OrderController(mockOrderService.Object);
        var order = new Order
        {
            District = selectedDistrict,
            Total = orderAmount
        };

        //Act
        var completedOrder = await sut.CompletedOrder(order);

        //Assert
        completedOrder.District.Should().Be(selectedDistrict);
    }
    
    [Fact]
    public async Task CompleteOrder_WhenCalledWithMiddleton_ReturnsExpectedAdvert()
    {
        //Arrange
        var selectedDistrict = "Middleton";
        var orderAmount = 10;
        var advert = new Advert();
        var mockOrderService = new Mock<IOrderService>();
        mockOrderService.Setup(service => service.CreateAdvert(selectedDistrict)).ReturnsAsync(advert);
        var sut = new OrderController(mockOrderService.Object);
        var order = new Order
        {
            District = selectedDistrict,
            Total = orderAmount
        };

        //Act
        var completedOrder = await sut.CompletedOrder(order);

        //Assert
        completedOrder.Advert.Content.Should().ContainAll("Percent off your next purchase!");
        completedOrder.Advert.Heading.Should().ContainAll(selectedDistrict);
        completedOrder.Advert.ImageUrl.Should().Be("https://via.placeholder.com/150/1fe46f");
    }
}