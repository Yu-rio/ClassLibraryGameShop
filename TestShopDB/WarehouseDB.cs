using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestShopDB
{
    private readonly IDataContext _dataContext;

    public WarehouseRepository(IDataContext dataContext)
    {
        _dataContext = dataContext;
    }

    public List<Warehouse> GetAll()
    {
        return _dataContext.GetTable<Warehouse>().ToList();
    }

    public Warehouse GetById(string warehouseId)
    {
        return _dataContext.GetTable<Warehouse>().FirstOrDefault(w => w.WarehouseId == warehouseId);
    }

    public void Insert(Warehouse warehouse)
    {
        _dataContext.Insert(warehouse);
    }

    public void Update(Warehouse warehouse)
    {
        _dataContext.Update(warehouse);
    }

    public void Delete(Warehouse warehouse)
    {
        _dataContext.Delete(warehouse);
    }
}
