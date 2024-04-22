using LinqToDB;
using LinqToDB.DataProvider.SqlServer;
using ClassLibraryGameShop;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TestShop;
using System.Xml.Linq;

namespace TestShop
{
    public class CategoryDB
    {
        private const string CONNECTION_STRING = @"Server=DESKTOP-4DJEC1V\MSSQLSERVER01;DataBase=GameShop;Trusted_Connection=True;TrustServerCertificate=True;";

        public int Create(string id, string name)
        {
            using (var db = SqlServerTools.CreateDataConnection(CONNECTION_STRING))
            {
                if (GetByName(name) != null || GetById(id) !=null)
                    return 0;
                else
                    return db.GetTable<Category>()
                        .Value(p => p.CategoryName, name)
                        .Value(p => p.CategoryId, id)
                        .Insert();
            }
        }

        public List<Category> Read()
        {
            using (var db = SqlServerTools.CreateDataConnection(CONNECTION_STRING))
            {
                return db.GetTable<Category>().ToList();
            }
        }

        public Category GetById(string categoryId)
        {
            using (var db = SqlServerTools.CreateDataConnection(CONNECTION_STRING))
            {
                return db.GetTable<Category>()
                    .Where(c => c.CategoryId == categoryId)
                    .FirstOrDefault();

            }
        }
        public Category GetByName(string categoryName)
        {
            using (var db = SqlServerTools.CreateDataConnection(CONNECTION_STRING))
            {
                return db.GetTable<Category>()
                    .Where(c => c.CategoryName.StartsWith(categoryName))
                    .FirstOrDefault();
            }
        }

        public int Update(string id, string name)
        {
            using (var db = SqlServerTools.CreateDataConnection(CONNECTION_STRING))
            {
                return db.GetTable<Category>()
                    .Where(c => c.CategoryId == id)
                    .Set(c => c.CategoryName, name)
                    .Update();
            }
        }

        public int Delete(string id)
        {
            using (var db = SqlServerTools.CreateDataConnection(CONNECTION_STRING))
            {
                return db.GetTable<Category>()
                    .Where(c => c.CategoryId == id)
                    .Delete();
            }
        }
    }
}
