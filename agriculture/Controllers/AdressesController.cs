using BusinessLayer.Abstract;
using BusinessLayer.ValidationRules;
using EntityLayer.Concrete;
using FluentValidation.Results;
using Microsoft.AspNetCore.Mvc;

namespace agriculture.Controllers
{
	public class AdressesController : Controller
	{
		private readonly IAdressService _adressService;

		public AdressesController(IAdressService adressService)
		{
			_adressService = adressService;
		}

		public IActionResult Index()
		{
			var values = _adressService.GetListAll();
			return View(values);
		}
		[HttpGet]
		public IActionResult AddAdress()
		{
			return View();
		}
		[HttpPost]
		public IActionResult AddAdress(Address address)
		{
			AdressesValidator validationRules = new AdressesValidator();
			ValidationResult result = validationRules.Validate(address);
			if (result.IsValid)
			{
				_adressService.Insert(address);
				return RedirectToAction("Index");

			}
			else
			{
				foreach (var item in result.Errors)
				{
					ModelState.AddModelError(item.PropertyName,item.ErrorCode);
				}
			}
			
			return View();
		}
		[HttpGet]
		public IActionResult EditAdress(int id)
		{
			
			var values= _adressService.GetById(id);
			return View(values);
		}
		[HttpPost]
		public IActionResult EditAdress(Address address)
		{
			AdressesValidator validator = new AdressesValidator();
			ValidationResult result = validator.Validate(address);
			if (result.IsValid)
			{
				_adressService.Update(address);
				return RedirectToAction("Index");
			}
			else
			{
				foreach (var item in result.Errors)
				{
					ModelState.AddModelError(item.PropertyName,item.ErrorMessage);
				}
			}
			return View();
		}
		public IActionResult Delete(int id)
		{
			var values = _adressService.GetById(id);
			_adressService.Delete(values);
			return RedirectToAction("Index"); 
		}
	}
}
