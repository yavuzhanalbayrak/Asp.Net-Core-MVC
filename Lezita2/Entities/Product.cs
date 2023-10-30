using System.ComponentModel.DataAnnotations;

namespace Lezita2.Models
{
    public class Product
    {
        [Key]
        public int Id { get; set; }
        public string? Name { get; set; }
        public int Price { get; set; }
        public int Quantity { get; private set; }
        public string? Description { get; set; }
        public string? Image { get; set; }
        public int? CategoryId { get; set; }
     
    }
}
