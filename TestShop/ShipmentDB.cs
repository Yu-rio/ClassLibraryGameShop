using ClassLibraryGameShop;
using LinqToDB;
using LinqToDB.DataProvider.SqlServer;

namespace TestShop
{
    public class ShipmentDB
    {
        private const string CONNECTION_STRING = @"Server=DESKTOP-4DJEC1V\MSSQLSERVER01;DataBase=GameShop;Trusted_Connection=True;";
        public int Create(string shipmentId, DateTime dateAndTime, float? sum, string warehouseId, string supplierId, string transactionId)
        {
            using (var db = SqlServerTools.CreateDataConnection(CONNECTION_STRING))
            {
                var warehhouseDb = new WarehouseDB().GetById(warehouseId);
                var supplierDb = new SupplierDB().GetById(supplierId);
                if (GetById(shipmentId) != null || warehhouseDb == null || supplierDb == null)
                    return 0;
                else
                    return db.GetTable<Shipment>()
                             .Value(s => s.ShipmentId, shipmentId)
                             .Value(s => s.DateAndTime, dateAndTime)
                             .Value(s => s.Sum, sum)
                             .Value(s => s.WarehouseId, warehouseId)
                             .Value(s => s.SupplierId, supplierId)
                             .Value(s => s.TransactionId, transactionId)
                             .Insert();
            }
        }

        public List<Shipment> Read()
        {
            using (var db = SqlServerTools.CreateDataConnection(CONNECTION_STRING))
            {
                return db.GetTable<Shipment>().LoadWith(lw => lw.Warehouse).LoadWith(lw => lw.Supplier).ToList();
            }
        }

        public Shipment GetById(string shipmentId)
        {
            using (var db = SqlServerTools.CreateDataConnection(CONNECTION_STRING))
            {
                return db.GetTable<Shipment>()
                         .Where(s => s.ShipmentId == shipmentId)
                         .FirstOrDefault();
            }
        }

       public Shipment GetByTransactionId(string transactionId)
        {
            using (var db = SqlServerTools.CreateDataConnection(CONNECTION_STRING))
            {
                return db.GetTable<Shipment>()
                         .Where(s => s.TransactionId == transactionId)
                         .FirstOrDefault();
            }
        }
        public int Update(string shipmentId, DateTime dateAndTime, float? sum, string warehouseId, string supplierId, string transactionId)
        {
            using (var db = SqlServerTools.CreateDataConnection(CONNECTION_STRING))
            {
                var warehhouseDb = new WarehouseDB().GetById(warehouseId);
                var supplierDb = new SupplierDB().GetById(supplierId);
                if (warehhouseDb == null || supplierDb == null)
                    return 0;
                else
                    return db.GetTable<Shipment>()
                         .Where(s => s.ShipmentId == shipmentId)
                         .Set(s => s.DateAndTime, dateAndTime)
                         .Set(s => s.Sum, sum)
                         .Set(s => s.WarehouseId, warehouseId)
                         .Set(s => s.SupplierId, supplierId)
                         .Set(s => s.TransactionId, transactionId)
                         .Update();
            }
        }

        public int Delete(string shipmentId)
        {
            using (var db = SqlServerTools.CreateDataConnection(CONNECTION_STRING))
            {
                return db.GetTable<Shipment>()
                         .Where(s => s.ShipmentId == shipmentId)
                         .Delete();
            }
        }
    }
}
