using LinqToDB.Mapping;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassLibraryGameShop
{
    [Table("OrderItem")]
    public class OrderItem
    {
        [Column] public float? Price { get; set; }

        [Column] public int? Quantity { get; set; }

        [PrimaryKey(1), NotNull] public string ProductId { get; set; }

        [PrimaryKey(2), NotNull] public string OrderId { get; set; }

        [Association(ThisKey = "ProductId", OtherKey = "ProductId")]
        public Product Product { get; set; }

        [Association(ThisKey = "OrderId", OtherKey = "OrderId")]
        public Order Order { get; set; }
    }
}
