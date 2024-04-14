using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestShopDB
{
    private readonly IDataContext _dataContext;

    public OrderItemRepository(IDataContext dataContext)
    {
        _dataContext = dataContext;
    }

    public List<OrderItem> GetAll()
    {
        return _dataContext.GetTable<OrderItem>().ToList();
    }

    public OrderItem GetByCompositeKey(string productId, string orderId)
    {
        return _dataContext.GetTable<OrderItem>().FirstOrDefault(oi => oi.ProductId == productId && oi.OrderId == orderId);
    }

    public void Insert(OrderItem orderItem)
    {
        _dataContext.Insert(orderItem);
    }

    public void Update(OrderItem orderItem)
    {
        _dataContext.Update(orderItem);
    }

    public void Delete(OrderItem orderItem)
    {
        _dataContext.Delete(orderItem);
    }
}
