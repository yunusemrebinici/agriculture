using EntityLayer.Concrete;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.ValidationRules
{
	public class TeamValidator : AbstractValidator<Team>
	{
		public TeamValidator()
		{
			RuleFor(x=>x.PersonName).NotEmpty().WithMessage("İsim Boş Geçilemez");
			RuleFor(x => x.Title).NotEmpty().WithMessage("Görev Kısmını Boş Geçemezsiniz");
			RuleFor(x => x.ImageUrl).NotEmpty().WithMessage("Resim Kısmı Boş Geçilemez");
			RuleFor(x => x.PersonName).MaximumLength(50).WithMessage("Lütfen 50 karakterden az veri girişi yapınız");
			RuleFor(x => x.PersonName).MinimumLength(5).WithMessage("Minimum 5 karakter olmalı");
			RuleFor(x => x.Title).MinimumLength(5).WithMessage("Minimum 5 karakter olmalı");
			RuleFor(x => x.Title).MaximumLength(20).WithMessage("Lütfen 20 karakterden az veri girişi yapınız");

		}
	}
}
