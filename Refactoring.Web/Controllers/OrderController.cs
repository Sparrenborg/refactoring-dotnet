using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Refactoring.Web.DomainModels;
using Refactoring.Web.Services;

namespace Refactoring.Web.Controllers {
    public class OrderController : Controller {
        public IActionResult Index() {
            return View();
        }

        private readonly IOrderService _orderService;
        public OrderController(IOrderService orderService)
        {
            _orderService = orderService;
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
            await _orderService.ProcessOrder();
            var completedOrder = _orderService.GetOrder();
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