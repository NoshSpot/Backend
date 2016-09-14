using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace NoshSpot.API.Models
{
    public class MenuGroup
    {
        public int MenuGroupId { get; set; }
        public int RestaurantId { get; set; }

        public string MenuGroupTitle { get; set; }
        
        public virtual ICollection<MenuItem> MenuItems { get; set; }

        public virtual Restaurant Restaurant { get; set; }
    }
}