using EFDataAccessLibrary.DataAccess;
using EFDataAccessLibrary.Models;
using Microsoft.EntityFrameworkCore;

namespace EFDataAccessLibrary.ContractServices
{
    public class CustomerService : ICustomerSevice
    {
        // Bu serviste bir log mekanizması kullanılmamıştır ve hatalar throw exception olarak handle edilmiştir.

        private readonly OrderContext _dbOrderContext;
        public CustomerService(OrderContext dbOrderContext)
        {
            _dbOrderContext = dbOrderContext;
        }

        public List<Customer> Customers { get; set; } = new List<Customer>();

        public void CreateCustomer(Customer customer)
        {
            _dbOrderContext.Customer.Add(customer);
            _dbOrderContext.SaveChanges();
        }

        public void CreateCustomer(List<Customer> customerList)
        {
            _dbOrderContext.Customer.AddRange(customerList);
            _dbOrderContext.SaveChanges();
        }

        public void DeleteCustomer(int? id)
        {
            var dbCustomer = _dbOrderContext.Customer.Find(id);

            if (dbCustomer == null)
            {
                throw new Exception($"The customer record with id :{id} that you want to delete could not be found.");
            }

            var dbCustomerAddress = dbCustomer.Addresses;

            // Deletes customer-related address information.
            foreach (var itemAddres in dbCustomerAddress)
            {
                _dbOrderContext.Addresses.Remove(itemAddres);
            }

            _dbOrderContext.Customer.Remove(dbCustomer);
        }

        public async Task<Customer> GetSingleCustomer(int id)
        {
            var dbCustomer = await _dbOrderContext.Customer.FindAsync(id);

            if (dbCustomer == null)
            {
                throw new Exception($"The customer record with the id:{id} you are looking for was not found.");
            }

            return dbCustomer;
        }

        public async Task<IEnumerable<Customer>> GetAllCustomers()
        {
            return await _dbOrderContext.Customer.ToListAsync();
        }

        public async Task<Customer> UpdateCustomer(Customer customer, int? id)
        {
            var dbCustomerObject = await _dbOrderContext.Customer.FindAsync(id);

            if (dbCustomerObject == null)
            {
                throw new Exception($"The record with the id:{id} you want to update could not be found ");
            }
            dbCustomerObject.Name = customer.Name;
            dbCustomerObject.FirstName = customer.FirstName;
            dbCustomerObject.Addresses = customer.Addresses;

            return dbCustomerObject;
        }
    }
}
