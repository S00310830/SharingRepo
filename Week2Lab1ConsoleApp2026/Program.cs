namespace Week2Lab1ConsoleApp2026;

using Microsoft.EntityFrameworkCore;
using Tracker.WebAPIClient;

internal class Program
{
    static void Main(string[] args)
    {
        ActivityAPIClient.Track(StudentID: "S00310830",
            StudentName: "Isaac Lavergne",
            activityName: "RAD301 2026 Week 2 Lab 1",
            Task: "Implementing Queries");

        list_categories();
        list_products();
        list_products(50);
        list_product_value();
        list_category_products("Hardware");
        list_supplier_parts();
        add_new_supplier("New Supplier", "123 Main St", "Suite 100");
    }

    public static void list_categories()
    {
        using (DatabaseContext db = new DatabaseContext(new DbContextOptions<DatabaseContext>()))
        {
            // get all categories and display their details
            foreach (var category in db.Categories)
            {
                Console.WriteLine($"Category ID: {category.CategoryID}, Description: {category.Description}");
            }
            Console.WriteLine("Press any key to continue...\n");
            Console.ReadKey();
        }
    }

    public static void list_products()
    {
        using (DatabaseContext db = new DatabaseContext(new DbContextOptions<DatabaseContext>()))
        {
            // get all products and display their details
            foreach (var product in db.Products)
            {
                Console.WriteLine($"Product ID: {product.ProductId}, Description: {product.Description}, Unit Price: {product.UnitPrice}, Date First Issued: {product.DateFirstIssued}, Quantity In Stock: {product.QuantityInStock}");
            }
            Console.WriteLine("Press any key to continue...\n");
            Console.ReadKey();
        }
    }

    public static void list_products(int UpperLimit)
    {
        using (DatabaseContext db = new DatabaseContext(new DbContextOptions<DatabaseContext>()))
        {
            // get all products with a unit price less than or equal to the upper limit
            var products = db.Products.Where(p => p.UnitPrice <= UpperLimit);
            foreach (var product in products)
            {
                Console.WriteLine($"Product ID: {product.ProductId}, Description: {product.Description}, Unit Price: {product.UnitPrice}, Date First Issued: {product.DateFirstIssued}, Quantity In Stock: {product.QuantityInStock}");
            }
            Console.WriteLine("Press any key to continue...\n");
            Console.ReadKey();
        }
    }

    public static void list_product_value()
    {
        using (DatabaseContext db = new DatabaseContext(new DbContextOptions<DatabaseContext>()))
        {
            // calculate the total value of each product (UnitPrice * QuantityInStock) and get the product id, description, and total value
            var products = db.Products.Select(p => new
            {
                p.ProductId,
                p.Description,
                Value = p.UnitPrice * p.QuantityInStock
            });
            foreach (var product in products)
            {
                Console.WriteLine($"Product ID: {product.ProductId}, Description: {product.Description}, Total Value: {product.Value}");
            }
            Console.WriteLine("Press any key to continue...\n");
            Console.ReadKey();
        }
    }

    public static void list_category_products(string Category)
    {
        using (DatabaseContext db = new DatabaseContext(new DbContextOptions<DatabaseContext>()))
        {
            // get the category id for the given category description
            var selected_category = db.Categories.Where(c => c.Description == Category).Select(c => c.CategoryID).FirstOrDefault();
            
            // get all products for the selected category
            var products = db.Products.Where(p => p.CategoryId == selected_category);
            foreach (var product in products)
            {
                Console.WriteLine($"Product ID: {product.ProductId}, Description: {product.Description}, Unit Price: {product.UnitPrice:F2}, Date First Issued: {product.DateFirstIssued}, Quantity In Stock: {product.QuantityInStock}, Category: {Category}");
            }
            Console.WriteLine("Press any key to continue...\n");
            Console.ReadKey();
        }
    }

    public static void list_supplier_parts()
    {
        using (DatabaseContext db = new DatabaseContext(new DbContextOptions<DatabaseContext>()))
        {
            var supplier_list = db.Suppliers.ToList();
            foreach (var supplier in supplier_list)
            {
                Console.WriteLine($"\nSupplier ID: {supplier.SupplierID}, Name: {supplier.SupplierName}\n");

                // get product ids supplied by this supplier
                var products = db.Products
                   .Where(p => db.SupplierProducts
                       .Any(sp => sp.SupplierID == supplier.SupplierID &&
                                 sp.ProductID == p.ProductId))
                   .ToList();

                // List all products supplied by the selected supplier in the outer loop
                foreach (var product in products)
                {
                    Console.WriteLine($"Product ID: {product.ProductId}, Description: {product.Description}, Unit Price: {product.UnitPrice}, Date First Issued: {product.DateFirstIssued}, Quantity In Stock: {product.QuantityInStock}");
                }
            }
            Console.WriteLine("Press any key to continue...\n");
            Console.ReadKey();
        }
    }

    public static void add_new_supplier(string SupplierName, string SupplierAddressLine1, string SupplierAddressLine2)
    {
        using (DatabaseContext db = new DatabaseContext(new DbContextOptions<DatabaseContext>()))
        {
            // create a new supplier object
            Supplier newSupplier = new Supplier
            {
                SupplierName = SupplierName,
                SupplierAddressLine1 = SupplierAddressLine1,
                SupplierAddressLine2 = SupplierAddressLine2
            };
            // add the new supplier to the database
            db.Suppliers.Add(newSupplier);
            db.SaveChanges();
            Console.WriteLine($"New supplier added: {newSupplier.SupplierName}, Address: {newSupplier.SupplierAddressLine1}, Phone: {newSupplier.SupplierAddressLine2}");
        }
    }
}

