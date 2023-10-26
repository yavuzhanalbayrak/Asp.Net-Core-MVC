using FluentValidation;

namespace Lezita2.Models.Validators
{
    public class ProductValidation : AbstractValidator<Product>
    {
        public ProductValidation()
        {
            RuleFor(product => product.Name).NotEmpty().WithMessage("Ürün ismi giriniz.");
            RuleFor(customer => customer.Image).NotEmpty().WithMessage("Ürün resmi zorunludur.");
            RuleFor(customer => customer.Description).NotEmpty().WithMessage("Ürün açıklaması giriniz.");
            RuleFor(x => x.CategoryId)
                .NotNull().WithMessage("Kategori seçimi zorunludur.")
                .NotEqual(-1).WithMessage("Lütfen geçerli bir kategori seçin.");
            // ... diğer kurallar ...
        }
    }
}
