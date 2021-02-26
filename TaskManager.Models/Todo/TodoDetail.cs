using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TaskManager.Models.Todo
{
    public class TodoDetail
    {
        public int TodoId { get; set; }
        public DateTime DueDate { get; set; }
        public bool Complete { get; set; }

       // [ForeignKey(nameof(Activity))]
       // public int ActivityId { get; set; }
       // public virtual Data.Activity Activity { get; set; }
    }
}
