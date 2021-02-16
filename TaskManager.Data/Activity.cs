using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TaskManager.Data
{
    public class Activity
    {

        [Key]
        public Guid ActivityId { get; set; }

        [ForeignKey(nameof(Category))]
        public Guid CategoryId { get; set; }
        public virtual Category Category { get; set; }

        [Required]
        public Guid UserId { get; set; }

        [Required]
        public string Title { get; set; }

        [Required]
        public string Description { get; set; }

        
    }
}
