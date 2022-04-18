using EFDataAccessLibrary.Models;
using EFDataAccessLibrary.DataAccess;

namespace EFDataAccessLibrary.ContractServices;

public class ProductService
{
    // Bu serviste bir log mekanizması kullanılmamıştır ve hatalar throw exception olarak handle edilmiştir.

    private readonly OrderContext _dbOrderContext;
    public ProductService(OrderContext orderContext)
    {
        _dbOrderContext = orderContext;
    }

    public void CreateOrder(Product product)
    {
        _dbOrderContext.Products.Add(product);
        _dbOrderContext.SaveChanges();
    }

    public void CreateOrder(List<Product> product)
    {
        _dbOrderContext.Products.AddRange(product);
        _dbOrderContext.SaveChanges();
    }

    public Product GetSingleProduct(int id)
    {
        var dbProduct = _dbOrderContext.Products.Find(id);

        if (dbProduct == null)
        {
            throw new Exception($"The product record with the id:{id} you are looking for was not found.");
        }

        return dbProduct;
    }

    public void ProductStokUpdater(int productId, int quantity)
    {
        var resulttProduct = _dbOrderContext.Products.Find(productId);

        if (resulttProduct != null)
        {
            resulttProduct.Stock -= quantity;

            _dbOrderContext.Products.Update(resulttProduct);
            _dbOrderContext.SaveChanges();
        }
    }

    public bool StockControl(int productId, int quantity)
    {
        var resultProduct = _dbOrderContext.Products.Find(productId);

        if (resultProduct == null)
        {
            throw new Exception($"The product record with the id:{productId} you are looking for was not found.");
        }

        return resultProduct.Stock >= quantity;
    }

    public decimal GetProductPrice(int productId)
    {
        var resulttProduct = _dbOrderContext.Products.Find(productId);

        // Id check is done until it comes to this method, it will not be null
        return resulttProduct.Price;
    }
}
