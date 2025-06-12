using EntityLayer.Concrete;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.ValidationRules
{
	public class AdressesValidator : AbstractValidator<Address>
	{
		public AdressesValidator()
		{
			RuleFor(x => x.Description1).NotEmpty();
			RuleFor(x => x.Description1).MinimumLength(3).MaximumLength(30).WithMessage("Boş geçilemez,maximum 25 minimum 3 karakter olabilir");
			RuleFor(x => x.Description2).NotEmpty();
			RuleFor(x => x.Description2).MinimumLength(3).MaximumLength(30).WithMessage("Boş geçilemez,maximum 25 minimum 3 karakter olabilir");
			RuleFor(x => x.Description3).NotEmpty();
			RuleFor(x => x.Description3).MinimumLength(3).MaximumLength(30).WithMessage("Boş geçilemez,maximum 25 minimum 3 karakter olabilir");			
			RuleFor(x => x.Description4).NotEmpty();
			RuleFor(x => x.Description4).MinimumLength(3).MaximumLength(30).WithMessage("Boş geçilemez,maximum 25 minimum 3  karakter olabilir");
			RuleFor(x => x.Mapİnfo).NotEmpty();



		}
	}
}
