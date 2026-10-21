using System;
using System.CodeDom;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Rad301_2026_Week1_Lab1
{
    internal class ProductModel
    {
        public List<Product> products = new List<Product>
        {
            new Product
            {
                Id = 1,
                Description = "9\u0022 nails",
                QuantityInStock = 200,
                UnitPrice = 0.10f,
                CategoryID = 1
            },

            new Product
            {
                Id = 2,
                Description = "9\u0022 bolts",
                QuantityInStock = 120,
                UnitPrice = 0.20f,
                CategoryID = 1
            },

            new Product
            {
                Id = 3,
                Description = "Chimney Hoover",
                QuantityInStock = 10,
                UnitPrice = 100.50f,
                CategoryID = 2
            },

            new Product
            {
                Id = 4,
                Description = "Washing Machine",
                QuantityInStock = 7,
                UnitPrice = 399.99f,
                CategoryID = 2
            }
        };

        public List<Supplier> suppliers = new List<Supplier>
        {
            new Supplier
            {
                SupplierID = 1,
                SupplierName = "Parts 1",
                SupplierAddressLine1 = "Addr 11",
                SupplierAddressLine2 = "Addr 21"
            },

            new Supplier
            {
                SupplierID = 2,
                SupplierName = "Parts 2",
                SupplierAddressLine1 = "Addr 11",
                SupplierAddressLine2 = "Addr 21"
            }
        };

        public List<Category> categories = new List<Category>
        {
            new Category
            {
                Id = 1,
                Description = "Hardware"
            },

            new Category
            {
                Id = 2,
                Description = "Electrical Appliances"
            }
        };

        public List<SupplierProduct> supplierProducts = new List<SupplierProduct>
        {
            new SupplierProduct
            {
                SupplierId = 1,
                ProductId = 1,
                DateFirstSupplied = new DateTime(2012, 12, 12)
            },

            new SupplierProduct
            {
                SupplierId = 1,
                ProductId = 2,
                DateFirstSupplied = new DateTime(2013, 01, 06)
            },

            new SupplierProduct
            {
                SupplierId = 2,
                ProductId = 3,
                DateFirstSupplied = new DateTime(2017, 09, 09)
            },

            new SupplierProduct
            {
                SupplierId = 2,
                ProductId = 4,
                DateFirstSupplied = new DateTime(2017, 09, 10)
            }
        };

        public class Product
        {
            public int Id { get; set; }
            public string Description { get; set; }
            public int QuantityInStock { get; set; }
            public float UnitPrice { get; set; }
            public int CategoryID { get; set; }

            public override string ToString()
            {
                return String.Concat("ID: ", Id.ToString(), "\nDescription: ", Description, "\nQOH: ", QuantityInStock.ToString(),
                    "\nUnit Price: ", UnitPrice.ToString("F2"), "\nCategory ID:", CategoryID.ToString());
            }
        }

        public class Category
        {
            public int Id { get; set; }
            public string Description { get; set; }

            public override string ToString()
            {
                return String.Concat("ID: ", Id.ToString(), "\nDescription: ", Description);
            }
        }

        public class SupplierProduct
        {
            public int SupplierId { get; set; }
            public int ProductId { get; set; }
            public DateTime DateFirstSupplied { get; set; }

            public override string ToString()
            {
                return String.Concat("Supplier ID: ", SupplierId.ToString(), "\nProduct ID: ", ProductId.ToString(),
                    "\nFirst Supplied Date: ", DateFirstSupplied.ToShortDateString());
            }

        }

        public class Supplier
        {
            public int SupplierID { get; set; }
            public string SupplierName { get; set; }
            public string SupplierAddressLine1 { get; set; }
            public string SupplierAddressLine2 { get; set; }

            public override string ToString()
            {
                return String.Concat("Supplier ID: ", SupplierID.ToString(), "\nSupplier Name: ", SupplierName,
                    "\nSupplier Address Line 1: ", SupplierAddressLine1, "\nSupplier Address Line 2: ", SupplierAddressLine2);
            }
        }
    }
}
