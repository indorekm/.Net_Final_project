using System;
using System.ComponentModel.DataAnnotations;

namespace GymManagementSystem.Models
{
    /// <summary>
    /// Customer Model
    /// </summary>
    public class Customer
    {
        [Key]
        public int Id { get; set; }

        [Display(Name = "First Name")]
        public string FirstName { get; set; }

        [Display(Name = "Last Name")]
        public string LastName { get; set; }

        public string Gender { get; set; }

        [DataType(DataType.Date)]
        [Display(Name = "Birth Date")]
        public DateTime? BirthDate { get; set; }        

        [DataType(DataType.Date)]
        [Display(Name = "Joining Date")]
        public DateTime? JoinDate { get; set; }

        public string Email { get; set; }

        [Display(Name = "Phone Number")]
        public string PhoneNumber { get; set; }

        [Display(Name = "Zip")]
        public string ZipCode { get; set; }

        [Display(Name = "Height (cm)")]
        public float? Height { get; set; }

        [Display(Name = "Weight (kg)")]
        public float? Weight { get; set; }

        // READ ONLY
        public string Name
        {
            get { return $"{FirstName} {LastName}"; }
        }

        public int Age
        {
            get { return GetAge(); }
        }        

        [Display(Name = "BMI")]
        public float? Bmi
        {
            get { return GetBmi(); }
        }

        private int GetAge()
        {
            int age = 0;
            if (BirthDate.HasValue)
            {
                age = DateTime.Now.Year - BirthDate.Value.Year;
            }
            return age;
        }

        private float? GetBmi()
        {
            float? bmi = null;
            if (Weight.HasValue && Height.HasValue)
            {
                bmi = Weight.Value * 100 / (Height.Value * Height.Value);
            }
            return bmi;
        }

        // RELATIONSHIP
        [Display(Name = "Membership")]
        public int MembershipId { get; set; }

        public Membership Membership { get; set; }

        [Display(Name = "Schedule #")]
        public int ScheduleId { get; set; }

        public Schedule Schedule { get; set; }

        // VALIDATIONS
    }
}
