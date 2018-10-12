using System.Linq;
using GymManagementSystem.Data;
using GymManagementSystem.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace GymManagementSystem.Pages
{
    public class UpdateCustomerModel : PageModel
    {

        private readonly GymDbContext _context;
        private Models.Customer customerToUpdate;

        public UpdateCustomerModel(GymDbContext context)
        {
            _context = context;
        }


        [BindProperty]
        public UpdateCustomerForm UpdateCustomerForm { get; set; }

        public void OnGet(int? id)
        {
            UpdateCustomerForm.CustomerId = id;            
            PopulateSelectLists();
        }

        public IActionResult OnPost()
        {
            if (!ModelState.IsValid)
            {
                PopulateSelectLists();
                return Page();
            }

            customerToUpdate = _context.Customers.First(cust => cust.Id == UpdateCustomerForm.CustomerId);

            // 1. Update Schedule
            if (UpdateCustomerForm.ScheduleId.HasValue)
            {
                customerToUpdate.ScheduleId = UpdateCustomerForm.ScheduleId.Value;
            }
            // 2. Update Height
            if (UpdateCustomerForm.Height.HasValue)
            {
                customerToUpdate.Height = UpdateCustomerForm.Height.Value;
            }
            // 3. Update Weight
            if (UpdateCustomerForm.Weight.HasValue)
            {
                customerToUpdate.Weight = UpdateCustomerForm.Weight.Value;
            }

            _context.SaveChanges();
            return RedirectToPage("/customer/details", new { Id = customerToUpdate.Id });
        }

        private void PopulateSelectLists()
        {
            var schedules = _context.Schedules
                .OrderBy(x => x.ProgramName)
                .ThenBy(x => x.StartTime)
                .ToList();

            ViewData["ScheduleId"] = new SelectList(schedules, "Id", "Description");
        }
    }
}