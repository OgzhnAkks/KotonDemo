using EFDataAccessLibrary.DataAccess;
using EFDataAccessLibrary.ContractServices;
using Microsoft.AspNetCore.Mvc;
using System.Text.Json;
using EFDataAccessLibrary.Models;

namespace DemoWebAPI.Controllers
{
    [ApiController]
    [Route("[Controller]")]
    public class CustomerController : Controller
    {

        private readonly OrderContext _dbOrderContext;
        private ICustomerSevice _customerService;

        public CustomerController(OrderContext dbOrderContext)

        {
            _dbOrderContext = dbOrderContext;
            _customerService = new CustomerService(dbOrderContext);
        }


        [HttpGet(Name = "GetCustomers")]
        public async Task<IEnumerable<Customer>> Get()
        {
            return await _customerService.GetAllCustomers();
        }


        [HttpGet("{id}", Name = "GetCustomer")]
        public async Task<Customer> Get(int id)
        {
            return await _customerService.GetSingleCustomer(id);
        }


        [HttpPut("{id}", Name = "UpdateCustomer")]
        public void Update([FromBody] Customer customer,int id)
        {
            _customerService.UpdateCustomer(customer, id);
        }
    }
}
