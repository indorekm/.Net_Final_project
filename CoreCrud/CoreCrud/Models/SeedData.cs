using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CoreCrud.Models
{
    public class SeedData
    {
        public static void Initialize(IServiceProvider serviceProvider)
        {
            using (var context = new CoreCrudContext(
                serviceProvider.GetRequiredService<DbContextOptions<CoreCrudContext>>()))
            {
                // Look for any data recieved from DB.
                if (context.LunchBox.Any() || context.LunchBoxManufacturer.Any())
                {
                    return;   // DB has been seeded
                }

                context.LunchBox.AddRange(
                    new LunchBox
                    {
                        Id = 1,
                        LunchBoxName = "Mickey Mouse Lunch Box",
                        SoldDate = DateTime.Parse("2017-3-13"),
                        IsMicrowaveSafe = true,
                        Description = "For kids in 6 to 10 yrs",
                        Weight = 4.0F,
                        Price = 7.99M,
                        ManufacturerId = 1
                    },

                    new LunchBox
                    {
                        Id = 2,
                        LunchBoxName = "Tom and Jerry Lunch Box",
                        SoldDate = DateTime.Parse("2018-6-14"),
                        IsMicrowaveSafe = false,
                        Description = "For kids in 11 to 15 yrs",
                        Weight = 4.5F,
                        Price = 5.99M,
                        ManufacturerId = 1
                    },

                    new LunchBox
                    {
                        Id = 3,
                        LunchBoxName = "Star Lunch Box",
                        SoldDate = DateTime.Parse("2018-9-19"),
                        IsMicrowaveSafe = true,
                        Description = "For kids in 16 to 20 yrs",
                        Weight = 5.5F,
                        Price = 9.99M,
                        ManufacturerId = 1
                    },

                    new LunchBox
                    {
                        Id = 4,
                        LunchBoxName = "Office Lunch Box",
                        SoldDate = DateTime.Parse("2018-11-29"),
                        IsMicrowaveSafe = true,
                        Description = "For Office",
                        Weight = 6.5F,
                        Price = 12.99M,
                        ManufacturerId = 1
                    }
                );

                context.LunchBoxManufacturer.AddRange(
                    new LunchBoxManufacturer
                    {
                        Id = 1,
                        Name = "Timbler Co.",
                        EstablishedOn = DateTime.Parse("2011-11-29"),
                        IsSellingOnline = true,
                        Location = "Coloumbus",
                        SalesRevenue = 1000.00M,                        
                    }
                    );
                context.SaveChanges();
            }
        }
    }
}
