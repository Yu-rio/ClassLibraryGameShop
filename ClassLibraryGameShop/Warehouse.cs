using LinqToDB.Mapping;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassLibraryGameShop
{
    [Table("Warehouse")]
    public class Warehouse
    {
        [PrimaryKey, NotNull] public string WarehouseId { get; set; }

        [Column("Address"), NotNull] public string Address { get; set; }

        [Column, NotNull] public string PhoneNumber { get; set; }
    }
}
