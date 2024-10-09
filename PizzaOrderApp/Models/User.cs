using System.ComponentModel.DataAnnotations;

namespace PizzaOrderApp.Models
{
    public class User
    {
        [Required]
        [StringLength(50)]
        public string Name { get; set; }

        [Required]
        [Range(16, 120)]
        public int Age { get; set; }
    }
}
