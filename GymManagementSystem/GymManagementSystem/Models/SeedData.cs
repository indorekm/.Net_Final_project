using GymManagementSystem.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GymManagementSystem.Models
{
    public class SeedData
    {
        /// <summary>
        /// Initializes the specified service provider.
        /// </summary>
        /// <param name="serviceProvider">The service provider.</param>
        public static void Initialize(IServiceProvider serviceProvider)
        {
            using (var context = new GymDbContext(
                serviceProvider.GetRequiredService<DbContextOptions<GymDbContext>>()))
            {
                // Look for any data recieved from DB.
                if (context.Schedules.Any() && context.Membership.Any())
                {
                    return;   // DB has been seeded
                }

                // Add Schedules
                context.Schedules.AddRange(
                    new Schedule
                    {
                        Id = 1,
                        Day = DayOfWeek.Monday,
                        StartTime = new DateTime(1, 1, 1, 7, 0, 0), // consider only time and ignore days
                        EndTime = new DateTime(1, 1, 1, 9, 0, 0), // consider only time and ignore days
                        ProgramName = "Yoga",
                        TrainerId = 1
                    },
                    new Schedule
                    {
                        Id = 2,
                        Day = DayOfWeek.Monday,
                        StartTime = new DateTime(1, 1, 1, 8, 0, 0), // consider only time and ignore days
                        EndTime = new DateTime(1, 1, 1, 10, 0, 0), // consider only time and ignore days
                        ProgramName = "Zumba",
                        TrainerId = 2
                    },
                    new Schedule
                    {
                        Id = 3,
                        Day = DayOfWeek.Monday,
                        StartTime = new DateTime(1, 1, 1, 9, 0, 0), // consider only time and ignore days
                        EndTime = new DateTime(1, 1, 1, 12, 0, 0), // consider only time and ignore days
                        ProgramName = "Weight Training",
                        TrainerId = 3
                    },
                    new Schedule
                    {
                        Id = 4,
                        Day = DayOfWeek.Tuesday,
                        StartTime = new DateTime(1, 1, 1, 7, 0, 0), // consider only time and ignore days
                        EndTime = new DateTime(1, 1, 1, 9, 0, 0), // consider only time and ignore days
                        ProgramName = "Yoga",
                        TrainerId = 1
                    },
                    new Schedule
                    {
                        Id = 5,
                        Day = DayOfWeek.Tuesday,
                        StartTime = new DateTime(1, 1, 1, 8, 0, 0), // consider only time and ignore days
                        EndTime = new DateTime(1, 1, 1, 10, 0, 0), // consider only time and ignore days
                        ProgramName = "Zumba",
                        TrainerId = 2
                    },
                    new Schedule
                    {
                        Id = 6,
                        Day = DayOfWeek.Tuesday,
                        StartTime = new DateTime(1, 1, 1, 9, 0, 0), // consider only time and ignore days
                        EndTime = new DateTime(1, 1, 1, 12, 0, 0), // consider only time and ignore days
                        ProgramName = "Weight Training",
                        TrainerId = 3
                    },
                    new Schedule
                    {
                        Id = 7,
                        Day = DayOfWeek.Wednesday,
                        StartTime = new DateTime(1, 1, 1, 7, 0, 0), // consider only time and ignore days
                        EndTime = new DateTime(1, 1, 1, 9, 0, 0), // consider only time and ignore days
                        ProgramName = "Yoga",
                        TrainerId = 1
                    },
                    new Schedule
                    {
                        Id = 8,
                        Day = DayOfWeek.Wednesday,
                        StartTime = new DateTime(1, 1, 1, 8, 0, 0), // consider only time and ignore days
                        EndTime = new DateTime(1, 1, 1, 10, 0, 0), // consider only time and ignore days
                        ProgramName = "Zumba",
                        TrainerId = 2
                    },
                    new Schedule
                    {
                        Id = 9,
                        Day = DayOfWeek.Wednesday,
                        StartTime = new DateTime(1, 1, 1, 9, 0, 0), // consider only time and ignore days
                        EndTime = new DateTime(1, 1, 1, 12, 0, 0), // consider only time and ignore days
                        ProgramName = "Weight Training",
                        TrainerId = 3
                    },
                    new Schedule
                    {
                        Id = 10,
                        Day = DayOfWeek.Thursday,
                        StartTime = new DateTime(1, 1, 1, 7, 0, 0), // consider only time and ignore days
                        EndTime = new DateTime(1, 1, 1, 9, 0, 0), // consider only time and ignore days
                        ProgramName = "Yoga",
                        TrainerId = 1
                    },
                    new Schedule
                    {
                        Id = 11,
                        Day = DayOfWeek.Friday,
                        StartTime = new DateTime(1, 1, 1, 8, 0, 0), // consider only time and ignore days
                        EndTime = new DateTime(1, 1, 1, 10, 0, 0), // consider only time and ignore days
                        ProgramName = "Zumba",
                        TrainerId = 2
                    },
                    new Schedule
                    {
                        Id = 12,
                        Day = DayOfWeek.Saturday,
                        StartTime = new DateTime(1, 1, 1, 9, 0, 0), // consider only time and ignore days
                        EndTime = new DateTime(1, 1, 1, 12, 0, 0), // consider only time and ignore days
                        ProgramName = "Weight Training",
                        TrainerId = 3
                    },
                    new Schedule
                    {
                        Id = 13,
                        Day = DayOfWeek.Sunday,
                        StartTime = new DateTime(1, 1, 1, 7, 0, 0), // consider only time and ignore days
                        EndTime = new DateTime(1, 1, 1, 12, 0, 0), // consider only time and ignore days
                        ProgramName = "Jumbo Circuit Training",
                        TrainerId = 4
                    }
                    );

                // Add Memberships
                context.Membership.AddRange(
                    new Membership
                    {
                        Id = 1,
                        Duration = 30,
                        MembershipType = "Monthly",
                        MembershipFee = 100
                    },
                    new Membership
                    {
                        Id = 2,
                        Duration = 90,
                        MembershipType = "Quaterly",
                        MembershipFee = 275
                    },
                    new Membership
                    {
                        Id = 3,
                        Duration = 180,
                        MembershipType = "Half Yearly",
                        MembershipFee = 550
                    },
                    new Membership
                    {
                        Id = 4,
                        Duration = 360,
                        MembershipType = "Yearly",
                        MembershipFee = 1000
                    }
                    );

                // Add Trainers
                context.Trainers.AddRange(
                    new Trainer
                    {
                        Id = 1,
                        FirstName = "John",
                        LastName = "Dan",
                        BirthDate = new DateTime(1985, 03, 15),
                        Gender = "Male",
                        StartDate = new DateTime(2012, 06, 01),
                        Salary = 3500,                        
                        Specialty = "Yoga"
                    },
                    new Trainer
                    {
                        Id = 2,
                        FirstName = "Martha",
                        LastName = "Davis",
                        BirthDate = new DateTime(1995, 09, 24),
                        Gender = "Female",
                        StartDate = new DateTime(2017, 01, 15),
                        Salary = 4500,
                        Specialty = "Zumba"
                    },
                    new Trainer
                    {
                        Id = 3,
                        FirstName = "Chang",
                        LastName = "Palva",
                        BirthDate = new DateTime(1988, 12, 09),
                        Gender = "Male",
                        StartDate = new DateTime(2016, 08, 01),
                        Salary = 5000,
                        Specialty = "Weight Training"
                    },
                    new Trainer
                    {
                        Id = 4,
                        FirstName = "Freat",
                        LastName = "Galvo",
                        BirthDate = new DateTime(1992, 02, 09),
                        Gender = "Male",
                        StartDate = new DateTime(2015, 05, 01),
                        Salary = 6000,
                        Specialty = "Jumbo Circuit Training"
                    }
                    );

                // Add Customer
                context.Customers.AddRange(
                    new Customer
                    {
                        Id =1,
                        FirstName = "Abelson",
                        LastName = "Hal",                        
                        BirthDate = new DateTime(1996, 05, 09),
                        Gender = "Male",
                        Email = "abe.hal@gmail.com",
                        PhoneNumber = "513-967-4587",
                        ZipCode = "45210",
                        JoinDate = new DateTime(2017, 12, 02),
                        Height = 176,
                        Weight = 95,
                        MembershipId = 3,
                        ScheduleId = 3                        
                    },
                    new Customer
                    {
                        Id = 2,
                        FirstName = "Barry",
                        LastName = "Dave",
                        BirthDate = new DateTime(1996, 05, 09),
                        Gender = "Male",
                        Email = "dav.bar@gmail.com",
                        PhoneNumber = "513-937-4331",
                        ZipCode = "45212",
                        JoinDate = new DateTime(2018, 01, 20),
                        Height = 155,
                        Weight = 65,
                        MembershipId = 4,
                        ScheduleId = 2
                    },
                    new Customer
                    {
                        Id = 3,
                        FirstName = "Carolla",
                        LastName = "Adam",
                        BirthDate = new DateTime(1998, 09, 11),
                        Gender = "Female",
                        Email = "carolaadma@gmail.com",
                        PhoneNumber = "513-238-4344",
                        ZipCode = "45216",
                        JoinDate = new DateTime(2018, 09, 20),
                        Height = 165,
                        Weight = 65,
                        MembershipId = 2,
                        ScheduleId = 1
                    },
                    new Customer
                    {
                        Id = 4,
                        FirstName = "Dali",
                        LastName = "Salvador",
                        BirthDate = new DateTime(1997, 11, 01),
                        Gender = "Female",
                        Email = "dali.sal@gmail.com",
                        PhoneNumber = "513-148-0374",
                        ZipCode = "45216",
                        JoinDate = new DateTime(2018, 09, 20),
                        Height = 152,
                        Weight = 62,
                        MembershipId = 2,
                        ScheduleId = 6
                    },
                    new Customer
                    {
                        Id = 5,
                        FirstName = "Fox",
                        LastName = "Gene",
                        BirthDate = new DateTime(1988, 10, 11),
                        Gender = "Male",
                        Email = "fox.gen@gmail.com",
                        PhoneNumber = "513-998-0986",
                        ZipCode = "45221",
                        JoinDate = new DateTime(2018, 06, 2),
                        Height = 182,
                        Weight = 98,
                        MembershipId = 4,
                        ScheduleId = 13
                    },
                    new Customer
                    {
                        Id = 6,
                        FirstName = "Martin",
                        LastName = "John",
                        BirthDate = new DateTime(1980, 10, 11),
                        Gender = "Male",
                        Email = "martin.john@gmail.com",
                        PhoneNumber = "513-998-0186",
                        ZipCode = "45221",
                        JoinDate = new DateTime(2018, 05, 12),
                        Height = 172,
                        Weight = 74,
                        MembershipId = 4,
                        ScheduleId = 13
                    },
                    new Customer
                    {
                        Id = 7,
                        FirstName = "Paula",
                        LastName = "Sten",
                        BirthDate = new DateTime(1983, 09, 11),
                        Gender = "Female",
                        Email = "paula.sten@gmail.com",
                        PhoneNumber = "513-299-4224",
                        ZipCode = "45225",
                        JoinDate = new DateTime(2018, 09, 20),
                        Height = 165,
                        Weight = 70,
                        MembershipId = 1,
                        ScheduleId = 12
                    }
                    );

                context.SaveChanges();
            }
        }
    }
}
