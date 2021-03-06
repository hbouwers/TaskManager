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
        /// <summary>
        /// Get all Todos
        /// </summary>
        /// <returns></returns>
        public IHttpActionResult Get()
        {
            TodoService todoService = CreateTodoService();
            var todos = todoService.GetTodos();
            return Ok(todos);
        }
        /// <summary>
        /// Get All Incomplete Todos
        /// </summary>
        /// <returns></returns>
        /// 
        [Route("api/Todo/GetIncompleteTodos")]
        public IHttpActionResult GetIncompleteTodos()
        {
            TodoService todoService = CreateTodoService();
            var todos = todoService.GetIncompleteTodos();
            return Ok(todos);
        }
        /// <summary>
        /// Get Today's Todos
        /// </summary>
        /// <returns></returns>
        /// 
        [Route("api/Todo/GetTodaysTodos")]
        public IHttpActionResult GetTodaysTodos()
        {
            TodoService todoService = CreateTodoService();
            var todos = todoService.GetTodaysTodos();
            return Ok(todos);
        }
        /// <summary>
        /// Create a Todo
        /// </summary>
        /// <param name="todo"></param>
        /// <returns></returns>
        public IHttpActionResult Post(TodoCreate todo)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var service = CreateTodoService();

            if (!service.CreateTodo(todo))
                return InternalServerError();

            return Ok();
        }
        /// <summary>
        /// Get Todo by TodoId
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public IHttpActionResult Get(int id)
        {
            TodoService todoService = CreateTodoService();
            var todo = todoService.GetTodoById(id);
            return Ok(todo);
        }
        /// <summary>
        /// Update a Todo
        /// </summary>
        /// <param name="todo"></param>
        /// <returns></returns>
        /// 
        [Route("api/Todo/UpdateTodoId/{id}")]
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
        /// <summary>
        /// Delete Todo by TodoId
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
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
            var userId = Guid.Parse(User.Identity.GetUserId());
            var todoService = new TodoService(userId);
            return todoService;
        }
    }
}