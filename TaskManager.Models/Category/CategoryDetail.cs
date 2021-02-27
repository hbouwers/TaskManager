using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TaskManager.Models.Category
{
   public class CategoryDetail
    {
       // public int CategoryId { get; set; }

        [Required]
        [MinLength(2, ErrorMessage = "Please enter at least 2 characters.")]
        [MaxLength(40, ErrorMessage = "There are too many characters in this field.")]
        public string Title { get; set; }

        public string Description { get; set; }

        [ForeignKey(nameof(Activity))]
        public int? ActivityId { get; set; }

        //public virtual ActivityListItem Activity { get; set; }
    }
}
