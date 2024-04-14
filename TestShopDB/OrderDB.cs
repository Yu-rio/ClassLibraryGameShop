using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestShopDB
{
    private readonly IDataContext _dataContext;

    public OrderRepository(IDataContext dataContext)
    {
        _dataContext = dataContext;
    }

    public List<Order> GetAll()
    {
        return _dataContext.GetTable<Order>().ToList();
    }

    public Order GetById(string orderId)
    {
        return _dataContext.GetTable<Order>().FirstOrDefault(o => o.OrderId == orderId);
    }

    public void Insert(Order order)
    {
        _dataContext.Insert(order);
    }

    public void Update(Order order)
    {
        _dataContext.Update(order);
    }

    public void Delete(Order order)
    {
        _dataContext.Delete(order);
    }
}
