﻿using ClassLibraryGameShop;
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
        private const string CONNECTION_STRING = @"Server=DESKTOP-4DJEC1V\MSSQLSERVER01;DataBase=GameShop;Trusted_Connection=True;TrustServerCertificate=True;";

        public int Create(float? price, int? quantity, string productId, string orderId)
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
                return db.GetTable<OrderItem>().LoadWith(lw => lw.Product).LoadWith(lw => lw.Order).ToList();
            }
        }

        public OrderItem GetOrderItemByProductIdAndOrderId(string productId, string orderId)
        {
            using (var db = SqlServerTools.CreateDataConnection(CONNECTION_STRING))
            {
                return db.GetTable<OrderItem>().LoadWith(lw => lw.Product).LoadWith(lw => lw.Order)
                         .Where(oi => oi.ProductId == productId && oi.OrderId == orderId)
                         .FirstOrDefault();
            }
        }
        public List<OrderItem> GetByOrderId(string orderId)
        {
            using (var db = SqlServerTools.CreateDataConnection(CONNECTION_STRING))
            {
                return db.GetTable<OrderItem>().LoadWith(lw => lw.Product).LoadWith(lw => lw.Order)
                    .Where(oi => oi.OrderId == orderId).ToList();
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
