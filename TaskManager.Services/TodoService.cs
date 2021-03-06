using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TaskManager.Models.Todo;
using TaskManager.Data;
using System.Web.Http;

namespace TaskManager.Services
{
    public class TodoService
    {
        private readonly Guid _userId;

        public TodoService(Guid userId)
        {
            _userId = userId;
        }

        public bool CreateTodo(TodoCreate model)
        {
            var entity =
                new Todo()
                {
                    DueDate = model.DueDate,
                    Complete = false,
                    UserId = _userId,
                    ActivityId = model.ActivityId,
                };

            using (var ctx = new ApplicationDbContext())
            {
                ctx.Todos.Add(entity);
                return ctx.SaveChanges() == 1;
            }
        }

        public IEnumerable<TodoListItem> GetTodos()
        {
            using(var ctx = new ApplicationDbContext())
            {
                var query =
                    ctx
                    .Todos
                    .Where(e => e.UserId == _userId)
                    .Select(
                        e =>
                        new TodoListItem
                        {
                            TodoId = e.TodoId,
                            Title = e.Activity.Title,
                            DueDate = e.DueDate,
                            Complete = e.Complete,
                        }
                        );
                return query.ToArray();
            }
        }

        public IEnumerable<TodoListItem> GetIncompleteTodos()
        {
            using (var ctx = new ApplicationDbContext())
            {
                var query =
                    ctx
                    .Todos
                    .Where(e => e.UserId == _userId && e.Complete ==false)
                    .Select(
                        e =>
                        new TodoListItem
                        {
                            TodoId = e.TodoId,
                            Title = e.Activity.Title,
                            DueDate = e.DueDate,
                            Complete = e.Complete,
                        }
                        );
                return query.ToArray();
            }
        }
        public IEnumerable<TodoListItem> GetTodaysTodos()
        {
            using (var ctx = new ApplicationDbContext())
            {
                var query =
                    ctx
                    .Todos
                    .Where(e => e.UserId == _userId && e.DueDate == DateTime.Today)
                    .Select(
                        e =>
                        new TodoListItem
                        {
                            TodoId = e.TodoId,
                            Title = e.Activity.Title,
                            DueDate = e.DueDate,
                            Complete = e.Complete,
                        }
                        );
                return query.ToArray();
            }
        }

        public TodoDetail GetTodoById(int id)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity =
                    ctx
                    .Todos
                    .Single(e => e.TodoId == id && e.UserId == _userId);
                return
                    new TodoDetail
                    {
                        TodoId = entity.TodoId,
                        Title = entity.Activity.Title,
                        Description = entity.Activity.Description,
                        DueDate = entity.DueDate,
                        Complete = entity.Complete
                    };
            }
        }

        
        public bool UpdateTodo(TodoEdit model)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity =
                    ctx
                    .Todos
                    .Single(e => e.TodoId == model.TodoId && e.UserId == _userId);

                entity.DueDate = model.DueDate;
                entity.Complete = model.Complete;

                return ctx.SaveChanges() == 1;
            }
        }

        public bool DeleteTodo(int id)
        {
            using(var ctx = new ApplicationDbContext())
            {
                var entity =
                    ctx
                    .Todos
                    .Single(e => e.TodoId == id && e.UserId == _userId);

                ctx.Todos.Remove(entity);

                return ctx.SaveChanges() == 1;
            }
        }
    }
}
