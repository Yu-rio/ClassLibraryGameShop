using ClassLibraryGameShop;
using LinqToDB;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestShop
{
    public class DbNorthwind : LinqToDB.Data.DataConnection
    {
        public DbNorthwind() : base("Northwind") { }

        public ITable<Product> product => this.GetTable<Product>();
        public ITable<Category> category => this.GetTable<Category>();
        public ITable<Genre> genre => this.GetTable<Genre>();
        public ITable<Platform> platform => this.GetTable<Platform>();
        public ITable<Cart> cart => this.GetTable<Cart>();
        public ITable<CartItem> cartItem => this.GetTable<CartItem>();
        public ITable<Customer> customer => this.GetTable<Customer>();
        public ITable<Delivery> delivery => this.GetTable<Delivery>();
        public ITable<Order> order => this.GetTable<Order>();
        public ITable<OrderItem> orderItem => this.GetTable<OrderItem>();
        public ITable<Publisher> publisher => this.GetTable<Publisher>();
        public ITable<Shipment> shipment => this.GetTable<Shipment>();
        public ITable<ShipmentItem> shipmentItem => this.GetTable<ShipmentItem>();
        public ITable<Supplier> supplier => this.GetTable <Supplier>();
        public ITable<Warehouse> warehouse => this.GetTable<Warehouse>();
    }
}
