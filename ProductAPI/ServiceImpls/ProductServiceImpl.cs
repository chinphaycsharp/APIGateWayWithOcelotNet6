using Microsoft.EntityFrameworkCore;
using ProductAPI.Data;
using ProductAPI.Models;
using ProductAPI.Services;

namespace ProductAPI.ServiceImpls
{
    public class ProductServiceImpl :IProductService
    {
        private readonly DbGateWayContext _dbContext;

    public ProductServiceImpl(DbGateWayContext dbContext)
    {
        _dbContext = dbContext;
    }
    public IEnumerable<Product> GetProductList()
    {
        return _dbContext.Products.ToList();
    }
    public Product GetProductById(int id)
    {
        return _dbContext.Products.Where(x => x.ProductId == id).FirstOrDefault();
    }

    public Product AddProduct(Product product)
    {
        var result = _dbContext.Products.Add(product);
        _dbContext.SaveChanges();
        return result.Entity;
    }

    public Product UpdateProduct(Product product)
    {
        var result = _dbContext.Products.Update(product);
        _dbContext.SaveChanges();
        return result.Entity;
    }
    public bool DeleteProduct(int Id)
    {
        var filteredData = _dbContext.Products.Where(x => x.ProductId == Id).FirstOrDefault();
        var result = _dbContext.Remove(filteredData);
        _dbContext.SaveChanges();
        return result != null ? true : false;
    }
}
}
