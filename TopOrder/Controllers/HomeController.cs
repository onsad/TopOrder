using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using TopOrder.Models;
using TopOrder.Services;

namespace TopOrder.Controllers
{
    public class HomeController(IOrderService orderService, ILogger<HomeController> logger) : Controller
    {
        private readonly ILogger<HomeController> _logger = logger;

        public IActionResult Index(string searchString, string selectedOrderStatus)
        {
            ViewData["CurrentFilter"] = searchString;

            var vm = new OrderViewModel();
            vm.Dashboard = orderService.GetDashboard();

            if (string.IsNullOrEmpty(searchString) && string.IsNullOrEmpty(selectedOrderStatus))
            {
                vm.Orders = orderService.GetOrders().ToList();
            }
            else
            {
                var filters = new FilterInputData
                {
                    CustomerName = searchString,
                    StatusCode = selectedOrderStatus
                };
                vm.Orders = orderService.GetOrdersByFilters(filters).ToList();
            }

            return View(vm);
        }

        public IActionResult Privacy()
        {
            return View();
        }

        public IActionResult CreateOrder()
        {
            return View();
        }

        [HttpPost]
        public ActionResult CreateOrder(CreateOrderViewModel model)
        {
            if (ModelState.IsValid)
            {
                orderService.CreateNewOrder(model);
                return RedirectToAction("Index");
            }

            return View("CreateOrder", model);
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
