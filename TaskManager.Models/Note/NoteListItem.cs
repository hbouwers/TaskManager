using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TaskManager.Models.Note
{
    public class NoteListItem
    {
       // [Key]
        public int NoteId { get; set; }

        [Required]
        public string Text { get; set; }
        public int? ActivityId { get; set; }
        public string Title { get; set; }
    }
}
