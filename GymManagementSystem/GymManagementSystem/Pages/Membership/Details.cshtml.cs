using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using GymManagementSystem.Data;
using GymManagementSystem.Models;

namespace GymManagementSystem.Pages.Membership
{
    public class DetailsModel : PageModel
    {
        private readonly GymManagementSystem.Data.GymDbContext _context;

        public DetailsModel(GymManagementSystem.Data.GymDbContext context)
        {
            _context = context;
        }

        public Models.Membership Membership { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            Membership = await _context.Membership.FirstOrDefaultAsync(m => m.Id == id);

            if (Membership == null)
            {
                return NotFound();
            }
            return Page();
        }
    }
}
