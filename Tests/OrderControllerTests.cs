using FluentAssertions;
using Refactoring.Web.Controllers;
using Refactoring.Web.DomainModels;

namespace Tests;

public class OrderControllerTests
{
    [Theory]
    [InlineData("Cambridge", 10)]
    public async Task CompleteOrder_WhenCalledWithCambridge_ReturnsExpectedDistrict(string selectedDistrict, decimal orderAmount)
    {
        //Arrange
        var sut = new OrderController();

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
    
    [Theory]
    [InlineData("Cambridge", 0)]
    [InlineData("Cambridge", 1)]
    [InlineData("Cambridge", 800)]
    public async Task CompleteOrder_WhenCalledWithCambridge_ReturnsExpectedAdvertContent(string selectedDistrict, decimal orderAmount)
    {
        //Arrange
        var sut = new OrderController();

        var order = new Order
        {
            District = selectedDistrict,
            Total = orderAmount
        };

        //Act
        var completedOrder = await sut.CompletedOrder(order);

        //Assert
        completedOrder.Advert.Content.Should().Be("Custom Birthday and Wedding Cakes");
    }
    
    
    [Theory]
    [InlineData("Cambridge", 0)]
    [InlineData("Cambridge", 1)]
    [InlineData("Cambridge", 800)]
    public async Task CompleteOrder_WhenCalledWithCambridge_ReturnsExpectedAdvertHeading(string selectedDistrict, decimal orderAmount)
    {
        //Arrange
        var sut = new OrderController();

        var order = new Order
        {
            District = selectedDistrict,
            Total = orderAmount
        };

        //Act
        var completedOrder = await sut.CompletedOrder(order);

        //Assert
        completedOrder.Advert.Heading.Should().Be("Cambridge Bakery");
    }
    
    [Theory]
    [InlineData("Cambridge", 0)]
    [InlineData("Cambridge", 1)]
    [InlineData("Cambridge", 800)]
    public async Task CompleteOrder_WhenCalledWithCambridgeNotTuesday_ReturnsExpectedAdvertImageUrl(string selectedDistrict, decimal orderAmount)
    {
        //Arrange
        var sut = new OrderController();

        var order = new Order
        {
            District = selectedDistrict,
            Total = orderAmount
        };

        //Act
        var completedOrder = await sut.CompletedOrder(order);

        //Assert
        completedOrder.Advert.ImageUrl.Should().Be(null);
    }
    
    [Theory]
    [InlineData("Cambridge", 0)]
    [InlineData("Cambridge", 1)]
    [InlineData("Cambridge", 800)]
    public async Task CompleteOrder_WhenCalledWithCambridgeTuesday_ReturnsExpectedAdvertImageUrl(string selectedDistrict, decimal orderAmount)
    {
        //Arrange
        var sut = new OrderController();

        var order = new Order
        {
            District = selectedDistrict,
            Total = orderAmount,
        };

        //Act
        var completedOrder = await sut.CompletedOrder(order);

        //Assert
        completedOrder.Advert.ImageUrl.Should().Be("https://via.placeholder.com/150/1fe46f");
        
    }
    
    [Theory]
    [InlineData("Downtown", 10)]
    public async Task CompleteOrder_WhenCalledWithDowntown_ReturnsExpectedDistrict(string selectedDistrict, decimal orderAmount)
    {
        //Arrange
        var sut = new OrderController();
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
    
    
    
    [Theory]
    [InlineData("Downtown", 0)]
    [InlineData("Downtown", 1)]
    [InlineData("Downtown", 800)]
    public async Task CompleteOrder_WhenCalledWithDowntown_ReturnsExpectedAdvertHeading(string selectedDistrict, decimal orderAmount)
    {
        //Arrange
        var sut = new OrderController();
        var order = new Order
        {
            District = selectedDistrict,
            Total = orderAmount
        };

        //Act
        var completedOrder = await sut.CompletedOrder(order);

        //Assert
        completedOrder.Advert.Heading.Should().Be("Downtown Coffee Roasters");
    }
    
    [Theory]
    [InlineData("Downtown", 0)]
    [InlineData("Downtown", 1)]
    [InlineData("Downtown", 800)]
    public async Task CompleteOrder_WhenCalledWithDowntown_ReturnsExpectedAdvertImageUrl(string selectedDistrict, decimal orderAmount)
    {
        //Arrange
        var sut = new OrderController();
        var order = new Order
        {
            District = selectedDistrict,
            Total = orderAmount
        };

        //Act
        var completedOrder = await sut.CompletedOrder(order);

        //Assert
        completedOrder.Advert.ImageUrl.Should().Be(null);
    }

    [Theory]
    [InlineData("County", 10)]
    public async Task CompleteOrder_WhenCalledWithCounty_ReturnsExpectedDistrict(string selectedDistrict, decimal orderAmount)
    {
        //Arrange
        var sut = new OrderController();
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
    
    [Theory]
    [InlineData("County", 0)]
    [InlineData("County", 1)]
    [InlineData("County", 800)]
    public async Task CompleteOrder_WhenCalledWithCounty_ReturnsExpectedAdvertContent(string selectedDistrict, decimal orderAmount)
    {
        //Arrange
        var sut = new OrderController();
        var order = new Order
        {
            District = selectedDistrict,
            Total = orderAmount
        };

        //Act
        var completedOrder = await sut.CompletedOrder(order);

        //Assert
        completedOrder.Advert.Content.Should().Be("Kids eat free every Thursday night");
    }

    [Theory]
    [InlineData("County", 0)]
    [InlineData("County", 1)]
    [InlineData("County", 800)]
    public async Task CompleteOrder_WhenCalledWithCounty_ReturnsExpectedAdvertHeading(string selectedDistrict, decimal orderAmount)
    {
        //Arrange
        var sut = new OrderController();
        var order = new Order
        {
            District = selectedDistrict,
            Total = orderAmount
        };

        //Act
        var completedOrder = await sut.CompletedOrder(order);

        //Assert
        completedOrder.Advert.Heading.Should().Be("County Diner");
    }
    
    [Theory]
    [InlineData("County", 0)]
    [InlineData("County", 1)]
    [InlineData("County", 800)]
    public async Task CompleteOrder_WhenCalledWithCounty_ReturnsExpectedAdvertImageUrl(string selectedDistrict, decimal orderAmount)
    {
        //Arrange
        var sut = new OrderController();
        var order = new Order
        {
            District = selectedDistrict,
            Total = orderAmount
        };

        //Act
        var completedOrder = await sut.CompletedOrder(order);

        //Assert

        completedOrder.Advert.ImageUrl.Should().Be(null);
    }
    
    [Theory]
    [InlineData("Middleton", 10)]
 
    public async Task CompleteOrder_WhenCalledWithMiddleton_ReturnsExpectedDistrict(string selectedDistrict, decimal orderAmount)
    {
        //Arrange
        var sut = new OrderController();
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
    
    [Theory]
    [InlineData("Middleton", 0)]
    [InlineData("Middleton", 1)]
    [InlineData("Middleton", 800)]
    public async Task CompleteOrder_WhenCalledWithMiddleton_ReturnsExpectedAdvertContent(string selectedDistrict, decimal orderAmount)
    {
        //Arrange
        var sut = new OrderController();
        var order = new Order
        {
            District = selectedDistrict,
            Total = orderAmount
        };

        //Act
        var completedOrder = await sut.CompletedOrder(order);

        //Assert
        completedOrder.Advert.Content.Should().ContainAll("Percent off your next purchase!");
    }
    
    [Theory]
    [InlineData("Middleton", 0)]
    [InlineData("Middleton", 1)]
    [InlineData("Middleton", 800)]
    public async Task CompleteOrder_WhenCalledWithMiddleton_ReturnsExpectedAdvertHeading(string selectedDistrict, decimal orderAmount)
    {
        //Arrange
        var sut = new OrderController();
        var order = new Order
        {
            District = selectedDistrict,
            Total = orderAmount
        };

        //Act
        var completedOrder = await sut.CompletedOrder(order);

        //Assert
        completedOrder.Advert.Heading.Should().ContainAll(selectedDistrict);
    }
    
    [Theory]
    [InlineData("Middleton", 0)]
    [InlineData("Middleton", 1)]
    [InlineData("Middleton", 800)]
    public async Task CompleteOrder_WhenCalledWithMiddleton_ReturnsExpectedAdvertImageUrl(string selectedDistrict, decimal orderAmount)
    {
        //Arrange
        var sut = new OrderController();
        var order = new Order
        {
            District = selectedDistrict,
            Total = orderAmount
        };

        //Act
        var completedOrder = await sut.CompletedOrder(order);

        //Assert
        completedOrder.Advert.ImageUrl.Should().Be("https://via.placeholder.com/150/1fe46f");
    }
}