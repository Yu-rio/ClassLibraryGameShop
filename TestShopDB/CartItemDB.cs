using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestShopDB
{
    private readonly IDataContext _dataContext;

    public CartItemRepository(IDataContext dataContext)
    {
        _dataContext = dataContext;
    }

    public List<CartItem> GetAll()
    {
        return _dataContext.GetTable<CartItem>().ToList();
    }

    public CartItem GetByCompositeKey(string productId, string cartId)
    {
        return _dataContext.GetTable<CartItem>().FirstOrDefault(ci => ci.ProductId == productId && ci.CartId == cartId);
    }

    public void Insert(CartItem cartItem)
    {
        _dataContext.Insert(cartItem);
    }

    public void Update(CartItem cartItem)
    {
        _dataContext.Update(cartItem);
    }

    public void Delete(CartItem cartItem)
    {
        _dataContext.Delete(cartItem);
    }
}
