using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TaskManager.Models.Todo
{
    public class TodoEdit
    {
        public int TodoId { get; set; }
        public DateTime DueDate { get; set; }
        public bool Complete { get; set; }
        public int ActivityId { get; set; }
    }
}
