using System.ComponentModel.DataAnnotations;

namespace CoreationsTask.Models
{
    public class RegistrationVM
    {

        [Display(Name = "Full Name")]
        [Required(ErrorMessage = "Full Name is required")]
        public string FullName { get; set; }

        [Display(Name = "Username")]
        [Required(ErrorMessage = "Username is required")]

        public string UserName { get; set; }


        [Display(Name = "Email Address")]
        [Required(ErrorMessage = "Email Address is required")]
        [DataType(DataType.EmailAddress)]

        public string Email { get; set; }

        [Display(Name = "Password")]
        [Required(ErrorMessage = "Password is required")]
        [DataType(DataType.Password)]
        public string Password { get; set; }

        [Display(Name = "Confirm Password")]
        [Required(ErrorMessage = "Confirm Password is required")]
        [DataType(DataType.Password)]
        [Compare("Password", ErrorMessage = "Passwords don't match")]
        public string ConfirmPassword { get; set; }
    }
}
