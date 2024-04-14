using LinqToDB.Mapping;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassLibraryGameShop
{
    [Table("Cart")]
    public class Cart
    {
        [PrimaryKey, NotNull] public string CartId { get; set; }

        [Column, NotNull] public DateTime CreatedAt { get; set; }

        [Column, NotNull] public DateTime UpdatedAt { get; set; }

        [Column, NotNull] public string CustomerId { get; set; }

        [Association(ThisKey = "CustomerId", OtherKey = "CustomerId")]
        public Customer Customer { get; set; }
    }
}
