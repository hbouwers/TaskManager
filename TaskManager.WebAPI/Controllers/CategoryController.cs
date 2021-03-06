using Microsoft.AspNet.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using TaskManager.Models.Category;
using TaskManager.Services;

namespace TaskManager.WebAPI.Controllers
{
    public class CategoryController : ApiController
    {
        /// <summary>
        /// Create a Category
        /// </summary>
        /// <param name="category"></param>
        /// <returns></returns>
        public IHttpActionResult Post(CategoryCreate category)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var service = CreateCategoryService();

            if (!service.CreateCategory(category))
                return InternalServerError();

            return Ok();
        }
        /// <summary>
        /// Get All Categories
        /// </summary>
        /// <returns></returns>
        public IHttpActionResult Get()
        {
            CategoryService CategoryService = CreateCategoryService();
            var category = CategoryService.GetCategories();
            return Ok(category);
        }
        /// <summary>
        /// Get Category by CategoryId
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public IHttpActionResult Get(int id)
        {
            var categoryService = CreateCategoryService();
            var category = categoryService.GetCategoryById(id);
            if (category is null)
            {
                return InternalServerError();
            }
            return Ok(category);
        }
        /// <summary>
        /// Update a Category
        /// </summary>
        /// <param name="category"></param>
        /// <returns></returns>
        public IHttpActionResult Put(CategoryEdit category)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var service = CreateCategoryService();

            if (!service.UpdateCategory(category))
            {
                return InternalServerError();
            }
            return Ok();
        }
        /// <summary>
        /// Delete Category by CategoryId
        /// </summary>
        /// <param name="Id"></param>
        /// <returns></returns>
        public IHttpActionResult Delete(int Id)
        {
            var service = CreateCategoryService();

            if (!service.DeleteCategory(Id))
            {
                return InternalServerError();
            }

            return Ok();
        }
        private CategoryService CreateCategoryService()
        {
            var userId = Guid.Parse(User.Identity.GetUserId());
            var CategoryService = new CategoryService(userId);
            return CategoryService;
        }
    }
}
