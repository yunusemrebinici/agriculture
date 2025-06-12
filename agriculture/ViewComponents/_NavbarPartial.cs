using Microsoft.AspNetCore.Mvc;

namespace agriculture.ViewComponents
{
	public class _NavbarPartial:ViewComponent
	{
		public IViewComponentResult Invoke()
		{
			return View();
		}
	}
}
