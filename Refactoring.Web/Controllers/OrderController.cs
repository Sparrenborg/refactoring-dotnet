using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Refactoring.Web.DomainModels;
using Refactoring.Web.Services;

namespace Refactoring.Web.Controllers {
    public class OrderController : Controller {
        public IActionResult Index() {
            return View();
        }
        
        [HttpPost]
        public async Task<IActionResult> SubmitOrder(string selectedDistrict, decimal orderAmount)
        {
            var order = CreateOrder(selectedDistrict, orderAmount);
            var completedOrder = await CompletedOrder(order);
            return View(completedOrder);
        }

        public async Task<Order> CompletedOrder(Order order)
        {
            var orderService = new OrderService(order);
            await orderService.ProcessOrder();
            var completedOrder = orderService.GetOrder();
            return completedOrder;
        }

        public Order CreateOrder(string selectedDistrict, decimal orderAmount)
        {
            var order = new Order
            {
                District = selectedDistrict,
                Total = orderAmount,
            };
            return order;
        }
    }
}