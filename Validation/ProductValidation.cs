using FluentValidation;
using GestionLocationWebApplication.Models.Entities;

namespace GestionLocationWebApplication.Validation
{
    public class ProductValidation : AbstractValidator<Article>
    {
        public ProductValidation()
        {
            RuleFor(p => p.Label).NotNull().WithMessage("[Validation Label] Veuillez introduire le nom de votre produit");
            RuleFor(p => p.Quantity).NotNull().WithMessage("[Validation Quantité] Veuillez introduire la quantité de votre produit");
            RuleFor(p => p.Prix).NotNull().WithMessage("[Validation Prix] Veuillez introduire le prix de votre produit");
        }
    }
}