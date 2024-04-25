using ClassLibraryGameShop;
using LinqToDB;
using LinqToDB.DataProvider.SqlServer;

namespace TestShop
{
    public class ProductDB
    {
        private const string CONNECTION_STRING = @"Server=DESKTOP-4DJEC1V\MSSQLSERVER01;DataBase=GameShop;Trusted_Connection=True;TrustServerCertificate=True;";
        public int Create(string productId, string title, string trailerLink, int? quantity, float price, string content, string categoryId, string publisherId, string genreId, string platformId)
        {
            using (var db = SqlServerTools.CreateDataConnection(CONNECTION_STRING))
            {
                var categoryDb = new CategoryDB().GetById(categoryId);
                var publisherDb = new PublisherDB().GetById(publisherId);
                var platformDb = new PlatformDB().GetById(platformId);
                var genreDb = new GenreDB().GetById(genreId);
                if (GetById(productId) != null || categoryDb == null || publisherDb == null || platformDb ==null || genreDb==null)
                    return 0; 
                else
                    return db.GetTable<Product>()
                             .Value(p => p.ProductId, productId)
                             .Value(p => p.Title, title)
                             .Value(p => p.TrailerLink, trailerLink)
                             .Value(p => p.Quantity, quantity)
                             .Value(p => p.Price, price)
                             .Value(p => p.Content, content)
                             .Value(p => p.CategoryId, categoryId)
                             .Value(p => p.PublisherId, publisherId)
                             .Value(p => p.GenreId, genreId)
                             .Value(p => p.PlatformId, platformId)
                             .Insert();
            }
        }

        public List<Product> Read()
        {
            using (var db = SqlServerTools.CreateDataConnection(CONNECTION_STRING))
            {
                return db.GetTable<Product>().LoadWith(lw => lw.Platform).LoadWith(lw => lw.Category)
                    .LoadWith(lw => lw.Genre).LoadWith(lw => lw.Publisher).ToList();
            }
        }

        public Product GetById(string productId)
        {
            using (var db = SqlServerTools.CreateDataConnection(CONNECTION_STRING))
            {
                return db.GetTable<Product>()
                         .Where(p => p.ProductId == productId)
                         .FirstOrDefault();
            }
        }

        public int Update(string productId, string title, string trailerLink, int? quantity, float price, string content, string categoryId, string publisherId, string genreId, string platformId)
        {
            using (var db = SqlServerTools.CreateDataConnection(CONNECTION_STRING))
            {
                var categoryDb = new CategoryDB().GetById(categoryId);
                var publisherDb = new PublisherDB().GetById(publisherId);
                var platformDb = new PlatformDB().GetById(platformId);
                var genreDb = new GenreDB().GetById(genreId);
                if (categoryDb == null || publisherDb == null || platformDb == null || genreDb == null)
                    return 0;
                else
                    return db.GetTable<Product>()
                         .Where(p => p.ProductId == productId)
                         .Set(p => p.Title, title)
                         .Set(p => p.TrailerLink, trailerLink)
                         .Set(p => p.Quantity, quantity)
                         .Set(p => p.Price, price)
                         .Set(p => p.Content, content)
                         .Set(p => p.CategoryId, categoryId)
                         .Set(p => p.PublisherId, publisherId)
                         .Set(p => p.GenreId, genreId)
                         .Set(p => p.PlatformId, platformId)
                         .Update();
            }
        }

        public int Delete(string productId)
        {
            using (var db = SqlServerTools.CreateDataConnection(CONNECTION_STRING))
            {
                return db.GetTable<Product>()
                         .Where(p => p.ProductId == productId)
                         .Delete();
            }
        }
    }
}
