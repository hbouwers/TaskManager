using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TaskManager.Models.Category
{
   public class CategoryDetail
    {
        public int CategoryId { get; set; }

        public string Title { get; set; }

        public string Description { get; set; }

        public int? ActivityId { get; set; }
    }
}
