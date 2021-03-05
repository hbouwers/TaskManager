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

        [ForeignKey(nameof(Activity))]
        public int ActivityId { get; set; }
        public virtual Activity Activity { get; set; }

        public Guid UserId { get; set; }

        [Required]
        public string Text { get; set; }

        public DateTimeOffset CreatedUtc { get; set; }
    }
}
