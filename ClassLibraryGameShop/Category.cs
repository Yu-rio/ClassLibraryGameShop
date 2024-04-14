using LinqToDB.Mapping;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassLibraryGameShop
{
    [Table("Category")]
    public class Category
    {
        [PrimaryKey, NotNull] public string CategoryId { get; set; }

        [Column, NotNull] public string CategoryName { get; set; }
    }
}
