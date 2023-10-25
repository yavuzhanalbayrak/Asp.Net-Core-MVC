namespace Lezita2.Models
{
    public class Product
    {
        int Id { get; set; }
        public static int Count { get; private set; } = 0;
        public string? Name { get; set; }
        public string? Description { get; set; }
        public string? Image { get; set; }
        public int CategoryId { get; set; }
        public Product()
        {
            Id = ++Count;
        }
    }
}
