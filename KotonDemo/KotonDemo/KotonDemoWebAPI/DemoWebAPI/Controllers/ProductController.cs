using EFDataAccessLibrary.DataAccess;
using EFDataAccessLibrary.Models;
using Microsoft.AspNetCore.Mvc;
using System.Text.Json;

namespace DemoWebAPI.Controllers
{
    [ApiController]
    [Route("[Controller]")]
    public class ProductController : Controller
    {
        private readonly OrderContext _dbContext;
        public ProductController(OrderContext dbContext)
        {
            _dbContext = dbContext;
        }

        // Bu post işlemi ve ProductController json üzerindeki ürünleri DB ' ye kayıt etmek için yapıldı
        [HttpPost(Name ="ProductPostDBJsonFile")]
        public void Post()
        {
            if(!_dbContext.Products.Any())
            {
                string file = System.IO.File.ReadAllText("ProductMockDataList.json");
                var productJsonSerializer = JsonSerializer.Deserialize<List<Product>>(file);
                _dbContext.Products.AddRange(productJsonSerializer);
                _dbContext.SaveChanges();
            }
        }

    }
}
