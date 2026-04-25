using Microsoft.EntityFrameworkCore;
using Proyect.Clear.Arquitect.Domain.Entity;
using Proyect.Clear.Arquitect.Domain.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Proyect.Clear.Arquitect.Infrastructure.Service
{
    public class EfProductRepository : IProductRepository
    {
        private readonly AppDbContext _context;

        public EfProductRepository(AppDbContext context)
        {
            _context = context;
        }

        public async Task AddAsync(Product product)
        {
            _context.Products.Add(product);
            await _context.SaveChangesAsync();
        }

        public async Task<bool?> DeleteAsync(Product product)
        {
            try
            {
                _context.Products.Remove(product);
                await _context.SaveChangesAsync();
                return true;
            }
            catch {
                return false;
            }
        }

        public async Task<IEnumerable<Product>> GetAsync()
        {
            return await _context.Products.ToListAsync();
        }

        public async Task<Product?> GetByIdAsync(string id)
        {
            if (!Guid.TryParse(id, out Guid guidId))
                return null; // o lanza una excepción si prefieres

            return await _context.Products
                                 .FirstOrDefaultAsync(p => p.Id == guidId);
        }

        public async Task<Product?> GetByNameAsync(string name)
        {
            return await _context.Products.FirstOrDefaultAsync(p => p.Name == name);
        }

        public async Task<IEnumerable<Product>> GetPriceMinAsync(double preci)
        {
            return await _context.Products
                       .Where(p => p.Price >= preci)
                       .ToListAsync();
        }

        public async Task<Product?> UpdateAsync(Product product)
        {
            _context.Products.Update(product);
            await _context.SaveChangesAsync();
            return product;
        }
    }
}
