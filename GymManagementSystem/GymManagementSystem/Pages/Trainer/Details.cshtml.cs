using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using GymManagementSystem.Data;
using GymManagementSystem.Models;

namespace GymManagementSystem.Pages.Trainer
{
    public class DetailsModel : PageModel
    {
        private readonly GymManagementSystem.Data.GymDbContext _context;

        public DetailsModel(GymManagementSystem.Data.GymDbContext context)
        {
            _context = context;
        }

        public Models.Trainer Trainer { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            Trainer = await _context.Trainers.FirstOrDefaultAsync(m => m.Id == id);

            if (Trainer == null)
            {
                return NotFound();
            }
            return Page();
        }
    }
}
