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
    public class ActiveCustomersModel : PageModel
    {
        private GymDbContext _context;

        public ActiveCustomersModel(GymDbContext context)
        {
            _context = context;
        }

        public IList<Models.Customer> Customers { get; set; }

        public void OnGet()
        {
            var allCustomers = _context.Customers.Include(c => c.Membership).Include(c => c.Schedule).OrderBy(c=> c.Name).ToList();
            
            // TODO: logic to find active customers

            Customers = allCustomers;
        }
    }
}