﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TaskManager.Models.Note
{
    public class NoteListItem
    {
        public string Text { get; set; }

        public Guid UserId { get; set; }
    }
}
