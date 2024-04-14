using LinqToDB.Mapping;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassLibraryGameShop
{
    [Table("Publisher")]
    public class Publisher
    {
        [PrimaryKey, NotNull] public string PublisherId { get; set; }

        [Column, NotNull] public string PublisherName { get; set; }

        [Column, Nullable] public string CategoryId { get; set; }

        [Association(ThisKey = "CategoryId", OtherKey = "CategoryId")]
        public Category Category { get; set; }
    }
}
