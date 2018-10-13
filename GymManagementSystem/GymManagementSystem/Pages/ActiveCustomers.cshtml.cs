using System.Collections.Generic;
using System.Linq;
using GymManagementSystem.Data;
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

        public IList<Models.Customer> ActiveCustomer { get; set; }

        public void OnGet()
        {
            ActiveCustomer = _context.Customers
                 .Include(c => c.Membership)
                 .Include(c => c.Schedule)
                 .OrderBy(c => c.Name).ToList();
        }
    }
}