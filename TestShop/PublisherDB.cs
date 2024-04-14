using LinqToDB;
using LinqToDB.Mapping;
using System;
using ClassLibraryGameShop;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LinqToDB.DataProvider.SqlServer;

namespace TestShop
{
    public class PublisherDB
    {
        private const string CONNECTION_STRING = @"Server=DESKTOP-4DJEC1V\MSSQLSERVER01;DataBase=GameShop;Trusted_Connection=True;";
        public int Create(string publisherId, string publisherName, string categoryId)
        {
            using (var db = SqlServerTools.CreateDataConnection(CONNECTION_STRING))
            {
                var categoryDb = new CategoryDB().GetById(categoryId);
                if (GetById(publisherId) != null || GetByName(publisherName)!=null || categoryDb ==null)
                    return 0; 
                else
                    return db.GetTable<Publisher>()
                             .Value(p => p.PublisherId, publisherId)
                             .Value(p => p.PublisherName, publisherName)
                             .Value(p => p.CategoryId, categoryId)
                             .Insert();
            }
        }

        public List<Publisher> Read()
        {
            using (var db = SqlServerTools.CreateDataConnection(CONNECTION_STRING))
            {
                return db.GetTable<Publisher>().LoadWith(lw => lw.Category).ToList();
            }
        }

        public Publisher GetById(string publisherId)
        {
            using (var db = SqlServerTools.CreateDataConnection(CONNECTION_STRING))
            {
                return db.GetTable<Publisher>()
                         .Where(p => p.PublisherId == publisherId)
                         .FirstOrDefault();
            }
        }

        public Publisher GetByName(string publisherName)
        {
            using (var db = SqlServerTools.CreateDataConnection(CONNECTION_STRING))
            {
                return db.GetTable<Publisher>()
                         .Where(p => p.PublisherName == publisherName)
                         .FirstOrDefault();
            }
        }

        public int Update(string publisherId, string publisherName, string categoryId)
        {
            using (var db = SqlServerTools.CreateDataConnection(CONNECTION_STRING))
            {
                var categoryDb = new CategoryDB().GetById(categoryId);
                if (GetByName(publisherName) != null || categoryDb == null)
                    return 0;
                else
                    return db.GetTable<Publisher>()
                         .Where(p => p.PublisherId == publisherId)
                         .Set(p => p.PublisherName, publisherName)
                         .Set(p => p.CategoryId, categoryId)
                         .Update();
            }
        }

        public int Delete(string publisherId)
        {
            using (var db = SqlServerTools.CreateDataConnection(CONNECTION_STRING))
            {
                return db.GetTable<Publisher>()
                         .Where(p => p.PublisherId == publisherId)
                         .Delete();
            }
        }
    }
}
