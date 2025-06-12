using DataAccessLayer.Contexts;
using Microsoft.AspNetCore.Mvc;

namespace agriculture.ViewComponents
{
	public class _DashboardChartPartial:ViewComponent
	{
		
		public IViewComponentResult Invoke()
		{
			ViewBag.v1 = 88;
			ViewBag.v2 = 20;
		
			return View();
		}
	}
}
