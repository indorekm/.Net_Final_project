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
        [StringLength(100, MinimumLength = 2, ErrorMessage = "2 - 100 characters only")]
        public string FirstName { get; set; }

        [Display(Name = "Last Name")]
        [Required(ErrorMessage = "Please provide a Last name")]
        [StringLength(100, MinimumLength = 2, ErrorMessage = "2 - 100 characters only")]
        public string LastName { get; set; }

        [Required(ErrorMessage = "Please provide a Gender")]
        [CustomValidation(typeof(Customer), "GenderValidation")]
        [Display(Name = "Gender")]
        public string Gender { get; set; }

        [DataType(DataType.Date)]
        [Required(ErrorMessage = "Please provide a Birth Date")]
        [CustomValidation(typeof(Customer), "BirthValidation")]
        [Display(Name = "Birth Date")]
        public DateTime? BirthDate { get; set; }        

        [DataType(DataType.Date)]
        [Required(ErrorMessage = "Please provide a Joining Date")]
        [CustomValidation(typeof(Customer), "JoinValidation")]
        [Display(Name = "Joining Date")]
        public DateTime? JoinDate { get; set; }

        [RegularExpression(@"^([\w-\.]+)@((\[[0-9]{1,3}\.[0-9]{1,3}\.[0-9]{1,3}\.)|(([\w-]+\.)+))([a-zA-Z]{2,4}|[0-9]{1,3})(\]?)$", ErrorMessage = "Please enter valid Email ID" )]
        [Required(ErrorMessage = "Please provide an Email ID")]
        public string Email { get; set; }

        [Display(Name = "Phone Number")]
        [Required(ErrorMessage = "Please provide a Phone number")]
        [RegularExpression("^[0-9]{10}$", ErrorMessage = "Please enter valid 10 digit Mobile number" )]
        public string PhoneNumber { get; set; }

        [RegularExpression("^[0-9]{5}$", ErrorMessage = "Please enter valid 5 digit zip code" )]
        [Display(Name = "Zip")]
        [Required(ErrorMessage = "Please provide a Zip code")]
        public string ZipCode { get; set; }

        [Range(100,int.MaxValue,ErrorMessage="Height cannot be less than 100 cms")]
        [Display(Name = "Height (cms)")]
        [Required(ErrorMessage = "Please provide Height measurement")]
        public float? Height { get; set; }

        [Display(Name = "Weight (kgs)")]
        [Range(20,Int32.MaxValue,ErrorMessage="Weight cannot be less than 20 Kgs")]
        [Required(ErrorMessage = "Please provide weight measurement")]
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

        [Display(Name = "Schedule")]
        public int ScheduleId { get; set; }

        public Schedule Schedule { get; set; }

        // VALIDATIONS
         public static ValidationResult GenderValidation(string Gender, ValidationContext context) {
            if (string.IsNullOrWhiteSpace(Gender)) {
                return ValidationResult.Success;
            }
            var instance = context.ObjectInstance as Customer;
            if (instance == null) {
                return ValidationResult.Success;
            }
            if (!Gender.ToLower().Equals("male") && !Gender.ToLower().Equals("female") && !Gender.ToLower().Equals("other")) {
               return new ValidationResult($"Gender can be Male, Female or Other");
            }
            return ValidationResult.Success;
        }

           public static ValidationResult JoinValidation(DateTime? Date, ValidationContext context) {
            if (Date == null) {
                return ValidationResult.Success;
            }
            var instance = context.ObjectInstance as Customer;
            if (instance == null) {
                return ValidationResult.Success;
            }
            if (Date < DateTime.Today) {
                return ValidationResult.Success;
            }
            return new ValidationResult("Date must be in the past");
        }
        public static ValidationResult BirthValidation(DateTime? Date, ValidationContext context) {
            if (Date == null) {
                return ValidationResult.Success;
            }
            var instance = context.ObjectInstance as Customer;
            if (instance == null) {
                return ValidationResult.Success;
            }

            var diff = ((DateTime.Today - Date).Value.TotalDays)/365;
            if (diff < 18) {
                return new ValidationResult("Customer should be above 18 years of age");
            }
            return ValidationResult.Success;
        }
    }
}
