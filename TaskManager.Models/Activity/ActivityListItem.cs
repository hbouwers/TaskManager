using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TaskManager.Models
{
    public class ActivityListItem
    {



        public int ActivityId { get; set; }


        [Required]
        public string Title { get; set; }

        [Display(Name = "Created")]

        public DateTimeOffset CreatedUtc { get; set; }




    }
}