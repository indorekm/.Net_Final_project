using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using GymManagementSystem.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;

namespace GymManagementSystem.Pages
{
    public class IndexModel : PageModel
    {
        private GymDbContext _context;

        public IndexModel(GymDbContext context)
        {
            _context = context;
        }

        // Customer stats
        public int TotalCustomers { get; set; }

        public int MaleCustomers { get; set; }

        public int FemaleCustomers { get; set; }

        public int CustomersWithYearlyMembership { get; set; }

        // Trainer stats
        public int TotalTrainers { get; set; }

        public int MaleTrainers { get; set; }

        public int FemaleTrainers { get; set; }

        public int FivePlusExperienceTrainers { get; set; }        

        public int TotalSchedules { get; set; }

        public List<Models.Trainer> Trainers { get; set; }

        public void OnGet()
        {
            // Customer stats
            var customers = _context.Customers.Include(cust => cust.Membership).Include(cust => cust.Schedule);
            TotalCustomers = customers.Count();
            MaleCustomers = customers.Where(cust => cust.Gender.ToLower() == "male").Count();
            FemaleCustomers = customers.Where(cust => cust.Gender.ToLower() == "female").Count();
            CustomersWithYearlyMembership = customers.Where(cust => cust.Membership.MembershipType == "Yearly").Count();

            // Trainers stats
            Trainers = _context.Trainers.ToList();
            TotalTrainers = Trainers.Count();
            MaleTrainers = Trainers.Where(t => t.Gender.ToLower() == "male").Count();
            FemaleTrainers = Trainers.Where(t => t.Gender.ToLower() == "female").Count();
            FivePlusExperienceTrainers = Trainers.Where(t => t.Experience > 5 * 365).Count();
            TotalSchedules = _context.Schedules.Count();
        }
    }
}
