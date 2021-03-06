using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TaskManager.Models.Todo
{
    public class TodoEdit
    {
        [Required]
        public int TodoId { get; set; }
        [Required]
        public DateTime DueDate { get; set; }
        [Required]
        public bool Complete { get; set; }
        [Required]
        public int ActivityId { get; set; }
    }
}
