using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Linq;

namespace CoreCrud.Models
{
    /// <summary>
    /// Seed Data
    /// </summary>
    public class SeedData
    {
        /// <summary>
        /// Initializes the specified service provider.
        /// </summary>
        /// <param name="serviceProvider">The service provider.</param>
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


                // Lunch Boxes
                context.LunchBox.AddRange(
                    new LunchBox
                    {
                        Id = 1,
                        LunchBoxName = "Mickey Mouse Lunch Box 1",
                        IsMicrowaveSafe = true,
                        Description = "For kids in 6 to 10 yrs",
                        Weight = 4.0F,
                        Price = 7.99M,
                        ManufacturerId = 1
                    },

                    new LunchBox
                    {
                        Id = 2,
                        LunchBoxName = "Tom and Jerry Lunch Box 5",
                        SoldDate = DateTime.Parse("2018-6-14"),
                        IsMicrowaveSafe = false,
                        Description = "For kids in 11 to 15 yrs",
                        Weight = 4.5F,
                        Price = 5.99M,
                        ManufacturerId = 2
                    },

                    new LunchBox
                    {
                        Id = 3,
                        LunchBoxName = "Star Lunch Box 4",
                        IsMicrowaveSafe = true,
                        Description = "For kids in 16 to 20 yrs",
                        Weight = 5.5F,
                        Price = 9.99M,
                        ManufacturerId = 1
                    },

                    new LunchBox
                    {
                        Id = 4,
                        LunchBoxName = "Office Lunch Box 4",
                        SoldDate = DateTime.Parse("2018-11-29"),
                        IsMicrowaveSafe = true,
                        Description = "For Office",
                        Weight = 6.5F,
                        Price = 12.99M,
                        ManufacturerId = 1
                    },

                    new LunchBox
                    {
                        Id = 5,
                        LunchBoxName = "Mickey Mouse Lunch Box 2",
                        IsMicrowaveSafe = true,
                        Description = "For kids in 6 to 10 yrs",
                        Weight = 4.0F,
                        Price = 7.99M,
                        ManufacturerId = 3
                    },

                    new LunchBox
                    {
                        Id = 6,
                        LunchBoxName = "Tom and Jerry Lunch Box 1",
                        IsMicrowaveSafe = false,
                        Description = "For kids in 11 to 15 yrs",
                        Weight = 4.5F,
                        Price = 5.99M,
                        ManufacturerId = 2
                    },

                    new LunchBox
                    {
                        Id = 7,
                        LunchBoxName = "Star Lunch Box 5",
                        SoldDate = DateTime.Parse("2018-9-19"),
                        IsMicrowaveSafe = true,
                        Description = "For kids in 16 to 20 yrs",
                        Weight = 5.5F,
                        Price = 9.99M,
                        ManufacturerId = 1
                    },

                    new LunchBox
                    {
                        Id = 8,
                        LunchBoxName = "Office Lunch Box 5",
                        SoldDate = DateTime.Parse("2018-11-29"),
                        IsMicrowaveSafe = true,
                        Description = "For Office",
                        Weight = 6.5F,
                        Price = 12.99M,
                        ManufacturerId = 1
                    },

                    new LunchBox
                    {
                        Id = 9,
                        LunchBoxName = "Mickey Mouse Lunch Box 3",
                        IsMicrowaveSafe = true,
                        Description = "For kids in 6 to 10 yrs",
                        Weight = 4.0F,
                        Price = 7.99M,
                        ManufacturerId = 4
                    },

                    new LunchBox
                    {
                        Id = 10,
                        LunchBoxName = "Tom and Jerry Lunch Box 2",
                        IsMicrowaveSafe = false,
                        Description = "For kids in 11 to 15 yrs",
                        Weight = 4.5F,
                        Price = 5.99M,
                        ManufacturerId = 2
                    },

                    new LunchBox
                    {
                        Id = 11,
                        LunchBoxName = "Star Lunch Box 1",
                        SoldDate = DateTime.Parse("2018-9-19"),
                        IsMicrowaveSafe = true,
                        Description = "For kids in 16 to 20 yrs",
                        Weight = 5.5F,
                        Price = 9.99M,
                        ManufacturerId = 1
                    },

                    new LunchBox
                    {
                        Id = 12,
                        LunchBoxName = "Office Lunch Box 1",
                        IsMicrowaveSafe = true,
                        Description = "For Office",
                        Weight = 6.5F,
                        Price = 12.99M,
                        ManufacturerId = 3
                    },

                    new LunchBox
                    {
                        Id = 13,
                        LunchBoxName = "Mickey Mouse Lunch Box 4",
                        IsMicrowaveSafe = true,
                        Description = "For kids in 6 to 10 yrs",
                        Weight = 4.0F,
                        Price = 7.99M,
                        ManufacturerId = 1
                    },

                    new LunchBox
                    {
                        Id = 14,
                        LunchBoxName = "Tom and Jerry Lunch Box 3",
                        IsMicrowaveSafe = false,
                        Description = "For kids in 11 to 15 yrs",
                        Weight = 4.5F,
                        Price = 5.99M,
                        ManufacturerId = 2
                    },

                    new LunchBox
                    {
                        Id = 15,
                        LunchBoxName = "Star Lunch Box 2",
                        SoldDate = DateTime.Parse("2018-9-19"),
                        IsMicrowaveSafe = true,
                        Description = "For kids in 16 to 20 yrs",
                        Weight = 5.5F,
                        Price = 9.99M,
                        ManufacturerId = 1
                    },

                    new LunchBox
                    {
                        Id = 16,
                        LunchBoxName = "Office Lunch Box 2",
                        IsMicrowaveSafe = true,
                        Description = "For Office",
                        Weight = 6.5F,
                        Price = 12.99M,
                        ManufacturerId = 1
                    },

                    new LunchBox
                    {
                        Id = 17,
                        LunchBoxName = "Mickey Mouse Lunch Box 5",
                        IsMicrowaveSafe = true,
                        Description = "For kids in 6 to 10 yrs",
                        Weight = 4.0F,
                        Price = 7.99M,
                        ManufacturerId = 2
                    },

                    new LunchBox
                    {
                        Id = 18,
                        LunchBoxName = "Tom and Jerry Lunch Box 4",
                        SoldDate = DateTime.Parse("2018-6-14"),
                        IsMicrowaveSafe = false,
                        Description = "For kids in 11 to 15 yrs",
                        Weight = 4.5F,
                        Price = 5.99M,
                        ManufacturerId = 3
                    },

                    new LunchBox
                    {
                        Id = 19,
                        LunchBoxName = "Star Lunch Box 3",
                        IsMicrowaveSafe = true,
                        Description = "For kids in 16 to 20 yrs",
                        Weight = 5.5F,
                        Price = 9.99M,
                        ManufacturerId = 4
                    },

                    new LunchBox
                    {
                        Id = 20,
                        LunchBoxName = "Office Lunch Box 3",
                        IsMicrowaveSafe = true,
                        Description = "For Office",
                        Weight = 6.5F,
                        Price = 12.99M,
                        ManufacturerId = 2
                    }
                );


