using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TaskManager.Models.Activity
{
   public class ActivityEdit
    {
        public int ActivityId { get; set; }
                
        public string Title { get; set; }
                
        public string Description { get; set; }
    }
}
