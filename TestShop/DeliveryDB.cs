using ClassLibraryGameShop;
using LinqToDB;
using LinqToDB.DataProvider.SqlServer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestShop
{
    public class DeliveryDB
    {
        private const string CONNECTION_STRING = @"Server=DESKTOP-4DJEC1V\MSSQLSERVER01;DataBase=GameShop;Trusted_Connection=True;TrustServerCertificate=True;";
        public int Create(string deliveryId, string name, string phoneNumber, string status)
        {
            using (var db = SqlServerTools.CreateDataConnection(CONNECTION_STRING))
            {
                if (GetById(deliveryId) != null)
                    return 0; 
                else
                    return db.GetTable<Delivery>()
                             .Value(d => d.DeliveryId, deliveryId)
                             .Value(d => d.Name, name)
                             .Value(d => d.PhoneNumber, phoneNumber)
                             .Value(d => d.Status, status)
                             .Insert();
            }
        }

        public List<Delivery> Read()
        {
            using (var db = SqlServerTools.CreateDataConnection(CONNECTION_STRING))
            {
                return db.GetTable<Delivery>().ToList();
            }
        }

        public Delivery GetById(string deliveryId)
        {
            using (var db = SqlServerTools.CreateDataConnection(CONNECTION_STRING))
            {
                return db.GetTable<Delivery>()
                         .Where(d => d.DeliveryId == deliveryId)
                         .FirstOrDefault();
            }
        }

        public int Update(string deliveryId, string name, string phoneNumber, string status)
        {
            using (var db = SqlServerTools.CreateDataConnection(CONNECTION_STRING))
            {
                return db.GetTable<Delivery>()
                         .Where(d => d.DeliveryId == deliveryId)
                         .Set(d => d.Name, name)
                         .Set(d => d.PhoneNumber, phoneNumber)
                         .Set(d => d.Status, status)
                         .Update();
            }
        }

        public int Delete(string deliveryId)
        {
            using (var db = SqlServerTools.CreateDataConnection(CONNECTION_STRING))
            {
                return db.GetTable<Delivery>()
                         .Where(d => d.DeliveryId == deliveryId)
                         .Delete();
            }
        }
    }
}
