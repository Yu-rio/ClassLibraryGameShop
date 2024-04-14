using ClassLibraryGameShop;
using LinqToDB;
using LinqToDB.DataProvider.SqlServer;

namespace TestShop
{
    public class OrderDB
    {
        private const string CONNECTION_STRING = @"Server=DESKTOP-4DJEC1V\MSSQLSERVER01;DataBase=GameShop;Trusted_Connection=True;";
        public int Create(string orderId, DateTime orderDate, float sum, string status, string deliveryId, string customerId, string transactionId)
        {
            using (var db = SqlServerTools.CreateDataConnection(CONNECTION_STRING))
            {
                var customerDb = new CustomerDB().GetById(customerId);
                var transactionDb = new TransactionDB().GetById(transactionId);
                var deliveryDb = new DeliveryDB().GetById(deliveryId);
                if (GetById(orderId) != null || customerDb == null || transactionDb == null || deliveryDb == null)
                    return 0;
                else
                    return db.GetTable<Order>()
                             .Value(o => o.OrderId, orderId)
                             .Value(o => o.OrederDate, orderDate)
                             .Value(o => o.Sum, sum)
                             .Value(o => o.Status, status)
                             .Value(o => o.DeliveryId, deliveryId)
                             .Value(o => o.CustomerId, customerId)
                             .Value(o => o.TransactionId, transactionId)
                             .Insert();
            }
        }

        public List<Order> Read()
        {
            using (var db = SqlServerTools.CreateDataConnection(CONNECTION_STRING))
            {
                return db.GetTable<Order>().ToList();
            }
        }

        public Order GetById(string orderId)
        {
            using (var db = SqlServerTools.CreateDataConnection(CONNECTION_STRING))
            {
                return db.GetTable<Order>()
                         .Where(o => o.OrderId == orderId)
                         .FirstOrDefault();
            }
        }

        public List<Order> GetByCustomerId(string customerId)
        {
            using (var db = SqlServerTools.CreateDataConnection(CONNECTION_STRING))
            {
                return db.GetTable<Order>()
                         .Where(o => o.CustomerId == customerId)
                         .ToList();
            }
        }

        public int Update(string orderId, DateTime orderDate, float sum, string status, string deliveryId, string customerId, string transactionId)
        {
            using (var db = SqlServerTools.CreateDataConnection(CONNECTION_STRING))
            {
                var customerDb = new CustomerDB().GetById(customerId);
                var transactionDb = new TransactionDB().GetById(transactionId);
                var deliveryDb = new DeliveryDB().GetById(deliveryId);
                if (customerDb == null || transactionDb == null || deliveryDb == null)
                    return 0;
                else
                    return db.GetTable<Order>()
                         .Where(o => o.OrderId == orderId)
                         .Set(o => o.OrederDate, orderDate)
                         .Set(o => o.Sum, sum)
                         .Set(o => o.Status, status)
                         .Set(o => o.DeliveryId, deliveryId)
                         .Set(o => o.CustomerId, customerId)
                         .Set(o => o.TransactionId, transactionId)
                         .Update();
            }
        }

        public int Delete(string orderId)
        {
            using (var db = SqlServerTools.CreateDataConnection(CONNECTION_STRING))
            {
                return db.GetTable<Order>()
                         .Where(o => o.OrderId == orderId)
                         .Delete();
            }
        }
    }
}
