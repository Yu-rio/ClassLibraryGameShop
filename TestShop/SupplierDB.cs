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
    public class SupplierDB
    {
        private const string CONNECTION_STRING = @"Server=DESKTOP-4DJEC1V\MSSQLSERVER01;DataBase=GameShop;Trusted_Connection=True;";
        public int Create(string supplierId, string supplierName, string phoneNumber, string address)
        {
            using (var db = SqlServerTools.CreateDataConnection(CONNECTION_STRING))
            {
                if (GetById(supplierId) != null)
                    return 0; 
                else
                    return db.GetTable<Supplier>()
                             .Value(s => s.SupplierId, supplierId)
                             .Value(s => s.SupplierName, supplierName)
                             .Value(s => s.PhoneNumber, phoneNumber)
                             .Value(s => s.Address, address)
                             .Insert();
            }
        }

        public List<Supplier> Read()
        {
            using (var db = SqlServerTools.CreateDataConnection(CONNECTION_STRING))
            {
                return db.GetTable<Supplier>().ToList();
            }
        }

        public Supplier GetById(string supplierId)
        {
            using (var db = SqlServerTools.CreateDataConnection(CONNECTION_STRING))
            {
                return db.GetTable<Supplier>()
                         .Where(s => s.SupplierId == supplierId)
                         .FirstOrDefault();
            }
        }

        public int Update(string supplierId, string supplierName, string phoneNumber, string address)
        {
            using (var db = SqlServerTools.CreateDataConnection(CONNECTION_STRING))
            {
                return db.GetTable<Supplier>()
                         .Where(s => s.SupplierId == supplierId)
                         .Set(s => s.SupplierName, supplierName)
                         .Set(s => s.PhoneNumber, phoneNumber)
                         .Set(s => s.Address, address)
                         .Update();
            }
        }

        public int Delete(string supplierId)
        {
            using (var db = SqlServerTools.CreateDataConnection(CONNECTION_STRING))
            {
                return db.GetTable<Supplier>()
                         .Where(s => s.SupplierId == supplierId)
                         .Delete();
            }
        }
    }
}
