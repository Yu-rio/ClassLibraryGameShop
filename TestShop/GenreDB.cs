using ClassLibraryGameShop;
using LinqToDB;
using LinqToDB.DataProvider.SqlServer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestShop
{
    public class GenreDB
    {
        private const string CONNECTION_STRING = @"Server=DESKTOP-4DJEC1V\MSSQLSERVER01;DataBase=GameShop;Trusted_Connection=True;TrustServerCertificate=True;";
        public int Create(string genreId, string genreName, string categoryId)
        {
            using (var db = SqlServerTools.CreateDataConnection(CONNECTION_STRING))
            {
                var categoryDb = new CategoryDB().GetById(categoryId);
                if (GetById(genreId) != null || GetByName(genreName)!=null || categoryDb == null)
                    return 0; 
                else
                    return db.GetTable<Genre>()
                             .Value(g => g.GenreId, genreId)
                             .Value(g => g.GenreName, genreName)
                             .Value(g => g.CategoryId, categoryId)
                             .Insert();
            }
        }

        public List<Genre> Read()
        {
            using (var db = SqlServerTools.CreateDataConnection(CONNECTION_STRING))
            {
                return db.GetTable<Genre>().LoadWith(lw => lw.Category).ToList();
            }
        }

        public Genre GetById(string genreId)
        {
            using (var db = SqlServerTools.CreateDataConnection(CONNECTION_STRING))
            {
                return db.GetTable<Genre>()
                         .Where(g => g.GenreId == genreId)
                         .FirstOrDefault();
            }
        }
        public Genre GetByName(string genreName)
        {
            using (var db = SqlServerTools.CreateDataConnection(CONNECTION_STRING))
            {
                return db.GetTable<Genre>()
                         .Where(g => g.GenreName.StartsWith(genreName))
                         .FirstOrDefault();
            }
        }
        public int Update(string genreId, string genreName, string categoryId)
        {
            using (var db = SqlServerTools.CreateDataConnection(CONNECTION_STRING))
            {
                var categoryDb = new CategoryDB().GetById(categoryId);
                if ( GetByName(genreName) != null || categoryDb == null)
                    return 0;
                else
                    return db.GetTable<Genre>()
                         .Where(g => g.GenreId == genreId)
                         .Set(g => g.GenreName, genreName)
                         .Set(g => g.CategoryId, categoryId)
                         .Update();
            }
        }

        public int Delete(string genreId)
        {
            using (var db = SqlServerTools.CreateDataConnection(CONNECTION_STRING))
            {
                return db.GetTable<Genre>()
                         .Where(g => g.GenreId == genreId)
                         .Delete();
            }
        }
    }
}
