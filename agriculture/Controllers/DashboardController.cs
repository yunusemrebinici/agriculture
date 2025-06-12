using Microsoft.AspNetCore.Mvc;

namespace agriculture.Controllers
{
	public class DashboardController : Controller
	{
		public IActionResult Index()
		{
			return View();
		}
	}
}
