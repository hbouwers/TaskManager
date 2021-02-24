using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TaskManager.Models.Category
{
    public class CategoryListItem
    {
        public int CategoryId { get; set; }

        public string Title { get; set; }

        public string Description { get; set; }
    }
}
