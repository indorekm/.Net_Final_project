using System.ComponentModel.DataAnnotations;

namespace GymManagementSystem.Models
{
    public class Membership
    {
        [Key]
        public int Id { get; set; }

        [Display(Name = "Membership Type")]
        public string MembershipType { get; set; }

        [Display(Name = "Duration")]
        public int Duration { get; set; }

        [Display(Name = "Membership Fee")]
        public decimal? MembershipFee { get; set; }
    }
}
