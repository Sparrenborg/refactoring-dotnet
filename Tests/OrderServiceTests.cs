using FluentAssertions;
using Refactoring.Web.Controllers;
using Refactoring.Web.DomainModels;
using Refactoring.Web.Services;

namespace Tests;

public class OrderServiceTests
{
    [Theory]
    [InlineData("Cambridge", 10)]
    public async Task CompleteOrder_WhenCalledWithCambridge_ReturnsExpectedDistrict(string selectedDistrict, decimal orderAmount)
    {
      

    }
}