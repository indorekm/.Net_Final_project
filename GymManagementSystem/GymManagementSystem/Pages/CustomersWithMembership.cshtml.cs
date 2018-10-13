using System;
using System.Collections.Generic;
using System.Linq;
using GymManagementSystem.Data;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;

namespace GymManagementSystem.Pages
{
    public class CustomersWithMembership : PageModel
    {
        private GymDbContext _context;
        
        public CustomersWithMembership(GymDbContext context)
        {
            _context = context;
        }

        public List<Tuple<string, List<Models.Customer>>> Customers { get; set; }

        public void OnGet()
        {
            Customers = _context.Customers
                 .Include(c => c.Membership)
                 .Include(c => c.Schedule)
                 .GroupBy(s => new { s.Membership.MembershipType })
                 .OrderBy(c => c.Key.MembershipType)
                 .Select(c => Tuple.Create(c.Key.MembershipType, c.ToList())).ToList();
        }
    }
}