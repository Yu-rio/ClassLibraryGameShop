using LinqToDB.Mapping;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassLibraryGameShop
{
    [Table("Platform")]
    public class Platform
    {
        [PrimaryKey, NotNull] public string PlatformId { get; set; }

        [Column, NotNull] public string PlatformName { get; set; }
    }
}
