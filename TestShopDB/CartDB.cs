using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestShopDB
{
    private readonly IDataContext _dataContext;

    public CartRepository(IDataContext dataContext)
    {
        _dataContext = dataContext;
    }

    public List<Cart> GetAll()
    {
        return _dataContext.GetTable<Cart>().ToList();
    }

    public Cart GetById(string cartId)
    {
        return _dataContext.GetTable<Cart>().FirstOrDefault(c => c.CartId == cartId);
    }

    public void Insert(Cart cart)
    {
        _dataContext.Insert(cart);
    }

    public void Update(Cart cart)
    {
        _dataContext.Update(cart);
    }

    public void Delete(Cart cart)
    {
        _dataContext.Delete(cart);
    }
}
