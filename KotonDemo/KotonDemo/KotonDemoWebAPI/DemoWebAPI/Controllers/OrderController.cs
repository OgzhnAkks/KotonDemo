using Microsoft.AspNetCore.Mvc;
using EFDataAccessLibrary.DataAccess;
using EFDataAccessLibrary.ContractServices;
using EFDataAccessLibrary.Models;

namespace DemoWebAPI.Controllers
{
    [ApiController]
    [Route("[Controller]")]
    public class OrderController : Controller
    {
        private readonly OrderContext _dbContext;
        private IOrderService _orderService;

        public OrderController(OrderContext dbContext)
        {
            _dbContext = dbContext;
            _orderService = new OrderService(dbContext);
        }

        [HttpGet(Name = "GetOrders")]
        public IEnumerable<Order> Get()
        {
            return _orderService.GetAllOrders();
        }

        [HttpPost(Name = "CreateOrder")]
        public void Post([FromBody] Order order)
        {
            _orderService.CreateOrder(order);
        }
    }
}
