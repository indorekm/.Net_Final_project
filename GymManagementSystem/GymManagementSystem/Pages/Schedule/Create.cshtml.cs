using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using GymManagementSystem.Models;

namespace GymManagementSystem.Pages.Schedule
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
            ViewData["TrainerId"] = new SelectList(_context.Trainers, "Id", "Name");
            ViewData["Day"] = new SelectList(Constant.GetDaysOfWeek());
            return Page();
        }

        [BindProperty]
        public Models.Schedule Schedule { get; set; }

        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                ViewData["TrainerId"] = new SelectList(_context.Trainers, "Id", "Name");
                ViewData["Day"] = new SelectList(Constant.GetDaysOfWeek());
                return Page();
            }

            _context.Schedules.Add(Schedule);
            await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }
    }
}