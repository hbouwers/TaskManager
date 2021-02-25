using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TaskManager.Data
{
    public class Note
    {
        [Key]
        public int NoteId { get; set; }

        [Required]
        public string Text { get; set; }
        public DateTimeOffset CreatedUtc { get; set; }

        [ForeignKey(nameof (Activity))]
        public int ActivityId { get; set; }
        public virtual Activity Activity { get; set; }

        [ForeignKey(nameof(Todo))]
        public int TodoId { get; set; }
        public virtual Todo Todo { get; set; }

        [ForeignKey(nameof(Category))]
        public int CategoryId { get; set; }
        public virtual Category Category { get; set; }

        [ForeignKey(nameof(User))]
        //changed from GUID to string bc type does not match
        //by default UserID is a string.
        public string UserId { get; set; }
        public virtual ApplicationUser User { get; set; }
        //Guid.Parse(User.Identity.GetUserId()) comes back as a string by default. 
    }
}
