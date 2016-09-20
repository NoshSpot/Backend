using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace NoshSpot.API.DTO
{
    public class OrderDTO
    {
        public int OrderId { get; set; }
        public int RestaurantId { get; set; }
        public int CustomerId { get; set; }

        public DateTime TimeStamp { get; set; }

        public IEnumerable<MenuItemDTO> MenuItems { get; set; }
    }
}