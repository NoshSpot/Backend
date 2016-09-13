using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace NoshSpot.API.Models
{
    public class MenuItem
    {
        public int MenuItemId { get; set; }
        public int MenuGroupId { get; set; }

        public string Name { get; set; }
        public string Description { get; set;}
        public decimal Price { get; set; }

        public virtual MenuGroup MenuGroup { get; set; }
        public virtual ICollection<OrderItem> OrderItems { get; set; }
    }
}