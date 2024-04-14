using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestShopDB
{
    private readonly IDataContext _dataContext;

    public ShipmentRepository(IDataContext dataContext)
    {
        _dataContext = dataContext;
    }

    public List<Shipment> GetAll()
    {
        return _dataContext.GetTable<Shipment>().ToList();
    }

    public Shipment GetById(string shipmentId)
    {
        return _dataContext.GetTable<Shipment>().FirstOrDefault(s => s.ShipmentId == shipmentId);
    }

    public void Insert(Shipment shipment)
    {
        _dataContext.Insert(shipment);
    }

    public void Update(Shipment shipment)
    {
        _dataContext.Update(shipment);
    }

    public void Delete(Shipment shipment)
    {
        _dataContext.Delete(shipment);
    }
}
