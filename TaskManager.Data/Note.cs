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
        public string Text { get; set; }
        public string Title { get; set; }
        public bool IsComplete { get; set; }
        public DateTime DueDate { get; set; }
        public DateTimeOffset CreatedUtc { get; set; }

        [ForeignKey(nameof (Activity))]
        public int ActivityId { get; set; }
        public virtual Activity Activity { get; set; }


        //--------------------------------//
        // not 100% sure this is correct?//
        
        [ForeignKey(nameof(ApplicationUser))]
        public Guid UserId { get; set; }
        public virtual ApplicationUser User { get; set; }
    }
}
