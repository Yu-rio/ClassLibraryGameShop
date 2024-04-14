using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LinqToDB.Mapping;

namespace ClassLibraryGameShop
{
    [Table("Product")]
    public class Product
    {
        [PrimaryKey, NotNull] public string ProductId { get; set; }

        [Column, NotNull] public string Title { get; set; }

        [Column, Nullable] public string TrailerLink { get; set; }

        [Column] public int? Quantity { get; set; }

        [Column, NotNull] public float Price { get; set; }

        [Column, Nullable] public string Content { get; set; }

        [Column, NotNull] public string CategoryId { get; set; }

        [Association(ThisKey = "CategoryId", OtherKey = "CategoryId")]
        public Category Category { get; set; }

        [Column, Nullable] public string PublisherId { get; set; }

        [Association(ThisKey = "PublisherId", OtherKey = "PublisherId")]
        public Publisher Publisher { get; set; }

        [Column, Nullable] public string GenreId { get; set; }

        [Association(ThisKey = "GenreId", OtherKey = "GenreId")]
        public Genre Genre { get; set; }

        [Column, Nullable] public string PlatformId { get; set; }

        [Association(ThisKey = "PlatformId", OtherKey = "PlatformId")]
        public Platform Platform { get; set; }
    }
}
