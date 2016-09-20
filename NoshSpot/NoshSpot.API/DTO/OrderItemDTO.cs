using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace NoshSpot.API.DTO
{
    public class OrderItemDTO
    {
        public int OrderItemId { get; set; }
        public int MenuItemId { get; set; }
        public int OrderId { get; set; }

        public MenuItemDTO MenuItem { get; set; }
    }
}