using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProductModel2026
{
    public interface ISupplier<T> : IRepository<T> where T : Supplier
    {
    }
}
