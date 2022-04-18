using EFDataAccessLibrary.DataAccess;
using EFDataAccessLibrary.Models;

namespace EFDataAccessLibrary.ContractServices;

public class OrderService : IOrderService
{
    // Bu serviste bir log mekanizması kullanılmamıştır ve hatalar throw exception olarak handle edilmiştir.

    private const string _statusConfirmation = "Approved";

    private readonly OrderContext _dbOrderContext;
    private readonly ProductService _productManager;
    public OrderService(OrderContext dbOrderContext)
    {
        _dbOrderContext = dbOrderContext;
        _productManager = new ProductService(dbOrderContext);

    }

    public IEnumerable<Order> GetAllOrders()
    {
        return _dbOrderContext.Orders;
    }

    public Order GetSingleOrder(int id)
    {
        var resultOrder = _dbOrderContext.Orders.Find(id);
        if (resultOrder == null)
        {
            throw new Exception($"The order record with the id:{id} you are looking for was not found.");
        }

        return resultOrder;
    }

    public void CreateOrder(List<Order> orderList)
    {
        foreach (var order in orderList)
        {
            _productManager.ProductStokUpdater(order.ProductId, order.Quantity);

            if (_productManager.StockControl(order.ProductId, order.Quantity))
            {
                order.Status = _statusConfirmation;

                order.Biling.ItemPrice = _productManager.GetProductPrice(order.ProductId);

                order.Biling.TotalCost = TotalCostCalculator(order.Biling.Taxes, order.Biling.Discounts, order.Biling.ItemPrice);

                _dbOrderContext.Orders.Add(order);
                _dbOrderContext.SaveChanges();
            }
            else
            {
                throw new Exception($"Your order could not be created. The product with {order.ProductId} is out of stock.");

            }

        }
    }

    // Swagger üzerinden tek bir sipariş kaydı yaratmak için yapıldı.
    public void CreateOrder(Order order)
    {

        if (_productManager.StockControl(order.ProductId, order.Quantity))
        {
            order.Status = _statusConfirmation;
            order.Biling.ItemPrice = _productManager.GetProductPrice(order.ProductId);
            order.Biling.TotalCost = TotalCostCalculator(order.Biling.Taxes, order.Biling.Discounts, order.Biling.ItemPrice);

            // Updates product stock after stock is checked.
            _productManager.ProductStokUpdater(order.ProductId, order.Quantity);

            _dbOrderContext.Orders.Add(order);
            _dbOrderContext.SaveChanges();
        }
        else
        {
            throw new Exception($"Your order could not be created. The product with {order.ProductId} is out of stock.");
        }

    }

    // This method can be split or called from different services.
    private decimal TotalCostCalculator(List<Taxe> taxes, List<Discount> discounts, decimal productPrice)
    {
        decimal resultItemPrice = 0;

        foreach (var itemTaxe in taxes)
        {
            resultItemPrice = productPrice + (productPrice * itemTaxe.TaxeRate / 100);
        }

        foreach (var itemDiscount in discounts)
        {
            resultItemPrice = resultItemPrice - (resultItemPrice * itemDiscount.DiscountRate / 100);
        }

        return resultItemPrice;
    }



}
