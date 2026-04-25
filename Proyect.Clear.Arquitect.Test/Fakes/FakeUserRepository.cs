using Proyect.Clear.Arquitect.Domain.Entity;
using Proyect.Clear.Arquitect.Domain.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Proyect.Clear.Arquitect.Test.Fakes
{
    public class FakeProductRepository : IProductRepository
    {
        private readonly List<Product> _products = new();     

        public Task<IEnumerable<Product>> GetAsync()
        {
            throw new NotImplementedException();
        }

        public Task AddAsync(Product product)
        {
            throw new NotImplementedException();
        }

        public Task<Product?> GetByIdAsync(string id)
        {
            throw new NotImplementedException();
        }

        public Task<Product?> GetByNameAsync(string name)
        {
            throw new NotImplementedException();
        }

        public Task<Product?> UpdateAsync(Product product)
        {
            throw new NotImplementedException();
        }

        public Task<bool?> DeleteAsync(Product product)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<Product>> GetPriceMinAsync(double preci)
        {
            var result = _products.Where(p => p.Price >= preci);
            return Task.FromResult(result);
        }
    }
}
