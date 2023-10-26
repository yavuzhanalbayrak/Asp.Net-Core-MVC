namespace Lezita2.Models
{
    public class AddProductImage
    {
        public static int Count { get; private set; } = 0;
        public string? Name { get; set; }
        public string? Description { get; set; }
        public IFormFile? Image { get; set; }
        public int? CategoryId { get; set; }
    }
}
