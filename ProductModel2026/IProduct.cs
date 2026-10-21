using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProductModel2026
{
    public interface IProduct<T> : IRepository<T> where T : Product 
    {
    }
}
