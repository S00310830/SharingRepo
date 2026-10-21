using Microsoft.EntityFrameworkCore;
using ProductModel2026;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Sql_lite_EF9_Maui_sample_2026.DataLayer
{
    public class ProductDataService : IProduct<Product>
    {
        private readonly MauiProductContext _context;
        public ProductDataService(MauiProductContext productContext)
        {
            _context = productContext;
        }


        public Task Add(Product entity)
        {
            throw new NotImplementedException();
        }

        public Task AddRange(IEnumerable<Product> entities)
        {
            throw new NotImplementedException();
        }

        public Task<List<Product>> Find(Expression<Func<Product, bool>> predicate)
        {
            throw new NotImplementedException();
        }

        public Task<Product> Get(int id)
        {
            throw new NotImplementedException();
        }

        public Task<List<Product>> GetAll()
        {
            return _context.Products
             .Include(p => p.Suppliers)
             .ToListAsync();
        }

        public Task Remove(Product entity)
        {
            throw new NotImplementedException();
        }

        public Task RemoveRange(IEnumerable<Product> entities)
        {
            throw new NotImplementedException();
        }

        public async Task Update(Product entity)
        {
            if (entity == null) throw new ArgumentNullException(nameof(entity));
            _context.Products.Update(entity);
            await _context.SaveChangesAsync();
        }
    }
}
