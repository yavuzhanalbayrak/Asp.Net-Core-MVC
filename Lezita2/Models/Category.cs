namespace Lezita2.Models
{
    public class Category
    {
        int Id { get; set; }
        public static int Count { get; private set; } = 0;
        public string? Name { get; set; }
        public string? Image { get; set; }
        public Category()
        {
            Id = ++Count;
        }
    }
}
