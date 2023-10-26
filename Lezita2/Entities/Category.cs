using System.ComponentModel.DataAnnotations;

namespace Lezita2.Models
{
    public class Category
    {
        [Key]
        public int Id { get; set; }
        public static int Count { get; private set; } = 0;
        public string? Name { get; set; }
        public string? Image { get; set; }
        public string? BackGroundImage { get; set; }
       
    }
}
