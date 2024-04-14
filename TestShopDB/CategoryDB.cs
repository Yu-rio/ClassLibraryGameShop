using LinqToDB;
using LinqToDB.DataProvider.SqlServer;
using ClassLibraryGameShop;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestShopDB
{
    private readonly IDataContext _dataContext;

    public CategoryRepository(IDataContext dataContext)
    {
        _dataContext = dataContext;
    }

    public List<Category> GetAll()
    {
        return _dataContext.GetTable<Category>().ToList();
    }

    public Category GetById(string categoryId)
    {
        return _dataContext.GetTable<Category>().FirstOrDefault(c => c.CategoryId == categoryId);
    }

    public void Insert(Category category)
    {
        _dataContext.Insert(category);
    }

    public void Update(Category category)
    {
        _dataContext.Update(category);
    }

    public void Delete(Category category)
    {
        _dataContext.Delete(category);
    }
}
