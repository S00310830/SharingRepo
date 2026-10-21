using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tracker.WebAPIClient;

namespace Rad301_2026_Week1_Lab1
{
    internal class Program
    {
        static void Main(string[] args)
        {

            ActivityAPIClient.Track(StudentID: "S00310830", StudentName: "Isaac Lavergne",
            activityName: "Rad301 2026 Week 1 Lab 1",
            Task: "Designing classes Model");

            ActivityAPIClient.Track(StudentID: "S00310830", StudentName: "Isaac Lavergne",
            activityName: "Rad301 2026 Week 1 Lab 1 - Part 2",
            Task: "Starting Queries");

            ProductModel _productModel = new ProductModel();


            Console.WriteLine("\nList of Product Categories\n");

            foreach (var category in _productModel.categories)
            {
                Console.WriteLine(category);
                Console.WriteLine();
            }

            Console.WriteLine("\nProduct List\n");

            foreach (var product in _productModel.products)
            {
                Console.WriteLine(product);
                Console.WriteLine();
            }

            Console.WriteLine("Product List With Quantity <= 100\n");

            foreach (var product in _productModel.products.Where(p => p.QuantityInStock <= 100))
            {
                Console.WriteLine(product);
                Console.WriteLine();
            }

            Console.WriteLine("Products Listed With Total Inventory Value\n");

            foreach(var product in _productModel.products)
            {
                float totalPrice = product.UnitPrice * product.QuantityInStock;
                Console.WriteLine(product);
                Console.WriteLine("Total Price In Stock: " +  totalPrice);
                Console.WriteLine();
            }

            Console.WriteLine("Products Listed in the Hardware Category\n");

            foreach(var product in _productModel.products.Where(p => p.CategoryID == 1))
            {
                Console.WriteLine(product);
                Console.WriteLine();
            }

            Console.WriteLine("Supplier List With Supplier Parts\n");

            foreach (var supplier in _productModel.suppliers.OrderBy(p => p.SupplierName))
            {

                Console.WriteLine("\nParts for Supplier: " + supplier.SupplierID + "\n");
                Console.WriteLine(supplier + "\n");

                foreach (var supplierProduct in _productModel.supplierProducts.Where(p => p.SupplierId == supplier.SupplierID))
                {
                    foreach (var product in _productModel.products.Where(p => p.Id == supplierProduct.ProductId))
                    {
                        Console.WriteLine(product);
                        Console.WriteLine();
                    }                    
                }
                Console.WriteLine();
            }
        }
    }
}
