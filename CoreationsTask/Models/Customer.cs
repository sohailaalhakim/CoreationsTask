using CoreationsTask.Data.Base;
using System.ComponentModel.DataAnnotations;

namespace CoreationsTask.Models
{
    public class Customer : IEntityBase
    {
        [Key]
        public int Id { get; set; }
        [Display(Name = "Customer Name")]
        [Required(ErrorMessage = "Name is required")]
        [MaxLength(100)]
        public string FullName { get; set; }
        [Display(Name = "Mobile Phone")]
        [Required(ErrorMessage = "Mobile Phone is required")]
        [MaxLength(11)]
        [RegularExpression(@"^01[0-9]{9}$", ErrorMessage = "Please enter a valid phone number.")]
        public string Mobile { get; set; }
        [Display(Name = "Address")]
        [MaxLength(250)]
        public string Address { get; set; }

        public List<Product> Products { get; set;}
        //public List<Order> Orders { get; set; }

    }
}
