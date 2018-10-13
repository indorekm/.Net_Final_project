using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace GymManagementSystem.Models
{
    /// <summary>
    /// Schedule Model
    /// </summary>
    public class Schedule
    {
        [Key]
        public int Id { get; set; }
    
        [Required(ErrorMessage="Please provide Day")]
        public DayOfWeek Day { get; set; }

        [CustomValidation(typeof(Schedule), "ProgramValidation")]
        [Required(ErrorMessage = "Please provide a Program")]
        [Display(Name = "Program")]
        public string ProgramName { get; set; }

        [Required(ErrorMessage = "Please provide a Start Date and Time")]
        [CustomValidation(typeof(Schedule), "DateTimeValidation")]
        [Display(Name = "Start Time")]
        public DateTime? StartTime { get; set; }

        [Display(Name = "End Time")]
        [Required(ErrorMessage = "Please provide a End Date and Time")]
        [CustomValidation(typeof(Schedule), "DateTimeValidation")]
        public DateTime? EndTime { get; set; }

        // READ ONLY

        [Display(Name = "Schedule Description")]
        public string Description
        {
            get { return $"{ProgramName} - {Day} - {StartTime.Value.ToShortTimeString()} to {EndTime.Value.ToShortTimeString()}"; }
        }

        // RELATIONSHIP
        [Required(ErrorMessage="Please provide Trainer")]
        [Display(Name = "Trainer")]
        public int TrainerId { get; set; }

        public Trainer Trainer { get; set; }

        // VALIDATIONS
        public static ValidationResult ProgramValidation(string Program, ValidationContext context) {
            var instance = context.ObjectInstance as Schedule;
            if (instance == null) {
                return ValidationResult.Success;
            }
            if (!Program.ToLower().Equals("yoga") && !Program.ToLower().Equals("zumba") && !Program.ToLower().Equals("weight training") 
                && !Program.ToLower().Equals("jumbo ciruit training")) {
               return new ValidationResult($"Program can either be Yoga, Zumba, Weight Training or Jumbo Ciruit Training");
            }
            return ValidationResult.Success;
        }

        public static ValidationResult DateTimeValidation(DateTime? Time, ValidationContext context) {
            if (Time == null) {
                return ValidationResult.Success;
            }
            var instance = context.ObjectInstance as Customer;
            if (instance == null) {
                return ValidationResult.Success;
            }
            if (Time > DateTime.Today) {
                return ValidationResult.Success;
            }
            return new ValidationResult("Date must be in the Future");
        }

        
    }

    /// <summary>
    /// Contant class
    /// </summary>
    public static class Constant
    {
        public static int MaxLimitOfSession { get { return 5; } }

        /// <summary>
        /// Gets the days of week.
        /// </summary>
        /// <returns></returns>
        public static List<DayOfWeek> GetDaysOfWeek()
        {
            return new List<DayOfWeek>
            {
                DayOfWeek.Monday,
                DayOfWeek.Tuesday,
                DayOfWeek.Wednesday,
                DayOfWeek.Thursday,
                DayOfWeek.Friday,
                DayOfWeek.Saturday,
                DayOfWeek.Sunday
            };
        }
    }
}
