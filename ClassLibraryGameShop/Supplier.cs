using LinqToDB.Mapping;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassLibraryGameShop
{
    [Table("Supplier")]
    public class Supplier
    {
        [PrimaryKey, NotNull] public string SupplierId { get; set; }

        [Column, NotNull] public string SupplierName { get; set; }

        [Column, NotNull] public string PhoneNumber { get; set; }

        [Column("Address"), NotNull] public string Address { get; set; }
    }
}
