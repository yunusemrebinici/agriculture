using BusinessLayer.Abstract;
using Microsoft.AspNetCore.Mvc;

namespace agriculture.ViewComponents
{
	public class _AddressPartial:ViewComponent
	{
		readonly IAdressService _adressService;

		public _AddressPartial(IAdressService adressService)
		{
			_adressService = adressService;
		}

		public IViewComponentResult Invoke()
		{
			var values = _adressService.GetListAll();
			return View(values);
		}

	}
}
