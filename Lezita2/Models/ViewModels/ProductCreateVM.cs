using Microsoft.EntityFrameworkCore;

namespace Lezita2.Models.ViewModels
{
    public class ProductCreateVM
    {
        public string? Name { get; set; }
        public int? Price { get; set; }
        public int? Quantity { get; set; }
        public string? Description { get; set; }
        public IFormFile? Image { get; set; }
        public int? CategoryId { get; set; }

        public async Task AddImageAsync(Product product)
        {

            var dictionary = "productImages";
            // Uzantıyı al (örneğin ".jpg")
            var fileExtension = Path.GetExtension(Image.FileName);

            // Özgün bir dosya adı oluştur (guid + uzantı)
            var filename = $"{Guid.NewGuid()}{fileExtension}";

            // Dosyanın kaydedileceği tam yolu oluştur
            var path = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot", dictionary, filename);

            //Fotoğrafın url'i eklendi
            product.Image = $"/{dictionary}/{filename}";
            // Dosyayı belirlenen yola kaydet
            using (var stream = new FileStream(path, FileMode.Create))
            {
                await Image.CopyToAsync(stream);
            }
            
            
        }
    }
}
