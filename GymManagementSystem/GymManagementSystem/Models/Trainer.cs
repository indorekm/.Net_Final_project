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
        public string FirstName { get; set; }

        [Display(Name = "Last Name")]
        public string LastName { get; set; }

        public string Gender { get; set; }

        [DataType(DataType.Date)]
        [Display(Name = "Birth Date")]
        public DateTime? BirthDate { get; set; }

        // READ ONLY
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

        [DataType(DataType.Date)]
        [Display(Name = "Employment Date")]
        public DateTime? StartDate { get; set; }

        public string Specialty { get; set; }

        public decimal? Salary { get; set; }

        // READONLY
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
    }
}
