using LinqToDB;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestShopDB
{
    private readonly IDataContext _dataContext;

    public ProductRepository(IDataContext dataContext)
    {
        _dataContext = dataContext;
    }

    public List<Product> GetAll()
    {
        return _dataContext.GetTable<Product>().ToList();
    }

    public Product GetById(string productId)
    {
        return _dataContext.GetTable<Product>().FirstOrDefault(p => p.ProductId == productId);
    }

    public void Insert(Product product)
    {
        _dataContext.Insert(product);
    }

    public void Update(Product product)
    {
        _dataContext.Update(product);
    }

    public void Delete(Product product)
    {
        _dataContext.Delete(product);
    }
}
