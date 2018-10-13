using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using GymManagementSystem.Data;
using GymManagementSystem.Models;

namespace GymManagementSystem.Pages.Customer
{
    public class CreateModel : PageModel
    {
        private readonly GymManagementSystem.Data.GymDbContext _context;

        public CreateModel(GymManagementSystem.Data.GymDbContext context)
        {
            _context = context;
        }

        public IActionResult OnGet()
        {
        ViewData["MembershipId"] = new SelectList(_context.Membership, "Id", "MembershipType");
                ViewData["ScheduleId"] = new SelectList(_context.Schedules, "Id", "Description");
            return Page();
        }

        [BindProperty]
        public Models.Customer Customer { get; set; }

        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                ViewData["MembershipId"] = new SelectList(_context.Membership, "Id", "MembershipType");
                ViewData["ScheduleId"] = new SelectList(_context.Schedules, "Id", "Description");
                return Page();
            }

            _context.Customers.Add(Customer);
            await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }
    }
}