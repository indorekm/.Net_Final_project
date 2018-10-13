using GymManagementSystem.Data;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace GymManagementSystem.Models
{
    public class AddScheduleForm
    {
        [Required(ErrorMessage = "Please provide Day")]
        public DayOfWeek Day { get; set; }

        [Required(ErrorMessage = "Please provide a Start Date and Time")]
        [CustomValidation(typeof(AddScheduleForm), "DateTimeValidation")]
        [Display(Name = "Start Time")]
        public DateTime? StartTime { get; set; }

        [Display(Name = "End Time")]
        [Required(ErrorMessage = "Please provide a End Date and Time")]
        [CustomValidation(typeof(AddScheduleForm), "DateTimeValidation")]
        public DateTime? EndTime { get; set; }

        [Required(ErrorMessage = "Please provide Trainer")]
        [Display(Name = "Trainer")]
        [CustomValidation(typeof(AddScheduleForm), "TrainerValidation")]
        public int TrainerId { get; set; }

        // VALIDATIONS

        public static ValidationResult DateTimeValidation(DateTime? time, ValidationContext context)
        {
            var instance = context.ObjectInstance as AddScheduleForm;
            if (instance == null)
            {
                return ValidationResult.Success;
            }

            if (time == null)
            {
                return ValidationResult.Success;
            }

            if (time > DateTime.Today)
            {
                return ValidationResult.Success;
            }
            return new ValidationResult("Date must be in the Future");
        }

        public static ValidationResult TrainerValidation(int? trainerId, ValidationContext context)
        {
            var instance = context.ObjectInstance as AddScheduleForm;
            if (instance == null)
            {
                return ValidationResult.Success;
            }

            if (trainerId == null)
            {
                return ValidationResult.Success;
            }

            var dbContext = context.GetService(typeof(GymDbContext)) as GymDbContext;
            var trainerScheduleCount = dbContext.Schedules.Where(s => s.TrainerId == trainerId).Count();
            if (trainerScheduleCount > 4)
            {
                return new ValidationResult("Trainer cannot have more than 4 schedules");                
            }
            return ValidationResult.Success;
        }
    }
}
