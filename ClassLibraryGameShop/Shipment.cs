using LinqToDB.Mapping;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassLibraryGameShop
{
    [Table("Shipment")]
    public class Shipment
    {
        [PrimaryKey, NotNull] public string ShipmentId { get; set; }

        [Column, NotNull] public DateTime DateAndTime { get; set; }

        [Column] public float? Sum { get; set; }

        [Column, NotNull] public string WarehouseId { get; set; }

        [Column, NotNull] public string SupplierId { get; set; }

        [Column, NotNull] public string TransactionId { get; set; }

        [Association(ThisKey = "WarehouseId", OtherKey = "WarehouseId")]
        public Warehouse Warehouse { get; set; }

        [Association(ThisKey = "SupplierId", OtherKey = "SupplierId")]
        public Supplier Supplier { get; set; }

        [Association(ThisKey = "TransactionId", OtherKey = "TransactionId")]
        public Transaction Transaction { get; set; }
    }
}
