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
    public class PlatformDB
    {
        private const string CONNECTION_STRING = @"Server=DESKTOP-4DJEC1V\MSSQLSERVER01;DataBase=GameShop;Trusted_Connection=True;TrustServerCertificate=True;";
        public int Create(string platformId, string platformName)
        {
            using (var db = SqlServerTools.CreateDataConnection(CONNECTION_STRING))
            {
                if (GetById(platformId) != null || GetByName(platformName)!=null)
                    return 0; 
                else
                    return db.GetTable<Platform>()
                             .Value(p => p.PlatformId, platformId)
                             .Value(p => p.PlatformName, platformName)
                             .Insert();
            }
        }

        public List<Platform> Read()
        {
            using (var db = SqlServerTools.CreateDataConnection(CONNECTION_STRING))
            {
                return db.GetTable<Platform>().ToList();
            }
        }

        public Platform GetById(string platformId)
        {
            using (var db = SqlServerTools.CreateDataConnection(CONNECTION_STRING))
            {
                return db.GetTable<Platform>()
                         .Where(p => p.PlatformId == platformId)
                         .FirstOrDefault();
            }
        }
        public Platform GetByName(string platformName)
        {
            using (var db = SqlServerTools.CreateDataConnection(CONNECTION_STRING))
            {
                return db.GetTable<Platform>()
                         .Where(p => p.PlatformName.StartsWith(platformName))
                         .FirstOrDefault();
            }
        }


        public int Update(string platformId, string platformName)
        {
            using (var db = SqlServerTools.CreateDataConnection(CONNECTION_STRING))
            {
                return db.GetTable<Platform>()
                         .Where(p => p.PlatformId == platformId)
                         .Set(p => p.PlatformName, platformName)
                         .Update();
            }
        }

        public int Delete(string platformId)
        {
            using (var db = SqlServerTools.CreateDataConnection(CONNECTION_STRING))
            {
                return db.GetTable<Platform>()
                         .Where(p => p.PlatformId == platformId)
                         .Delete();
            }
        }
    }
}
