using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestShopDB
{
    private readonly IDataContext _dataContext;

    public TransactionRepository(IDataContext dataContext)
    {
        _dataContext = dataContext;
    }

    public List<Transaction> GetAll()
    {
        return _dataContext.GetTable<Transaction>().ToList();
    }

    public Transaction GetById(string transactionId)
    {
        return _dataContext.GetTable<Transaction>().FirstOrDefault(t => t.TransactionId == transactionId);
    }

    public void Insert(Transaction transaction)
    {
        _dataContext.Insert(transaction);
    }

    public void Update(Transaction transaction)
    {
        _dataContext.Update(transaction);
    }

    public void Delete(Transaction transaction)
    {
        _dataContext.Delete(transaction);
    }
}
