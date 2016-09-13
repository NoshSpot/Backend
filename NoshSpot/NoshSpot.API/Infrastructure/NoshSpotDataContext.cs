using NoshSpot.API.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace NoshSpot.API.Infrastructure
{
    public class NoshSpotDataContext: DbContext
    {
        public NoshSpotDataContext(): base("NoshSpot")
        {
                
        }

        public IDbSet<Category> Categories { get; set; }
        public IDbSet<Customer> Customers { get; set; }
        public IDbSet<MenuGroup> MenuGroups { get; set; }
        public IDbSet<MenuItem> MenuItems { get; set; }
        public IDbSet<Order> Orders { get; set; }
        public IDbSet<OrderItem> OrderItems { get; set; }
        public IDbSet<Payment> Payments { get; set; }
        public IDbSet<Restaurant> Restaurants { get; set; }
        public IDbSet<Review> Reviews { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Category>()
                        .HasMany(c => c.Restaurants)
                        .WithRequired(r => r.Category)
                        .HasForeignKey(r => r.RestaurantId);

            modelBuilder.Entity<Customer>()
                        .HasMany(c => c.Orders)
                        .WithRequired(o => o.Customer)
                        .HasForeignKey(o => o.CustomerId);

            modelBuilder.Entity<Customer>()
                        .HasMany(c => c.Reviews)
                        .WithRequired(r => r.Customer)
                        .HasForeignKey(r => r.CustomerId);

            // a menu group has many menu items
            modelBuilder.Entity<MenuGroup>()
                        .HasMany(mg => mg.MenuItems)
                        .WithRequired(mi => mi.MenuGroup)
                        .HasForeignKey(mi => mi.MenuGroupId);

            // a menu item has many order items
            modelBuilder.Entity<MenuItem>()
                        .HasMany(mi => mi.OrderItems)
                        .WithRequired(oi => oi.MenuItem)
                        .HasForeignKey(oi => oi.MenuItemId);

            // an order has many order items
            modelBuilder.Entity<Order>()
                        .HasMany(o => o.OrderItems)
                        .WithRequired(oi => oi.Order)
                        .HasForeignKey(oi => oi.OrderId);

        }
    }
}