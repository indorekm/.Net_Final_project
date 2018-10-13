using System.ComponentModel.DataAnnotations;

namespace GymManagementSystem.Models
{
    public class Membership
    {
        [Key]
        public int Id { get; set; }

        [Display(Name = "Membership Type")]
        [Required(ErrorMessage = "Please provide Type of Membership")]
        [CustomValidation(typeof(Membership), "MembershipValidation")]
        public string MembershipType { get; set; }

        [Required(ErrorMessage = "Please provide Duration")]
        [Range(0,365,ErrorMessage="Duration should be between 0 and 365 days")]
        [Display(Name = "Duration")]
        public int Duration { get; set; }

        [Display(Name = "Membership Fee")]
        [Required(ErrorMessage = "Please provide Fee")]
        [Range(0,10000,ErrorMessage="Fee should be between 0 and 10,000 dollars")]
        public decimal? MembershipFee { get; set; }

          // VALIDATIONS
        public static ValidationResult MembershipValidation(string Membership, ValidationContext context) {
            var instance = context.ObjectInstance as Membership;
            if (instance == null) {
                return ValidationResult.Success;
            }
            if (!Membership.ToLower().Equals("regular") && !Membership.ToLower().Equals("express") && !Membership.ToLower().Equals("premuim") 
                && !Membership.ToLower().Equals("platinum")) {
               return new ValidationResult($"Speciality can either be Regular, Express, Premuim, Platinum");
            }
            return ValidationResult.Success;
        }
    }
}
