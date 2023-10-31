using FluentValidation;
using Lezita2.Models.ViewModels;

namespace Lezita2.Models.Validators
{
    public class CategoryUpdateValidator : AbstractValidator<CategoryUpdateVM>
    {
        public CategoryUpdateValidator()
        {
            RuleFor(x => x.Name).NotEmpty().WithMessage("Lütfen Kategori ismi giriniz.");
            RuleFor(x => x.BackGroundImage).NotEmpty().WithMessage("Lütfen arkaplan resmi ekleyiniz.");
            RuleFor(x => x.Image).NotEmpty().WithMessage("Lütfen resim ekleyiniz.");

        }
    }
}
