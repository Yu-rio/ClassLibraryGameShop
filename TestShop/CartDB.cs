using ClassLibraryGameShop;
using LinqToDB;
using LinqToDB.DataProvider.SqlServer;

namespace TestShop
{
    public class CartBD
    {
        private const string CONNECTION_STRING = @"Server=DESKTOP-4DJEC1V\MSSQLSERVER01;DataBase=GameShop;Trusted_Connection=True;TrustServerCertificate=True;";
        public int Create(string id, DateTime createdAt, string customerId)
        {
            using (var db = SqlServerTools.CreateDataConnection(CONNECTION_STRING))
            {
                var customerdb = new CustomerDB().GetById(customerId);
                if (GetById(id) != null || customerdb == null)
                    return 0;
                else
                    return db.GetTable<Cart>()
                        .Value(c => c.CartId, id)
                        .Value(c => c.CreatedAt, createdAt)
                        .Value(c => c.UpdatedAt, createdAt)
                        .Value(c => c.CustomerId, customerId)
                        .Insert();
            }
        }

        public List<Cart> Read()
        {
            using (var db = SqlServerTools.CreateDataConnection(CONNECTION_STRING))
            {
                return db.GetTable<Cart>().LoadWith(lw => lw.Customer).ToList();
            }
        }

        public Cart GetById(string id)
        {
            using (var db = SqlServerTools.CreateDataConnection(CONNECTION_STRING))
            {
                return db.GetTable<Cart>()
                    .Where(c => c.CartId == id)
                    .FirstOrDefault();
            }
        }

        public int Update(string id, DateTime updatedAt, string customerId)
        {
            using (var db = SqlServerTools.CreateDataConnection(CONNECTION_STRING))
            {
                var customerdb = new CustomerDB().GetById(customerId);
                if (customerdb == null)
                    return 0;
                else
                    return db.GetTable<Cart>()
                    .Where(c => c.CartId == id)
                    .Set(c => c.UpdatedAt, updatedAt)
                    .Set(c => c.CustomerId, customerId)
                    .Update();
            }
        }

        public int Delete(string id)
        {
            using (var db = SqlServerTools.CreateDataConnection(CONNECTION_STRING))
            {
                return db.GetTable<Cart>()
                    .Where(c => c.CartId == id)
                    .Delete();
            }
        }
    }
}