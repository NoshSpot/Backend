namespace NoshSpot.API.Migrations
{
    using Models;
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<NoshSpot.API.Infrastructure.NoshSpotDataContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
        }

        protected override void Seed(NoshSpot.API.Infrastructure.NoshSpotDataContext context)
        {
            string[] menuGroupTitles = new string[] { "Starters", "Appetizers", "Main", "Desserts", "Entrees", "Soups", "Salads", "Drinks", "Vegetarian", "Vegan", "Pescatarian", "Carnivore", "Omnivore" };

            //context.Categories.Add(new Models.Category { CategoryTitle = "Chinese" });
            var random = new Random();

            context.Categories.AddOrUpdate(
                c => c.CategoryTitle,
                new Models.Category { CategoryTitle = "Chinese" },
                new Models.Category { CategoryTitle = "American" },
                new Models.Category { CategoryTitle = "Italian" },
                new Models.Category { CategoryTitle = "Greek" },
                new Models.Category { CategoryTitle = "Mexican" },
                new Models.Category { CategoryTitle = "Indian" },
                new Models.Category { CategoryTitle = "Vietnamese" },
                new Models.Category { CategoryTitle = "British" },
                new Models.Category { CategoryTitle = "French" },
                new Models.Category { CategoryTitle = "Japanese" }
            );

            context.SaveChanges();

            if(context.Restaurants.Count() == 0)
            {
                for (int i = 0; i < 100; i++)
                {
                    context.Restaurants.AddOrUpdate(
                        r => r.Name,
                        new Models.Restaurant
                        {
                            Address = Faker.LocationFaker.StreetName(),
                            ZipCode = random.Next(10000, 100000),
                            Description = Faker.CompanyFaker.BS(),
                            Email = Faker.InternetFaker.Email(),
                            Name = Faker.CompanyFaker.Name(),
                            Telephone = Faker.PhoneFaker.Phone(),
                            WebSite = Faker.InternetFaker.Domain(),
                            CategoryId = random.Next(1, 11)
                        }
                    );
                }

                context.SaveChanges();


                foreach (var restaurant in context.Restaurants)
                {
                    int numberOfMenuGroups = random.Next(2, 7);

                    for (int i = 0; i < numberOfMenuGroups; i++)
                    {
                        var menuGroup = new MenuGroup
                        {
                            MenuGroupTitle = menuGroupTitles[random.Next(1, menuGroupTitles.Length)],
                            RestaurantId = restaurant.RestaurantId
                        };

                        int numberOfMenuItems = random.Next(3, 20);

                        for (int j = 0; j < numberOfMenuItems; j++)
                        {
                            menuGroup.MenuItems.Add(new MenuItem
                            {
                                Description = Faker.CompanyFaker.BS(),
                                Name = Faker.CompanyFaker.BS(),
                                Price = (decimal)Math.Round(random.NextDouble() * 100, 2)
                            });
                        }

                        restaurant.MenuGroups.Add(menuGroup);
                    }
                }

                context.SaveChanges();
            }
            
            //  This method will be called after migrating to the latest version.

            //  You can use the DbSet<T>.AddOrUpdate() helper extension method 
            //  to avoid creating duplicate seed data. E.g.
            //
            //    context.People.AddOrUpdate(
            //      p => p.FullName,
            //      new Person { FullName = "Andrew Peters" },
            //      new Person { FullName = "Brice Lambson" },
            //      new Person { FullName = "Rowan Miller" }
            //    );
            //
        }
    }
}
