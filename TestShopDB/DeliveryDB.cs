using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestShopDB
{
    private readonly IDataContext _dataContext;

    public DeliveryRepository(IDataContext dataContext)
    {
        _dataContext = dataContext;
    }

    public List<Delivery> GetAll()
    {
        return _dataContext.GetTable<Delivery>().ToList();
    }

    public Delivery GetById(string deliveryId)
    {
        return _dataContext.GetTable<Delivery>().FirstOrDefault(d => d.DeliveryId == deliveryId);
    }

    public void Insert(Delivery delivery)
    {
        _dataContext.Insert(delivery);
    }

    public void Update(Delivery delivery)
    {
        _dataContext.Update(delivery);
    }

    public void Delete(Delivery delivery)
    {
        _dataContext.Delete(delivery);
    }
}
