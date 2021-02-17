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
        [Required]
        public string Text { get; set; }
    }
}
