using ClassLibraryGameShop;
using LinqToDB;
using LinqToDB.DataProvider.SqlServer;

namespace TestShop
{
    public class CartItemDB
    {
        private const string CONNECTION_STRING = @"Server=DESKTOP-4DJEC1V\MSSQLSERVER01;DataBase=GameShop;Trusted_Connection=True;TrustServerCertificate=True;";
        public int Create(float? price, int? quantity, string productId, string cartId)
        {

            using (var db = SqlServerTools.CreateDataConnection(CONNECTION_STRING))
            {
                if (GetCartItemByProductIdAndCartId(productId, cartId) != null)
                    return 0;
                else
                    return db.GetTable<CartItem>()
                             .Value(ci => ci.Price, price)
                             .Value(ci => ci.Quantity, quantity)
                             .Value(ci => ci.ProductId, productId)
                             .Value(ci => ci.CartId, cartId)
                             .Insert();
            }
        }

        public List<CartItem> Read()
        {
            using (var db = SqlServerTools.CreateDataConnection(CONNECTION_STRING))
            {
                return db.GetTable<CartItem>()
                         .LoadWith(lw => lw.Product)
                         .LoadWith(lw => lw.Cart).ToList();
            }
        }

        public CartItem GetCartItemByProductIdAndCartId(string productId, string cartId)
        {
            using (var db = SqlServerTools.CreateDataConnection(CONNECTION_STRING))
            {
                return db.GetTable<CartItem>()
                         .Where(ci => ci.ProductId == productId && ci.CartId == cartId)
                         .LoadWith(lw => lw.Product)
                         .LoadWith(lw => lw.Cart)
                         .FirstOrDefault();
            }
        }
        public List<CartItem> GetCartItemByCartId(string cartId)
        {
            using (var db = SqlServerTools.CreateDataConnection(CONNECTION_STRING))
            {
                return db.GetTable<CartItem>()
                    .Where(ci => ci.CartId == cartId)
                    .LoadWith(lw => lw.Product)
                    .LoadWith(lw => lw.Cart)
                    .ToList();
            }
        }

        public int Update(float? price, int? quantity, string productId, string cartId)
        {
            using (var db = SqlServerTools.CreateDataConnection(CONNECTION_STRING))
            {
                return db.GetTable<CartItem>()
                         .Where(ci => ci.ProductId == productId && ci.CartId == cartId)
                         .Set(ci => ci.Price, price)
                         .Set(ci => ci.Quantity, quantity)
                         .Update();
            }
        }

        public int Delete(string productId, string cartId)
        {
            using (var db = SqlServerTools.CreateDataConnection(CONNECTION_STRING))
            {
                return db.GetTable<CartItem>()
                         .Where(ci => ci.ProductId == productId && ci.CartId == cartId)
                         .Delete();
            }
        }
    }
}
