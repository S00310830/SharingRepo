using Microsoft.EntityFrameworkCore;
using Tracker.WebAPIClient;
using Week32026.S00310830.BusinessModel;

namespace Week3ConsoleApp2026.S00310830
{
    internal class Program
    {
        static void Main(string[] args)
        {
            using (ProductDbContext db = new ProductDbContext(new DbContextOptions<ProductDbContext>()))
            {
                db.Categories.Add(new Category
                {
                    Description = "Accessories",
                    Products = new List<Product>
                    {
                        new Product
                        {
                            Description = "Bow Tie",
                            UnitPrice = 12.99f,
                            dateFirstIssued = DateTime.Now,
                            QuantityInStock = 200
                        },
                    }
                });
                db.SaveChanges();
            }

            ActivityAPIClient.Track(StudentID: "s00310830",
                StudentName: "isaac lavergne",
                activityName: "rad301 2026 week 3 lab 1",
                Task: "creating first category with roduct");
        }
    }
}
            
    


