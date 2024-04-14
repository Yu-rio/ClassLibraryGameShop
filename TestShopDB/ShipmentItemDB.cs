using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestShopDB
{
    private readonly IDataContext _dataContext;

    public ShipmentItemRepository(IDataContext dataContext)
    {
        _dataContext = dataContext;
    }

    public List<ShipmentItem> GetAll()
    {
        return _dataContext.GetTable<ShipmentItem>().ToList();
    }

    public ShipmentItem GetByCompositeKey(string shipmentId, string productId)
    {
        return _dataContext.GetTable<ShipmentItem>().FirstOrDefault(si => si.ShipmentId == shipmentId && si.ProductId == productId);
    }

    public void Insert(ShipmentItem shipmentItem)
    {
        _dataContext.Insert(shipmentItem);
    }

    public void Update(ShipmentItem shipmentItem)
    {
        _dataContext.Update(shipmentItem);
    }

    public void Delete(ShipmentItem shipmentItem)
    {
        _dataContext.Delete(shipmentItem);
    }
}
