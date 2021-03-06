﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TaskManager.Models.Activity
{
   public class ActivityEdit
    {
        [Required]
        public int ActivityId { get; set; }
        [Required]        
        public string Title { get; set; }
        [Required]        
        public string Description { get; set; }
    }
}
