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
    public class WarehouseDB
    {
        private const string CONNECTION_STRING = @"Server=DESKTOP-4DJEC1V\MSSQLSERVER01;DataBase=GameShop;Trusted_Connection=True;";
        public int Create(string warehouseId, string address, string phoneNumber)
        {
            using (var db = SqlServerTools.CreateDataConnection(CONNECTION_STRING))
            {
                if (GetById(warehouseId) != null)
                    return 0; 
                else
                    return db.GetTable<Warehouse>()
                             .Value(w => w.WarehouseId, warehouseId)
                             .Value(w => w.Address, address)
                             .Value(w => w.PhoneNumber, phoneNumber)
                             .Insert();
            }
        }

        public List<Warehouse> Read()
        {
            using (var db = SqlServerTools.CreateDataConnection(CONNECTION_STRING))
            {
                return db.GetTable<Warehouse>().ToList();
            }
        }

        public  Warehouse GetById(string warehouseId)
        {
            using (var db = SqlServerTools.CreateDataConnection(CONNECTION_STRING))
            {
                return db.GetTable<Warehouse>()
                         .Where(w => w.WarehouseId == warehouseId)
                         .FirstOrDefault();
            }
        }

        public int Update(string warehouseId, string address, string phoneNumber)
        {
            using (var db = SqlServerTools.CreateDataConnection(CONNECTION_STRING))
            {
                return db.GetTable<Warehouse>()
                         .Where(w => w.WarehouseId == warehouseId)
                         .Set(w => w.Address, address)
                         .Set(w => w.PhoneNumber, phoneNumber)
                         .Update();
            }
        }

        public int Delete(string warehouseId)
        {
            using (var db = SqlServerTools.CreateDataConnection(CONNECTION_STRING))
            {
                return db.GetTable<Warehouse>()
                         .Where(w => w.WarehouseId == warehouseId)
                         .Delete();
            }
        }
    }
}
