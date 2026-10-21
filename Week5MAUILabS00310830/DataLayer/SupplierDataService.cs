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
    public class SupplierDataService : ISupplier<Supplier>
    {
        private readonly MauiProductContext _context;
        public SupplierDataService(MauiProductContext supplierContext)
        {
            _context = supplierContext;
        }

        public Task Add(Supplier entity)
        {
            throw new NotImplementedException();
        }

        public Task AddRange(IEnumerable<Supplier> entities)
        {
            throw new NotImplementedException();
        }

        public Task<List<Supplier>> Find(Expression<Func<Supplier, bool>> predicate)
        {
            throw new NotImplementedException();
        }

        public Task<Supplier> Get(int id)
        {
            throw new NotImplementedException();
        }

        public Task<List<Supplier>> GetAll()
        {
            return _context.Suppliers
             .ToListAsync();
        }

        public Task Remove(Supplier entity)
        {
            throw new NotImplementedException();
        }

        public Task RemoveRange(IEnumerable<Supplier> entities)
        {
            throw new NotImplementedException();
        }

        public async Task Update(Supplier entity)
        {
            if (entity == null) throw new ArgumentNullException(nameof(entity));
            _context.Suppliers.Update(entity);
            await _context.SaveChangesAsync();
        }
    }
}
