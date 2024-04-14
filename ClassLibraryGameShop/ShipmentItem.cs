using LinqToDB.Mapping;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassLibraryGameShop
{
    [Table("ShipmentItem")]
    public class ShipmentItem
    {
        [PrimaryKey(1), NotNull] public string ShipmentId { get; set; }

        [PrimaryKey(2), NotNull] public string ProductId { get; set; }

        [Column, NotNull] public int Quantity { get; set; }

        [Column] public float? Price { get; set; }

        [Association(ThisKey = "ProductId", OtherKey = "ProductId")]
        public Product Product { get; set; }

        [Association(ThisKey = "ShipmentId", OtherKey = "ShipmentId")]
        public Shipment Shipment { get; set; }
    }
}
