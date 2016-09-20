using AutoMapper;
using NoshSpot.API.DTO;
using NoshSpot.API.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;
using System.Web.Routing;

namespace NoshSpot.API
{
    public class WebApiApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {
            GlobalConfiguration.Configure(WebApiConfig.Register);

            SetupMaps();
        }

        private void SetupMaps()
        {
            Mapper.CreateMap<Restaurant, RestaurantDTO>();
            Mapper.CreateMap<Category, CategoryDTO>();
            Mapper.CreateMap<Order, OrderDTO>()
                .ForMember("MenuItems", opt => opt.MapFrom(src => src.OrderItems.Select(oi => oi.MenuItem)));
            Mapper.CreateMap<OrderItem, OrderItemDTO>();
            Mapper.CreateMap<MenuItem, MenuItemDTO>();
        }
    }
}
