using GymManagementSystem.Data;
using GymManagementSystem.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.Linq;

namespace GymManagementSystem.Pages
{
    public class AddScheduleModel : PageModel
    {
        private GymDbContext _context;

        public AddScheduleModel(GymDbContext context)
        {
            _context = context;
        }

        [BindProperty]
        public AddScheduleForm AddScheduleForm { get; set; }

        public void OnGet()
        {
            PopulateSelectLists();
        }


        public IActionResult OnPost()
        {
            if (!ModelState.IsValid)
            {
                PopulateSelectLists();
                return Page();
            }

            var trainer = _context.Trainers.FirstOrDefault(t => t.Id == AddScheduleForm.TrainerId);

            var schedule = new Models.Schedule
            {
                Day = AddScheduleForm.Day,
                ProgramName = trainer.Specialty,
                StartTime = AddScheduleForm.StartTime,
                EndTime = AddScheduleForm.EndTime,
                TrainerId = AddScheduleForm.TrainerId
            };
                       
            _context.Schedules.Add(schedule);
            _context.SaveChanges();
            return RedirectToPage("/Schedule/details", new { Id = schedule.Id });
        }

        private void PopulateSelectLists()
        {
            ViewData["Day"] = new SelectList(Constant.GetDaysOfWeek());

            var trainersWithProgramSpeciality = _context.Trainers.Where(t => !string.IsNullOrEmpty(t.Specialty));
            ViewData["Trainers"] = new SelectList(trainersWithProgramSpeciality, "Id", "Name");
        }        
    }
}