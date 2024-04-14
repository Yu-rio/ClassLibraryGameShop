using LinqToDB.Mapping;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassLibraryGameShop
{
    [Table("Genre")]
    public class Genre
    {
        [PrimaryKey, NotNull] public string GenreId { get; set; }

        [Column, NotNull] public string GenreName { get; set; }

        [Column, Nullable] public string CategoryId { get; set; }

        [Association(ThisKey = "CategoryId", OtherKey = "CategoryId")]
        public Category Category { get; set; }
    }
}
