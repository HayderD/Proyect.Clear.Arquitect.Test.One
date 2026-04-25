using Proyect.Clear.Arquitect.Domain.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Proyect.Clear.Arquitect.Domain.Interfaces
{
    public interface IProductRepository
    {
        Task<IEnumerable<Product>> GetAsync();
        Task AddAsync(Product product);
        Task<Product?> GetByIdAsync(string id);
        Task<Product?> GetByNameAsync(string name);
        Task<Product?> UpdateAsync(Product product);
        Task<bool?> DeleteAsync(Product product);
        Task<IEnumerable<Product>> GetPriceMinAsync(double preci);
    }
}
