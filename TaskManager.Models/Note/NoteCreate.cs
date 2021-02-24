using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TaskManager.Data;

namespace TaskManager.Models.Note
{
    public class NoteCreate
    {
        [Key]
        public int NoteId { get; set; }
        [Required]
        [MinLength(2, ErrorMessage = "Please enter at least 2 characters")]
        [MaxLength(40, ErrorMessage = "Please enter less than 40 characters")]
        public string Text { get; set; }

<<<<<<< HEAD
        [Display(Name = "Created")]
=======
        [Display(Name ="Created")]
>>>>>>> 851f2c1931571450c702f0178161d0ec87c792f0
        public DateTimeOffset CreatedUtc { get; set; }

        [ForeignKey(nameof(Activity))]
        public int ActivityId { get; set; }
        // public virtual Activity Activity { get; set; }

        [ForeignKey(nameof(Todo))]
        public int TodoId { get; set; }
        public virtual Data.Todo Todo { get; set; }

<<<<<<< HEAD
        [ForeignKey(nameof(Category))]
        public int CategoryId { get; set; }
        //public virtual Category Category { get; set; }
=======

        [ForeignKey(nameof(Category))]
        public int CategoryId { get; set; }
        // public virtual Category Category { get; set; }
>>>>>>> 851f2c1931571450c702f0178161d0ec87c792f0

        [ForeignKey(nameof(ApplicationUser))]
        public string UserId { get; set; }
        public virtual ApplicationUser User { get; set; }
    }
}
