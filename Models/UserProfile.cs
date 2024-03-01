using System.ComponentModel.DataAnnotations;

namespace ExpenseManagement2.Models
{
    public class UserProfile
    {
        [Key]
        public int Id { get; set; }

        [Required(ErrorMessage = "Please complete this field")]
        [MinLength(3, ErrorMessage = "The entity is too short...")]
        [Display(Name = "First Name")]
        public string FirstName { get; set; }



        [Required(ErrorMessage = "Please complete this field")]
        [MinLength(3, ErrorMessage = "The entity is too short...")]
        [Display(Name = "Last Name")]
        public string LastName { get; set; }



        [Required(ErrorMessage = "Please complete this field")]
        [MinLength(3, ErrorMessage = "The entity is too short...")]
        [Display(Name = "Email Address")]
        public string Email { get; set; }



        [Required(ErrorMessage = "Please complete this field")]
        public string Password { get; set; }
    }
}
