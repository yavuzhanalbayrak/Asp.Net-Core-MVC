namespace Lezita2.Models.ViewModels
{
    public class CategoryUpdateVM
    {
        public int Id { get; set; }
        public string? Name { get; set; }
        public IFormFile? Image { get; set; }
        public IFormFile? BackGroundImage { get; set; }

        public async Task AddImageAsync(Category category)
        {
            var dictionary = "categoryImages";
            // Uzantıyı al (örneğin ".jpg")
            var fileExtension1 = Path.GetExtension(Image.FileName);
            var fileExtension2 = Path.GetExtension(BackGroundImage.FileName);

            // Özgün bir dosya adı oluştur (guid + uzantı)
            var filename1 = $"{Guid.NewGuid()}{fileExtension1}";
            var filename2 = $"{Guid.NewGuid()}{fileExtension2}";

            // Dosyanın kaydedileceği tam yolu oluştur
            var path1 = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot", dictionary, filename1);
            var path2 = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot", dictionary, filename2);

            category.Image = $"/{dictionary}/{filename1}";
            category.BackGroundImage = $"/{dictionary}/{filename2}";
            // Dosyayı belirlenen yola kaydet
            using (var stream = new FileStream(path1, FileMode.Create))
            {
                await Image.CopyToAsync(stream);
            }
            using (var stream = new FileStream(path2, FileMode.Create))
            {
                await BackGroundImage.CopyToAsync(stream);
            }

           
        }
    }
}
