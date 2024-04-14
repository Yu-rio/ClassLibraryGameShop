using LinqToDB.Mapping;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassLibraryGameShop
{
    [Table("Delivery")]
    public class Delivery
    {
        [PrimaryKey, NotNull] public string DeliveryId { get; set; }

        [Column, NotNull] public string Name { get; set; }

        [Column, NotNull] public string PhoneNumber { get; set; }

        [Column, NotNull] public string Status { get; set; }
    }
}
