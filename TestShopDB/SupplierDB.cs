using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestShopDB
{
    private readonly IDataContext _dataContext;

    public SupplierRepository(IDataContext dataContext)
    {
        _dataContext = dataContext;
    }

    public List<Supplier> GetAll()
    {
        return _dataContext.GetTable<Supplier>().ToList();
    }

    public Supplier GetById(string supplierId)
    {
        return _dataContext.GetTable<Supplier>().FirstOrDefault(s => s.SupplierId == supplierId);
    }

    public void Insert(Supplier supplier)
    {
        _dataContext.Insert(supplier);
    }

    public void Update(Supplier supplier)
    {
        _dataContext.Update(supplier);
    }

    public void Delete(Supplier supplier)
    {
        _dataContext.Delete(supplier);
    }
}
