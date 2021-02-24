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
        private readonly CategoryService _service = new CategoryService();

        public IHttpActionResult Post([FromBody] CategoryCreate category)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            if (category is null)
            {
                return BadRequest();
            }
            if (!_service.CreateCategory(category))
            {
                return InternalServerError();
            }
            return Ok();
        }
        public IHttpActionResult Get()
        {
            var categories = _service.GetCategories();
            if (categories is null)
            {
                return InternalServerError();
            }
            return Ok(categories);
        }
        public IHttpActionResult Get(int id)
        {
            var category = _service.GetCategoryById(id);
            if (category is null)
            {
                return InternalServerError();
            }
            return Ok(category);
        }

        public IHttpActionResult Put(CategoryEdit category)
        {
            if (category is null)
            {
                return BadRequest();
            }

            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (!_service.UpdateCategory(category))
            {
                return InternalServerError();
            }

            return Ok();
        }

        public IHttpActionResult Delete(int Id)
        {
            if (Id < 1)
            {
                return BadRequest("Value cannot be less than one.");
            }
            if (!_service.DeleteCategory(Id))
            {
                return InternalServerError();
            }
            return Ok();
        }
    }
}