                // Manufacturers
                context.LunchBoxManufacturer.AddRange(
                    new LunchBoxManufacturer
                    {
                        Id = 1,
                        Name = "Timbler Co.",
                        EstablishedOn = DateTime.Parse("2011-11-29"),
                        IsSellingOnline = true,
                        Location = "Coloumbus",
                        CellPhone = "5139679410",
                        SalesRevenue = 9000.00M,                        
                    },

                    new LunchBoxManufacturer
                    {
                        Id = 2,
                        Name = "Tupperware",
                        EstablishedOn = DateTime.Parse("2014-11-29"),
                        IsSellingOnline = false,
                        Location = "Sidney",
                        CellPhone = "5139679410",
                        SalesRevenue = 4500.00M,
                    },

                    new LunchBoxManufacturer
                    {
                        Id = 3,
                        Name = "Shane Vormer",
                        EstablishedOn = DateTime.Parse("2016-02-01"),
                        IsSellingOnline = false,
                        Location = "Blue Ash",
                        CellPhone = "5139679411",
                        SalesRevenue = 1500.00M,
                    },

                    new LunchBoxManufacturer
                    {
                        Id = 4,
                        Name = "New Egg Shell",
                        EstablishedOn = DateTime.Parse("2018-09-21"),
                        IsSellingOnline = true,
                        Location = "Calhoun",
                        CellPhone = "5139679412",
                        SalesRevenue = 7500.00M,
                    }
                    );
                context.SaveChanges();
            }
        }
    }
}
