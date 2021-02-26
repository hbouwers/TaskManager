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
        public int ActivityId { get; set; }

        [ForeignKey(nameof(Category))]
        //changed from GUID to int bc type did not match was GUID -> to int, needed to be int -> int
        public int CategoryId { get; set; }
        public virtual Category Category { get; set; }

        [Required]
       // public Guid UserId { get; set; }
        public string UserId { get; set; }

        [Required]
        public string Title { get; set; }

        [Required]
        public string Description { get; set; }

        
    }
}
