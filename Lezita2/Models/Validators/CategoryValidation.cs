using FluentValidation;

namespace Lezita2.Models.Validators
{
    public class CategoryValidation:AbstractValidator<AddCategoryImage>
    {
        public CategoryValidation()
        { 
            RuleFor(x => x.Name).NotEmpty().WithMessage("Lütfen Kategori ismi giriniz.");
            RuleFor(x => x.BackGroundImage).NotEmpty().WithMessage("Lütfen arkaplan resmi ekleyiniz.");
            RuleFor(x => x.Image).NotEmpty().WithMessage("Lütfen resim ekleyiniz.");
            
        }
    }
}
