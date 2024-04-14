using LinqToDB.Mapping;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassLibraryGameShop
{
    [Table("CartItem")]
    public class CartItem
    {
        [Column] public float? Price { get; set; }

        [Column] public int? Quantity { get; set; }

        [PrimaryKey(1), NotNull] public string ProductId { get; set; }

        [PrimaryKey(2), NotNull] public string CartId { get; set; }

        [Association(ThisKey = "ProductId", OtherKey = "ProductId")]
        public Product Product { get; set; }

        [Association(ThisKey = "CartId", OtherKey = "CartId")]
        public Cart Cart { get; set; }
    }
}
