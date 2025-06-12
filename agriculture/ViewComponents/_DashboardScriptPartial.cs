using Microsoft.AspNetCore.Mvc;

namespace agriculture.ViewComponents
{
	public class _DashboardScriptPartial : ViewComponent
	{
		public IViewComponentResult Invoke()
		{
			return View();
		}
	}
}
