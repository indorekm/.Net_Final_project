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
    public class ScheduleAsDaysModel : PageModel
    {
        private GymDbContext _context;

        public ScheduleAsDaysModel(GymDbContext context)
        {
            _context = context;
        }

        public List<Tuple<System.DayOfWeek, List<Models.Schedule>>> Schedules { get; set; }

        public void OnGet()
        {
            Schedules = _context.Schedules
                .Include(s => s.Trainer)
                .GroupBy(s => new { s.Day })
                .OrderBy(s => s.Key.Day)
                .Select(s => Tuple.Create(s.Key.Day, s.ToList())).ToList();            
        }
    }
}