using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace NoshSpot.API.DTO
{
    public class RestaurantDTO
    {
        public int RestaurantId { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string Address { get; set; }
        public int ZipCode { get; set; }
        public string Telephone { get; set; }
        public string Email { get; set; }
        public string WebSite { get; set; }

        //TODO: Add Category
        public CategoryDTO Category { get; set; }
    }
}