using Microsoft.EntityFrameworkCore;

namespace Lezita2.Models
{
    public class AddProductImage
    {
        public int Id { get; set; }
        public string? Name { get; set; }
        public string? Description { get; set; }
        public IFormFile? Image { get; set; }
        public int? CategoryId { get; set; }

        public async Task AddImageAsync(Product product)
        {
         
            var dictionary = "productImages";
            // Uzantıyı al (örneğin ".jpg")
            var fileExtension = Path.GetExtension(this.Image.FileName);

            // Özgün bir dosya adı oluştur (guid + uzantı)
            var filename = $"{Guid.NewGuid()}{fileExtension}";

            // Dosyanın kaydedileceği tam yolu oluştur
            var path = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot", dictionary, filename);

            // Dosyayı belirlenen yola kaydet
            using (var stream = new FileStream(path, FileMode.Create))
            {
                await this.Image.CopyToAsync(stream);
            }
            //Nesneye değerler atandı.
            product.Name = this.Name;
            product.Description = this.Description;
            product.CategoryId = this.CategoryId;
            //Fotoğrafın url'i eklendi
            product.Image = $"/{dictionary}/{filename}";
        }
    }
}
