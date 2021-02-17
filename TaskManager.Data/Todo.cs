using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TaskManager.Data
{
    public class Todo
    {
        [Key]
        public int TodoId { get; set; }

        [ForeignKey(nameof(Activity))]
        public int ActivityId { get; set; }

        public virtual Activity Activity { get; set; }

        [Required]
        public Guid UserId { get; set; }

        [Required]
        public string Title { get; set; }

        [Required]
        public DateTime DueDate { get; set; }

        [Required]
        public bool Complete { get; set; }
    }
}
