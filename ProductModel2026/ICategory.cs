using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProductModel2026
{
    public interface ICategory<T> : IRepository<T> where T : Category
    {

    }
}
