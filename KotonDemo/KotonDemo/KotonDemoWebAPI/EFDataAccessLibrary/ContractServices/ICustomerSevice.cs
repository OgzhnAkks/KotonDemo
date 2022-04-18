using EFDataAccessLibrary.Models;

namespace EFDataAccessLibrary.ContractServices
{
    public interface ICustomerSevice
    {
        public List<Customer> Customers { get; set; }

        Task<IEnumerable<Customer>> GetAllCustomers();

        Task<Customer> GetSingleCustomer(int id);

        void CreateCustomer(Customer customer);

        void CreateCustomer(List<Customer> customerList);

        Task<Customer> UpdateCustomer(Customer customer, int? id);

        void DeleteCustomer(int? id);
    }
}
