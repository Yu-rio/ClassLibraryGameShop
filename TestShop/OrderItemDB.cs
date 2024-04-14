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
    public class OrderItemDB
    {
        private const string CONNECTION_STRING = @"Server=DESKTOP-4DJEC1V\MSSQLSERVER01;DataBase=GameShop;Trusted_Connection=True;";

        public int CreateOrderItem(float? price, int? quantity, string productId, string orderId)
        {
            using (var db = SqlServerTools.CreateDataConnection(CONNECTION_STRING))
            {
                if (GetOrderItemByProductIdAndOrderId(productId, orderId) != null)
                    return 0; 
                else
                    return db.GetTable<OrderItem>()
                             .Value(oi => oi.Price, price)
                             .Value(oi => oi.Quantity, quantity)
                             .Value(oi => oi.ProductId, productId)
                             .Value(oi => oi.OrderId, orderId)
                             .Insert();
            }
        }

        public List<OrderItem> Read()
        {
            using (var db = SqlServerTools.CreateDataConnection(CONNECTION_STRING))
            {
                return db.GetTable<OrderItem>().ToList();
            }
        }

        public OrderItem GetOrderItemByProductIdAndOrderId(string productId, string orderId)
        {
            using (var db = SqlServerTools.CreateDataConnection(CONNECTION_STRING))
            {
                return db.GetTable<OrderItem>()
                         .Where(oi => oi.ProductId == productId && oi.OrderId == orderId)
                         .FirstOrDefault();
            }
        }

        public int Update(float? price, int? quantity, string productId, string orderId)
        {
            using (var db = SqlServerTools.CreateDataConnection(CONNECTION_STRING))
            {
                return db.GetTable<OrderItem>()
                         .Where(oi => oi.ProductId == productId && oi.OrderId == orderId)
                         .Set(oi => oi.Price, price)
                         .Set(oi => oi.Quantity, quantity)
                         .Update();
            }
        }

        public int Delete(string productId, string orderId)
        {
            using (var db = SqlServerTools.CreateDataConnection(CONNECTION_STRING))
            {
                return db.GetTable<OrderItem>()
                         .Where(oi => oi.ProductId == productId && oi.OrderId == orderId)
                         .Delete();
            }
        }
    }
}
