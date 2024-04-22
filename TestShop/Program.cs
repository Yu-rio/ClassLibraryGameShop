using ClassLibraryGameShop;
using System.Transactions;
using TestShop;
customerAndCategory();
static void customerAndCategory()
{
    CategoryDB categoryDB = new CategoryDB();
    CustomerDB customerDB = new CustomerDB();
    CartItemDB cartItemDB = new CartItemDB();
    DeliveryDB deliveryDB = new DeliveryDB();
    GenreDB genreDB = new GenreDB();
    OrderDB orderDB = new OrderDB();
    OrderItemDB orderItemDB = new OrderItemDB();
    PlatformDB platformDB = new PlatformDB();
    ProductDB productDB = new ProductDB();
    PublisherDB publisherDB = new PublisherDB();
    ShipmentDB shipmentDB = new ShipmentDB();
    ShipmentItemDB shipmentItemDB = new ShipmentItemDB();
    SupplierDB supplierDB = new SupplierDB();
    WarehouseDB warehouseDB = new WarehouseDB();

    
    Console.WriteLine("Creating a new customer...");
    int customerId = customerDB.Create("CM000003", "Валерий", "Жарков", "Алексеевич", "vabubadi23@mail.ru", new DateTime(2015, 7, 20), "г.Слободской, ул.Варюгова, д.23", "AS*D^FB^*A%SDF");
    Console.WriteLine("Customer created with ID: " + customerId);

    
    Console.WriteLine("Reading customers...");
    List<Customer> customers = customerDB.Read();
    foreach (var customer in customers)
    {
        Console.WriteLine($"Customer ID: {customer.CustomerId}, Name: {customer.FirstName}, Date: {customer.Birthday}");
    }
    
    Console.WriteLine("Reading categories...");
    List<Category> categories = categoryDB.Read();
    foreach (var category in categories)
    {
        Console.WriteLine($"Category ID: {category.CategoryId}, Name: {category.CategoryName}");
    }

    int categoryId = categoryDB.Update("C02", "Gift Cardes and Vouchers");
    Console.WriteLine("Category updated with ID: " + categoryId);
    categoryId = categoryDB.Create("C01", "Games");
    Console.WriteLine("Category created with ID: " + categoryId);
    
    categoryId = categoryDB.Delete("C04");
    Console.WriteLine("Category deleted with ID: " + categoryId);
    categoryId = categoryDB.Delete("C03");
    Console.WriteLine("Category deleted with ID: " + categoryId);
    categories = categoryDB.Read();
    foreach (var category in categories)
    {
        Console.WriteLine($"Category ID: {category.CategoryId}, Name: {category.CategoryName}");
    }
}