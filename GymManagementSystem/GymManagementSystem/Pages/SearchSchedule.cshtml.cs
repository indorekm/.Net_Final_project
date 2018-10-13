using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using GymManagementSystem.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;

namespace GymManagementSystem.Pages
{
    public class SearchScheduleModel : PageModel
    {
        private GymDbContext _context;

        public SearchScheduleModel(GymDbContext context)
        {
            _context = context;
        }
        
        [BindProperty]
        public int SearchTrainerId { get; set; }

        // WE WILL USE THIS PROPERTY TO TRACK IF A SEARCH HAS BEEN PERFORMED
        public bool SearchCompleted { get; set; }

        // WE WILL STORE THE RESULTS IN THIS PROPERTY
        public ICollection<Models.Schedule> SearchResults { get; set; }

        public void OnGet()
        {
            FillTrainerList();
            SearchCompleted = false;
        }

        private void FillTrainerList()
        {
            ViewData["Trainers"] = new SelectList(_context.Trainers, "Id", "Name");
        }

        public void OnPost()
        {
            // PERFORM SEARCH
            if (SearchTrainerId < 1)
            {
                // EXIT EARLY IF THERE IS NO SEARCH TERM PROVIDED
                FillTrainerList();
                return;
            }

            SearchResults = _context.Schedules
                                    .Include(s => s.Trainer)                                    
                                    .Where(s => s.TrainerId == SearchTrainerId)
                                    .ToList();
            SearchCompleted = true;
            FillTrainerList();
        }
    }
}