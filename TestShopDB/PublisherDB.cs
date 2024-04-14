using LinqToDB;
using LinqToDB.Mapping;
using System;
using ClassLibraryGameShop;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestShopDB
{
    private readonly IDataContext _dataContext;

    public PublisherRepository(IDataContext dataContext)
    {
        _dataContext = dataContext;
    }

    public List<Publisher> GetAll()
    {
        return _dataContext.GetTable<Publisher>().ToList();
    }

    public Publisher GetById(string publisherId)
    {
        return _dataContext.GetTable<Publisher>().FirstOrDefault(p => p.PublisherId == publisherId);
    }

    public void Insert(Publisher publisher)
    {
        _dataContext.Insert(publisher);
    }

    public void Update(Publisher publisher)
    {
        _dataContext.Update(publisher);
    }

    public void Delete(Publisher publisher)
    {
        _dataContext.Delete(publisher);
    }
}
