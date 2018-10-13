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
                        MembershipType = "Regular",
                        MembershipFee = 100
                    },
                    new Membership
                    {
                        Id = 2,
                        Duration = 90,
                        MembershipType = "Express",
                        MembershipFee = 275
                    },
                    new Membership
                    {
                        Id = 3,
                        Duration = 180,
                        MembershipType = "Premium",
                        MembershipFee = 550
                    },
                    new Membership
                    {
                        Id = 4,
                        Duration = 360,
                        MembershipType = "Platinum",
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
                        Salary = 15,                        
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
                        Salary = 20,
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
                        Salary = 25,
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
                        Salary = 30,
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
                        PhoneNumber = "5139674587",
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
                        PhoneNumber = "5139374331",
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
                        PhoneNumber = "5132384344",
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
                        PhoneNumber = "5131480374",
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
                        PhoneNumber = "5139980986",
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
                        PhoneNumber = "5139980186",
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
                        PhoneNumber = "5132994224",
                        ZipCode = "45225",
                        JoinDate = new DateTime(2018, 09, 20),
                        Height = 165,
                        Weight = 70,
                        MembershipId = 1,
                        ScheduleId = 12
                    },
                    new Customer
                    {
                        Id = 8,
                        FirstName = "Jack",
                        LastName = "Miller",
                        BirthDate = new DateTime(1974, 03, 17),
                        Gender = "Male",
                        Email = "jm@gmail.com",
                        PhoneNumber = "5132554224",
                        ZipCode = "45225",
                        JoinDate = new DateTime(2018, 03, 20),
                        Height = 162,
                        Weight = 90,
                        MembershipId = 4,
                        ScheduleId = 10
                    },
                     new Customer
                    {
                        Id = 9,
                        FirstName = "Alex",
                        LastName = "Ferguson",
                        BirthDate = new DateTime(1966, 10, 18),
                        Gender = "Male",
                        Email = "saf@gmail.com",
                        PhoneNumber = "5442554224",
                        ZipCode = "45226",
                        JoinDate = new DateTime(2017, 03, 20),
                        Height = 150,
                        Weight = 60,
                        MembershipId = 3,
                        ScheduleId = 8
                    },
                     new Customer
                    {
                        Id = 10,
                        FirstName = "Jose",
                        LastName = "Mourinho",
                        BirthDate = new DateTime(1984, 08, 17),
                        Gender = "Male",
                        Email = "jmou@gmail.com",
                        PhoneNumber = "5132554004",
                        ZipCode = "45625",
                        JoinDate = new DateTime(2018, 05, 19),
                        Height = 162,
                        Weight = 80,
                        MembershipId = 1,
                        ScheduleId = 7
                    },
                     new Customer
                    {
                        Id = 11,
                        FirstName = "Alex",
                        LastName = "Morgan",
                        BirthDate = new DateTime(1990, 04, 17),
                        Gender = "Female",
                        Email = "am@gmail.com",
                        PhoneNumber = "5132553424",
                        ZipCode = "45228",
                        JoinDate = new DateTime(2018, 02, 20),
                        Height = 167,
                        Weight = 90,
                        MembershipId = 4,
                        ScheduleId = 3
                    },
                     new Customer
                    {
                        Id = 12,
                        FirstName = "Gal",
                        LastName = "Gadot",
                        BirthDate = new DateTime(1980, 08, 17),
                        Gender = "Female",
                        Email = "gg@gmail.com",
                        PhoneNumber = "5100554224",
                        ZipCode = "45225",
                        JoinDate = new DateTime(2018, 06, 20),
                        Height = 162,
                        Weight = 90,
                        MembershipId = 2,
                        ScheduleId = 5
                    },
                     new Customer
                    {
                        Id = 13,
                        FirstName = "Lady",
                        LastName = "Gaga",
                        BirthDate = new DateTime(1988, 03, 17),
                        Gender = "Female",
                        Email = "lg@gmail.com",
                        PhoneNumber = "5132094224",
                        ZipCode = "45229",
                        JoinDate = new DateTime(2018, 09, 20),
                        Height = 162,
                        Weight = 90,
                        MembershipId = 4,
                        ScheduleId = 9
                    },
                     new Customer
                    {
                        Id = 14,
                        FirstName = "Kylie",
                        LastName = "Jenner",
                        BirthDate = new DateTime(1997, 03, 17),
                        Gender = "Female",
                        Email = "kj@gmail.com",
                        PhoneNumber = "5132559824",
                        ZipCode = "45220",
                        JoinDate = new DateTime(2018, 06, 20),
                        Height = 162,
                        Weight = 90,
                        MembershipId = 4,
                        ScheduleId = 5
                    },
                     new Customer
                    {
                        Id = 15,
                        FirstName = "Stephen",
                        LastName = "Curry",
                        BirthDate = new DateTime(1989, 03, 17),
                        Gender = "Male",
                        Email = "sc@gmail.com",
                        PhoneNumber = "5138754224",
                        ZipCode = "45225",
                        JoinDate = new DateTime(2018, 01, 20),
                        Height = 190,
                        Weight = 90,
                        MembershipId = 3,
                        ScheduleId = 8
                    },
                     new Customer
                    {
                        Id =16,
                        FirstName = "Raheem",
                        LastName = "Sterling",                        
                        BirthDate = new DateTime(1996, 03, 09),
                        Gender = "Male",
                        Email = "rs@gmail.com",
                        PhoneNumber = "5139674587",
                        ZipCode = "45210",
                        JoinDate = new DateTime(2017, 12, 02),
                        Height = 176,
                        Weight = 95,
                        MembershipId = 2,
                        ScheduleId = 4                        
                    },
                    new Customer
                    {
                        Id = 17,
                        FirstName = "Gareth",
                        LastName = "Barry",
                        BirthDate = new DateTime(1992, 05, 09),
                        Gender = "Male",
                        Email = "gb@gmail.com",
                        PhoneNumber = "5166374331",
                        ZipCode = "45215",
                        JoinDate = new DateTime(2018, 11, 20),
                        Height = 155,
                        Weight = 65,
                        MembershipId = 3,
                        ScheduleId = 1
                    },
                    new Customer
                    {
                        Id = 18,
                        FirstName = "Priyanka",
                        LastName = "Chopra",
                        BirthDate = new DateTime(1985, 02, 11),
                        Gender = "Female",
                        Email = "pc@gmail.com",
                        PhoneNumber = "5132377344",
                        ZipCode = "45218",
                        JoinDate = new DateTime(2016, 09, 20),
                        Height = 165,
                        Weight = 65,
                        MembershipId = 4,
                        ScheduleId = 11
                    },
                    new Customer
                    {
                        Id = 19,
                        FirstName = "Kendall",
                        LastName = "Jenner",
                        BirthDate = new DateTime(1997, 03, 01),
                        Gender = "Female",
                        Email = "kenny@gmail.com",
                        PhoneNumber = "5130080374",
                        ZipCode = "45216",
                        JoinDate = new DateTime(2013, 09, 20),
                        Height = 152,
                        Weight = 62,
                        MembershipId = 1,
                        ScheduleId = 6
                    },
                    new Customer
                    {
                        Id = 20,
                        FirstName = "Bear",
                        LastName = "Grylls",
                        BirthDate = new DateTime(1989, 10, 11),
                        Gender = "Male",
                        Email = "bg@gmail.com",
                        PhoneNumber = "5139980906",
                        ZipCode = "45221",
                        JoinDate = new DateTime(2012, 06, 2),
                        Height = 182,
                        Weight = 98,
                        MembershipId = 4,
                        ScheduleId = 13
                    },
                    new Customer
                    {
                        Id = 21,
                        FirstName = "Chris",
                        LastName = "Martin",
                        BirthDate = new DateTime(1983, 10, 11),
                        Gender = "Male",
                        Email = "cm@gmail.com",
                        PhoneNumber = "5192980186",
                        ZipCode = "45229",
                        JoinDate = new DateTime(2015, 05, 12),
                        Height = 172,
                        Weight = 74,
                        MembershipId = 3,
                        ScheduleId = 10
                    },
                    new Customer
                    {
                        Id = 22,
                        FirstName = "Rakhi",
                        LastName = "Sawant",
                        BirthDate = new DateTime(1984, 09, 11),
                        Gender = "Female",
                        Email = "rs@gmail.com",
                        PhoneNumber = "5132990924",
                        ZipCode = "45225",
                        JoinDate = new DateTime(2016, 09, 20),
                        Height = 165,
                        Weight = 70,
                        MembershipId = 1,
                        ScheduleId = 6
                    },
                    new Customer
                    {
                        Id = 23,
                        FirstName = "John",
                        LastName = "Terry",
                        BirthDate = new DateTime(1999, 03, 17),
                        Gender = "Male",
                        Email = "jt@gmail.com",
                        PhoneNumber = "5137754224",
                        ZipCode = "45225",
                        JoinDate = new DateTime(2017, 03, 20),
                        Height = 162,
                        Weight = 90,
                        MembershipId = 1,
                        ScheduleId = 10
                    },
                     new Customer
                    {
                        Id = 24,
                        FirstName = "Cesc",
                        LastName = "Fabregas",
                        BirthDate = new DateTime(1982, 10, 18),
                        Gender = "Male",
                        Email = "sf@gmail.com",
                        PhoneNumber = "5422554224",
                        ZipCode = "45226",
                        JoinDate = new DateTime(2017, 03, 20),
                        Height = 150,
                        Weight = 60,
                        MembershipId = 3,
                        ScheduleId = 8
                    },
                     new Customer
                    {
                        Id = 25,
                        FirstName = "Paul",
                        LastName = "Pogba",
                        BirthDate = new DateTime(1987, 08, 17),
                        Gender = "Male",
                        Email = "pp@gmail.com",
                        PhoneNumber = "5132507004",
                        ZipCode = "45625",
                        JoinDate = new DateTime(2014, 05, 19),
                        Height = 162,
                        Weight = 80,
                        MembershipId = 1,
                        ScheduleId = 7
                    },
                     new Customer
                    {
                        Id = 26,
                        FirstName = "Alexandra",
                        LastName = "Martin",
                        BirthDate = new DateTime(1994, 04, 17),
                        Gender = "Female",
                        Email = "ama@gmail.com",
                        PhoneNumber = "5132553424",
                        ZipCode = "45228",
                        JoinDate = new DateTime(2015, 02, 20),
                        Height = 167,
                        Weight = 90,
                        MembershipId = 4,
                        ScheduleId = 3
                    },
                     new Customer
                    {
                        Id = 27,
                        FirstName = "Jennifer",
                        LastName = "Lopez",
                        BirthDate = new DateTime(1981, 08, 17),
                        Gender = "Female",
                        Email = "jl@gmail.com",
                        PhoneNumber = "5100994224",
                        ZipCode = "45228",
                        JoinDate = new DateTime(2017, 06, 20),
                        Height = 162,
                        Weight = 90,
                        MembershipId = 2,
                        ScheduleId = 9
                    },
                     new Customer
                    {
                        Id = 28,
                        FirstName = "Emma",
                        LastName = "Stone",
                        BirthDate = new DateTime(1993, 03, 17),
                        Gender = "Female",
                        Email = "es@gmail.com",
                        PhoneNumber = "5100094224",
                        ZipCode = "45221",
                        JoinDate = new DateTime(2014, 09, 20),
                        Height = 162,
                        Weight = 90,
                        MembershipId = 4,
                        ScheduleId = 9
                    },
                     new Customer
                    {
                        Id = 29,
                        FirstName = "Anna",
                        LastName = "Hathway",
                        BirthDate = new DateTime(1998, 03, 17),
                        Gender = "Female",
                        Email = "ah@gmail.com",
                        PhoneNumber = "5132999824",
                        ZipCode = "45220",
                        JoinDate = new DateTime(2018, 06, 20),
                        Height = 162,
                        Weight = 90,
                        MembershipId = 4,
                        ScheduleId = 11
                    },
                     new Customer
                    {
                        Id = 30,
                        FirstName = "Lebron",
                        LastName = "James",
                        BirthDate = new DateTime(1983, 03, 17),
                        Gender = "Male",
                        Email = "lj@gmail.com",
                        PhoneNumber = "5130954224",
                        ZipCode = "45225",  
                        JoinDate = new DateTime(2014, 01, 20),
                        Height = 190,
                        Weight = 90,
                        MembershipId = 3,
                        ScheduleId = 8
                    }
                    );

                context.SaveChanges();
            }
        }
    }
}
