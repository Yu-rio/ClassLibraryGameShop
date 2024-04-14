using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestShopDB
{
    private readonly IDataContext _dataContext;

    public CustomerRepository(IDataContext dataContext)
    {
        _dataContext = dataContext;
    }

    public List<Customer> GetAll()
    {
        return _dataContext.GetTable<Customer>().ToList();
    }

    public Customer GetById(string customerId)
    {
        return _dataContext.GetTable<Customer>().FirstOrDefault(c => c.CustomerId == customerId);
    }

    public void Insert(Customer customer)
    {
        _dataContext.Insert(customer);
    }

    public void Update(Customer customer)
    {
        _dataContext.Update(customer);
    }

    public void Delete(Customer customer)
    {
        _dataContext.Delete(customer);
    }
}
