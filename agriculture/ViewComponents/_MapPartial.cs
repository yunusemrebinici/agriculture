using DataAccessLayer.Contexts;
using Microsoft.AspNetCore.Mvc;

namespace agriculture.ViewComponents
{
	public class _MapPartial:ViewComponent
	{
		public IViewComponentResult Invoke()
		{
			AgricultureContext context = new AgricultureContext();
			var values = context.Addresses.Select(x=>x.Mapİnfo).FirstOrDefault();
			ViewBag.v = values;
			return View();
		}
	}
}
