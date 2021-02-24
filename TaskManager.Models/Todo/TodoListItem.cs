using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TaskManager.Models.Todo
{
    public class TodoListItem
    {
        public int TodoId { get; set; }
        public string Title { get; set; }
        public DateTime DueDate { get; set; }
        public bool Complete { get; set; }
    }
}
