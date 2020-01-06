using BlazingShop.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace BlazingShop.Services
{
    public class ProductService
    {
        private readonly ApplicationDbContext _db;

        public ProductService(ApplicationDbContext db)
        {
            _db = db;
        }

        public Product GetProduct(int productId)
        {
            return _db.Products.Include(u => u.Category).FirstOrDefault(u => u.Id == productId);
        }

        public List<Product> GetProducts()
        {
            return _db.Products.Include(u => u.Category).ToList();
        }

        public List<Category> GetCategoryList()
        {
            return _db.Categories.ToList();
        }

        public bool CreateProduct(Product product)
        {
            try
            {
                _db.Products.Add(product);
                _db.SaveChanges();
                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }

        public bool UpdateProduct(Product product)
        {
            var existingProduct = _db.Products.FirstOrDefault(u => u.Id == product.Id);
            if (existingProduct != null)
            {
                if(product.Image == null)
                {
                    product.Image = existingProduct.Image;
                }
                _db.Products.Update(product);
                _db.SaveChanges();
            }
            else
            {
                return false;
            }
            return true;
        }

        public bool DeleteProduct(Product product)
        {
            var existingProduct = _db.Products.FirstOrDefault(u => u.Id == product.Id);
            if (existingProduct != null)
            {
                _db.Products.Remove(existingProduct);
                _db.SaveChanges();
            }
            else
            {
                return false;
            }
            return true;
        }
    }
}
