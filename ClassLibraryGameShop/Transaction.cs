using LinqToDB.Mapping;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassLibraryGameShop
{
    [Table("Transaction")]
    public class Transaction
    {
        [PrimaryKey, NotNull] public string TransactionId { get; set; }

        [Column, NotNull] public string CustomerId { get; set; }

        [Column, NotNull] public string SupplierId { get; set; }

        [Association(ThisKey = "CustomerId", OtherKey = "CustomerId")]
        public Customer Customer { get; set; }

        [Association(ThisKey = "SupplierId", OtherKey = "SupplierId")]
        public Supplier Supplier { get; set; }
    }
}
