﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TaskManager.Data;
using TaskManager.Models;
using TaskManager.Models.Category;

namespace TaskManager.Services
{
    public class CategoryService
    {
        public bool CreateCategory(CategoryCreate category)
        {
            var Entity = new Category
            {
                CategoryId = category.CategoryId,
                Title = category.Title,
                Description= category.Description
            };

            using (var ctx = new ApplicationDbContext())
            {
                ctx.Categories.Add(Entity);
                return ctx.SaveChanges() == 1;
            }
        }

        public IEnumerable<CategoryListItem> GetCategories()
        {
            using (var ctx = new ApplicationDbContext())
            {
                var query =
                    ctx
                    .Categories
                    .Select(c => new CategoryListItem
                    {
                        CategoryId = c.CategoryId,
                        Title = c.Title,
                        Description = c.Description
                    }).ToList();
                return query;
            }
        }

        public CategoryListItem GetCategoryById(int Id)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity =
                    ctx
                    .Categories
                    .Single(e => e.CategoryId == Id);

                return new CategoryListItem
                {
                  //  CategoryId = entity.CategoryId,
                    Title = entity.Title,
                       Description = entity.Description
                       // .Single(entity => new ActivityListItem)
                };
            }
        }

        public bool UpdateCategory(CategoryEdit categoryEdit)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var Category =
                    ctx
                    .Categories
                    .SingleOrDefault(c => c.CategoryId == categoryEdit.CategoryId);

                Category.Title = categoryEdit.Title;
                Category.Description = categoryEdit.Description;

                return ctx.SaveChanges() == 1;
            }
        }

        public bool DeleteCategory(int Id)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var Category =
                   ctx
                   .Categories
                   .SingleOrDefault(c => c.CategoryId == Id);

                ctx.Categories.Remove(Category);

                return ctx.SaveChanges() == 1;
            }
        }
    }
}