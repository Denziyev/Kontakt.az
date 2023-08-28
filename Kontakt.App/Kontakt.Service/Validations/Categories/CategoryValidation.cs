using FluentValidation;
using Kontakt.App.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kontakt.Service.Validations.Categories
{
    public class CategoryValidation : AbstractValidator<Category>
    {
        public CategoryValidation()
        {
            RuleFor(x => x.Name)
                  .NotEmpty().WithMessage("Name can not be empty")
                  .NotNull().WithMessage("Name can not be null")
                  .MinimumLength(5)
                  .MaximumLength(30);
        }
    }
}
