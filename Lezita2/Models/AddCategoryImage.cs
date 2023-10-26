namespace Lezita2.Models
{
    public class AddCategoryImage
    {
        public string? Name { get; set; }
        public IFormFile? Image { get; set; }
        public IFormFile? BackGroundImage { get; set; }
    }
}
