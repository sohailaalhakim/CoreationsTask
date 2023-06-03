using System.ComponentModel.DataAnnotations;

namespace CoreationsTask
{
    public class LoginVM
    {
        [Display(Name = "Email")]
        [Required(ErrorMessage = "Email Address is required")]
        public string Email { get; set; }

        [Required]
        [DataType(DataType.Password)]
        public string Password { get; set; }
        [Display(Name = "Remeber Me")]

        public bool RemeberMe { get; set; }
    }
}

