using System;
using System.ComponentModel.DataAnnotations;

namespace GymManagementSystem.Models
{
    /// <summary>
    /// Trainer Model
    /// </summary>
    public class Trainer
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
        [CustomValidation(typeof(Trainer), "GenderValidation")]
        public string Gender { get; set; }

        [DataType(DataType.Date)]
        [Required(ErrorMessage = "Please provide a Birth Date")]
        [CustomValidation(typeof(Trainer), "DateValidation")]
        [Display(Name = "Birth Date")]
        public DateTime? BirthDate { get; set; }

        [DataType(DataType.Date)]
        [Required(ErrorMessage = "Please provide a Employment Date")]
        [CustomValidation(typeof(Trainer), "DateValidation")]
        [Display(Name = "Employment Date")]
        public DateTime? StartDate { get; set; }

        [CustomValidation(typeof(Trainer), "SpecialityValidation")]
        [Display(Name = "Special In")]
        public string Specialty { get; set; }

        [Display(Name = "Salary/hr")]
        [Required(ErrorMessage = "Please provide Salary")]
        [Range(8,30,ErrorMessage="Salary should be between 8 and 30 dollars per hour")]
        public decimal? Salary { get; set; }

        // READONLY
        public string Name
        {
            get { return $"{FirstName} {LastName}"; }
        }

        public int Age
        {
            get { return GetAge(); }
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
        public double? Experience
        {
            get
            {
                return (DateTime.Today - StartDate).Value.TotalDays;
            }
        }

        private float? GetExperience()
        {
            throw new NotImplementedException();
        }

        // VALIDATIONS
        public static ValidationResult SpecialityValidation(string Speciality, ValidationContext context) {
            var instance = context.ObjectInstance as Trainer;
            if(Speciality == null){
                return ValidationResult.Success;
            }else if (!Speciality.ToLower().Equals("yoga") && !Speciality.ToLower().Equals("zumba") && !Speciality.ToLower().Equals("weight training") 
                && !Speciality.ToLower().Equals("jumbo ciruit training")) {
               return new ValidationResult($"Speciality can either be Yoga, Zumba, Weight Training or Jumbo Ciruit Training");
            }
            return ValidationResult.Success;
        }

          public static ValidationResult GenderValidation(string Gender, ValidationContext context) {
            var instance = context.ObjectInstance as Trainer;
            if (!Gender.ToLower().Equals("male") && !Gender.ToLower().Equals("female") && !Gender.ToLower().Equals("other")) {
               return new ValidationResult($"Gender can be Male, Female or Other");
            }
            return ValidationResult.Success;
        }

           public static ValidationResult DateValidation(DateTime? Date, ValidationContext context) {

            if (Date < DateTime.Today) {
                return ValidationResult.Success;
            }
            return new ValidationResult("Date must be in the past");
        }
    }
}
