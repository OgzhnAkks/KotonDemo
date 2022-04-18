using EFDataAccessLibrary.Models;

namespace EFDataAccessLibrary.ContractServices
{
    public interface IOrderService
    {
        void CreateOrder(List<Order> orderList);

        void CreateOrder(Order orderList);

        IEnumerable<Order> GetAllOrders();

    }
}