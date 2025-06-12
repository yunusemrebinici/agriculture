using EntityLayer.Concrete;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.ValidationRules
{
    public class ImageValidator : AbstractValidator<Image>
    {
        public ImageValidator()
        {
            RuleFor(x => x.Title).NotEmpty();
            RuleFor(x => x.Title).MinimumLength(8).MaximumLength(20).WithMessage("Minimum 8 , Maximum 20 karakter olmalı");
            //
            RuleFor(x => x.Description).NotEmpty();
            RuleFor(x => x.Description).MinimumLength(20).MaximumLength(50).WithMessage("Minimum 20 , Maximum 50 karakter olmalı");
            //
            RuleFor(x => x.ImageUrl).NotEmpty();
            RuleFor(x => x.ImageUrl).MinimumLength(10).MaximumLength(80).WithMessage("Minimum 10 , Maximum 80 karakter olmalıdır");
           
        }
    }
}
