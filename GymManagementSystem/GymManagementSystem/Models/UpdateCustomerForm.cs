using GymManagementSystem.Data;
using Microsoft.EntityFrameworkCore;
using System;
using System.ComponentModel.DataAnnotations;
using System.Linq;

namespace GymManagementSystem.Models
{
    /// <summary>
    /// Model for Update Customer Form
    /// </summary>
    public class UpdateCustomerForm
    {
        // STATIC FIELD
        public static int? CustomerId;

        [Display(Name = "Schedule")]
        [Required(ErrorMessage = "Please select a Schedule")]
        [CustomValidation(typeof(UpdateCustomerForm), "ValidateSchedule")]
        public int? ScheduleId { get; set; }        

        [Display(Name = "Height(cms)")]
        public int? Height { get; set; }
        [Display(Name = "Weight(kgs)")]
        public int? Weight { get; set; }

        public static ValidationResult ValidateSchedule(int? scheduleId, ValidationContext context)
        {
            if (scheduleId == null)
            {
                return ValidationResult.Success;
            }
            var dbContext = context.GetService(typeof(GymDbContext)) as GymDbContext;    

            // Then Validate Schedule
            var schedule = dbContext.Schedules
                .FirstOrDefault(s => s.Id == scheduleId);

            if (schedule == null)
            {
                return new ValidationResult("Please select a valid schedule");
            }

            // Schedule session has max limit of 5 customers
            if(HasReachedMaxLimit(schedule, dbContext))
            {
                return new ValidationResult("The schedule session is full. Please select other schedule.");
            }

            return ValidationResult.Success;
        }

        public static ValidationResult ValidateCustomer(int? customerId, ValidationContext context)
        {
            var dbContext = context.GetService(typeof(GymDbContext)) as GymDbContext;
            
            var customer = dbContext.Customers
                .Include(cust => cust.Schedule)
                .Include(cust => cust.Membership)
                .FirstOrDefault(cust => cust.Id == customerId.Value);

            if (customer == null)
            {
                return new ValidationResult("Please select a valid customer");
            }

            if (!IsValidCustomerMembership(customer))
            {
                return new ValidationResult("The customer membership is expired");
            }

            return ValidationResult.Success;
        }

        private static bool HasReachedMaxLimit(Schedule schedule, GymDbContext dbContext)
        {
            var custCountForSchedule = dbContext.Customers.Where(c => c.ScheduleId == schedule.Id).Count();
            return custCountForSchedule >= Constant.MaxLimitOfSession;
        }        

        private static bool IsValidCustomerMembership(Customer customer)
        {
            int daySinceJoined = 0;
            if (customer.JoinDate.HasValue)
            {
                daySinceJoined = (DateTime.Now - customer.JoinDate.Value).Days;
            }
            return daySinceJoined <= customer.Membership.Duration;
        }
    }
}
