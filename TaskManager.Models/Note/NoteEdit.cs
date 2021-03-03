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
    public class NoteEdit
    {
        [Required]
        public int NoteId { get; set; }

        [Required]
        public string Text { get; set; }

       
        public int ActivityId { get; set; }


        public int TodoId { get; set; }
    }
}
