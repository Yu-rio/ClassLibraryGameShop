using ClassLibraryGameShop;
using LinqToDB;
using LinqToDB.DataProvider.SqlServer;

namespace TestShop
{
    public class CustomerDB
    {
        private const string CONNECTION_STRING = @"Server=DESKTOP-4DJEC1V\MSSQLSERVER01;DataBase=GameShop;Trusted_Connection=True;";
        public int Create(string id, string firstName, string lastName, string patronymicName, string email, DateTime birthday, string address, string passwordHash)
        {
            using (var db = SqlServerTools.CreateDataConnection(CONNECTION_STRING))
            {

                if (GetById(id) != null)
                    return 0;
                else
                    return db.GetTable<Customer>()
                             .Value(c => c.CustomerId, id)
                             .Value(c => c.FirstName, firstName)
                             .Value(c => c.LastName, lastName)
                             .Value(c => c.PatronymicName, patronymicName)
                             .Value(c => c.Email, email)
                             .Value(c => c.Birthday, birthday)
                             .Value(c => c.Address, address)
                             .Value(c => c.PasswordHash, passwordHash)
                             .Insert();
            }
        }

        public List<Customer> Read()
        {
            using (var db = SqlServerTools.CreateDataConnection(CONNECTION_STRING))
            {
                return db.GetTable<Customer>().ToList();
            }
        }

        public Customer GetById(string id)
        {
            using (var db = SqlServerTools.CreateDataConnection(CONNECTION_STRING))
            {
                return db.GetTable<Customer>()
                         .Where(c => c.CustomerId == id)
                         .FirstOrDefault();
            }
        }

        public int Update(string id, string firstName, string lastName, string patronymicName, string email, DateTime birthday, string address, string passwordHash)
        {
            using (var db = SqlServerTools.CreateDataConnection(CONNECTION_STRING))
            {
                return db.GetTable<Customer>()
                         .Where(c => c.CustomerId == id)
                         .Set(c => c.FirstName, firstName)
                         .Set(c => c.LastName, lastName)
                         .Set(c => c.PatronymicName, patronymicName)
                         .Set(c => c.Email, email)
                         .Set(c => c.Birthday, birthday)
                         .Set(c => c.Address, address)
                         .Set(c => c.PasswordHash, passwordHash)
                         .Update();
            }
        }

        public int Delete(string id)
        {
            using (var db = SqlServerTools.CreateDataConnection(CONNECTION_STRING))
            {
                return db.GetTable<Customer>()
                         .Where(c => c.CustomerId == id)
                         .Delete();
            }
        }
    }
}
