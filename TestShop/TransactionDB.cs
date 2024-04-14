using ClassLibraryGameShop;
using LinqToDB;
using LinqToDB.DataProvider.SqlServer;
using TestShop;

namespace TestShop
{
    public class TransactionDB
    {
        private const string CONNECTION_STRING = @"Server=DESKTOP-4DJEC1V\MSSQLSERVER01;DataBase=GameShop;Trusted_Connection=True;";
        public int Create(string transactionId, string supplierCustomerId)
        {
            using (var db = SqlServerTools.CreateDataConnection(CONNECTION_STRING))
            {
                var customerDb = new CustomerDB().GetById(supplierCustomerId);
                var supplierDb = new SupplierDB().GetById(supplierCustomerId);
                if (GetById(transactionId) != null || customerDb == null)
                {
                    if (GetById(transactionId) != null || supplierDb == null)
                        return 0;
                    else
                        return db.GetTable<Transaction>()
                            .Value(t => t.TransactionId, transactionId)
                            .Value(t => t.SupplierId, supplierCustomerId)
                            .Insert();
                }
                else
                    return db.GetTable<Transaction>()
                             .Value(t => t.TransactionId, transactionId)
                             .Value(t => t.CustomerId, supplierCustomerId)
                             .Insert();
            }
        }

        public List<Transaction> Read()
        {
            using (var db = SqlServerTools.CreateDataConnection(CONNECTION_STRING))
            {
                return db.GetTable<Transaction>().ToList();
            }
        }

        public Transaction GetById(string transactionId)
        {
            using (var db = SqlServerTools.CreateDataConnection(CONNECTION_STRING))
            {
                return db.GetTable<Transaction>()
                         .Where(t => t.TransactionId == transactionId)
                         .FirstOrDefault();
            }
        }

        public int Update(string transactionId, string customerId, string supplierId)
        {
            using (var db = SqlServerTools.CreateDataConnection(CONNECTION_STRING))
            {

                return db.GetTable<Transaction>()
                         .Where(t => t.TransactionId == transactionId)
                         .Set(t => t.CustomerId, customerId)
                         .Set(t => t.SupplierId, supplierId)
                         .Update();
            }
        }

        public int Delete(string transactionId)
        {
            using (var db = SqlServerTools.CreateDataConnection(CONNECTION_STRING))
            {
                return db.GetTable<Transaction>()
                         .Where(t => t.TransactionId == transactionId)
                         .Delete();
            }
        }
    }
}
