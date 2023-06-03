using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace CoreationsTask.Models
{
    public class Product : IEntityBase
    {
        [Key]
        public int Id { get; set; }
        [Required(ErrorMessage = "Name is required")]
        [MaxLength(100)]
        [Display(Name = "Product Name")]
        public string Name { get; set; }
        [Required(ErrorMessage = "Price is required")]
        public decimal Price { get; set; }
        [ForeignKey("CustomerId")]
        public int CustomerId { get; set; }
        public Customer Customer { get; set; }
        //public List<Order> Orders { get; set;}


    }
}
