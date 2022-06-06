using Domain.Entities;
using Domain.Repositories;
using Infra.Data.Context;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infra.Data.Repositories
{
    public class ProductRepository : IProductRepository
    {

        private readonly ApplicationDbContext _db;
        public ProductRepository(ApplicationDbContext db)
        {
            _db = db;
        }
         async Task<Product> IProductRepository.CreateAsync(Product product)
        {
            _db.Add(product);
            await _db.SaveChangesAsync();
            return product;
        }

         async Task IProductRepository.DeleteAsync(Product product)
        {
            _db.Remove(product);
            await _db.SaveChangesAsync();
        }

         async Task IProductRepository.EditAsync(Product product)
        {
            _db.Update(product);
            await _db.SaveChangesAsync();
        }

         async Task<Product> IProductRepository.GetByIdAsync(int id)
        {
            return await _db.Product.FirstOrDefaultAsync(x => x.Id == id);
        }

         async Task<ICollection<Product>> IProductRepository.GetProductsAsync()
        {
            return await _db.Product.ToListAsync();
        }

    }
}
