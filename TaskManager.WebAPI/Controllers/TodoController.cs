using Microsoft.AspNet.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;
using TaskManager.Models.Todo;
using TaskManager.Services;

namespace TaskManager.WebAPI.Controllers
{
    [Authorize]
    public class TodoController : ApiController
    {
        public IHttpActionResult Get()
        {
            TodoService todoService = CreateTodoService();
            var todos = todoService.GetTodos();
            return Ok(todos);
        }

        public IHttpActionResult Post(TodoCreate todo)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var service = CreateTodoService();

            if (!service.CreateTodo(todo))
                return InternalServerError();

            return Ok();
        }

        public IHttpActionResult Get(int id)
        {
            TodoService todoService = CreateTodoService();
            var todo = todoService.GetTodoById(id);
            return Ok(todo);
        }

        public IHttpActionResult Put(TodoEdit todo)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var service = CreateTodoService();

            if (!service.UpdateTodo(todo))
            {
                return InternalServerError();
            }

            return Ok();
        }

        public IHttpActionResult Delete(int id)
        {
            var service = CreateTodoService();

            if (!service.DeleteTodo(id))
            {
                return InternalServerError();
            }

            return Ok();
        }

        private TodoService CreateTodoService()
        {
            //var userId = Guid.Parse(User.Identity.GetUserId());
            var userId = (User.Identity.GetUserId());
            var todoService = new TodoService(userId);
            return todoService;
        }
    }
}