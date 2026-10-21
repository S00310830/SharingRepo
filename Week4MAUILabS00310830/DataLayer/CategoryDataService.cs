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
    public class CategoryDataService : ICategory<Category>
    {
        private readonly MauiProductContext _context;
        public CategoryDataService(MauiProductContext productContext)
        {
            _context = productContext;
        }


        public Task Add(Category entity)
        {
            throw new NotImplementedException();
        }

        public Task AddRange(IEnumerable<Category> entities)
        {
            throw new NotImplementedException();
        }

        public Task<List<Category>> Find(Expression<Func<Category, bool>> predicate)
        {
            throw new NotImplementedException();
        }

        public Task<Category> Get(int id)
        {
            throw new NotImplementedException();
        }

        public Task<List<Category>> GetAll()
        {
            return _context.Categories
             .Include(c => c.Products).
             ThenInclude(p => p.Suppliers)
             .ToListAsync();
        }

        public Task Remove(Category entity)
        {
            throw new NotImplementedException();
        }

        public Task RemoveRange(IEnumerable<Category> entities)
        {
            throw new NotImplementedException();
        }

        public async Task Update(Category entity)
        {
            if (entity == null) throw new ArgumentNullException(nameof(entity));
            _context.Categories.Update(entity);
            await _context.SaveChangesAsync();
        }
    }
}
