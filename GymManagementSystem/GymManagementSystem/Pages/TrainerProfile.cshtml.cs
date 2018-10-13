using System;
using System.Collections.Generic;
using System.Linq;
using GymManagementSystem.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;

namespace GymManagementSystem.Pages
{
    public class TrainerProfileModel : PageModel
    {
        private GymDbContext _context;

        public TrainerProfileModel(GymDbContext context)
        {
            _context = context;
        }

        public Models.Trainer Trainer { get; set; }

        public List<Tuple<System.DayOfWeek, List<Models.Schedule>>> TrainerSchedules { get; set; }

        public IActionResult OnGet(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }            

            Trainer = _context.Trainers                
                .FirstOrDefault(t => t.Id == id);

            if (Trainer == null)
            {
                return NotFound();
            }

            TrainerSchedules = _context.Schedules
                .Include(s => s.Trainer)
                .Where(s => s.TrainerId == id)
                .GroupBy(s => new { s.Day })
                .OrderBy(s => s.Key.Day)
                .Select(s => Tuple.Create(s.Key.Day, s.ToList())).ToList();

            return Page();
        }
    }
}