using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TaskManager.Data;

namespace TaskManager.Models.Todo
{
    public class TodoCreate
    {
        [Required]
        public DateTime DueDate { get; set; }

       // [ForeignKey(nameof(Activity))]
      //  public int ActivityId { get; set; }
        // public virtual Data.Activity Activity { get; set; }

       // public string Title { get; set; }
    }
}
