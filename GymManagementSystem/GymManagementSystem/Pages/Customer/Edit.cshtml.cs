using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using GymManagementSystem.Data;
using GymManagementSystem.Models;

namespace GymManagementSystem.Pages.Customer
{
    public class EditModel : PageModel
    {
        private readonly GymManagementSystem.Data.GymDbContext _context;

        public EditModel(GymManagementSystem.Data.GymDbContext context)
        {
            _context = context;
        }

        [BindProperty]
        public Models.Customer Customer { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            Customer = await _context.Customers
                .Include(c => c.Membership)
                .Include(c => c.Schedule).FirstOrDefaultAsync(m => m.Id == id);

            if (Customer == null)
            {
                return NotFound();
            }
           ViewData["MembershipId"] = new SelectList(_context.Membership, "Id", "Id");
           ViewData["ScheduleId"] = new SelectList(_context.Schedules, "Id", "Id");
            return Page();
        }

        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                ViewData["MembershipId"] = new SelectList(_context.Membership, "Id", "Id");
                ViewData["ScheduleId"] = new SelectList(_context.Schedules, "Id", "Id");
                return Page();
            }

            _context.Attach(Customer).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!CustomerExists(Customer.Id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return RedirectToPage("./Index");
        }

        private bool CustomerExists(int id)
        {
            return _context.Customers.Any(e => e.Id == id);
        }
    }
}
