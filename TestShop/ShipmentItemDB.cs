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
    public class ShipmentItemDB
    {
        private const string CONNECTION_STRING = @"Server=DESKTOP-4DJEC1V\MSSQLSERVER01;DataBase=GameShop;Trusted_Connection=True;TrustServerCertificate=True;";
        public int Create(string shipmentId, string productId, int quantity, float? price)
        {
            using (var db = SqlServerTools.CreateDataConnection(CONNECTION_STRING))
            {
                if (GetShipmentItemByShipmentIdAndProductId(shipmentId, productId) != null)
                    return 0; 
                else
                    return db.GetTable<ShipmentItem>()
                             .Value(si => si.ShipmentId, shipmentId)
                             .Value(si => si.ProductId, productId)
                             .Value(si => si.Quantity, quantity)
                             .Value(si => si.Price, price)
                             .Insert();
            }
        }

        public List<ShipmentItem> Read()
        {
            using (var db = SqlServerTools.CreateDataConnection(CONNECTION_STRING))
            {
                return db.GetTable<ShipmentItem>().LoadWith(lw => lw.Product).LoadWith(lw => lw.Shipment).ToList();
            }
        }

        public ShipmentItem GetShipmentItemByShipmentIdAndProductId(string shipmentId, string productId)
        {
            using (var db = SqlServerTools.CreateDataConnection(CONNECTION_STRING))
            {
                return db.GetTable<ShipmentItem>().LoadWith(lw => lw.Product).LoadWith(lw => lw.Shipment)
                         .Where(si => si.ShipmentId == shipmentId && si.ProductId == productId)
                         .FirstOrDefault();
            }
        }

        public int Update(string shipmentId, string productId, int quantity, float? price)
        {
            using (var db = SqlServerTools.CreateDataConnection(CONNECTION_STRING))
            {
                return db.GetTable<ShipmentItem>()
                         .Where(si => si.ShipmentId == shipmentId && si.ProductId == productId)
                         .Set(si => si.Quantity, quantity)
                         .Set(si => si.Price, price)
                         .Update();
            }
        }

        public int Delete(string shipmentId, string productId)
        {
            using (var db = SqlServerTools.CreateDataConnection(CONNECTION_STRING))
            {
                return db.GetTable<ShipmentItem>()
                         .Where(si => si.ShipmentId == shipmentId && si.ProductId == productId)
                         .Delete();
            }
        }
    }
}
