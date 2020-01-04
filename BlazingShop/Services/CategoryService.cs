using BlazingShop.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BlazingShop.Services
{
    public class CategoryService
    {
        private readonly ApplicationDbContext _db;

        public CategoryService(ApplicationDbContext db)
        {
            _db = db;
        }

        public Category GetCategory(int categoryId)
        {
            return _db.Categories.FirstOrDefault(u => u.Id == categoryId);
        }

        public List<Category> GetCategories()
        {
            return _db.Categories.ToList();
        }

        public bool CreateCategory(Category category)
        {
            try
            {
                _db.Categories.Add(category);
                _db.SaveChanges();
                return true;
            }
            catch(Exception ex)
            {
                return false;
            }
        }

        public bool UpdateCategory(Category category)
        { 
            var existingCategory = _db.Categories.FirstOrDefault(u => u.Id == category.Id);
            if(existingCategory != null)
            {
                existingCategory.Name = category.Name;
                _db.SaveChanges();
            }
            else
            {
                return false;
            }
            return true;
        }

        public bool DeleteCategory(Category category)
        {
            var existingCategory = _db.Categories.FirstOrDefault(u => u.Id == category.Id);
            if (existingCategory != null)
            {
                _db.Categories.Remove(existingCategory);
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
