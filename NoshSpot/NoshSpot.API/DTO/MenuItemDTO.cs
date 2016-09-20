using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace NoshSpot.API.DTO
{
    public class MenuItemDTO
    {
        public int MenuItemId { get; set; }
        public int MenuGroupId { get; set; }

        public string Name { get; set; }
        public string Description { get; set; }
        public decimal Price { get; set; }
    }
}