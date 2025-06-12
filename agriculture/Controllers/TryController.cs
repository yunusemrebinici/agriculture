using Microsoft.AspNetCore.Mvc;

namespace agriculture.Controllers
{
	public class TryController : Controller
	{
		public IActionResult Index()
		{
			return View();
		}
	}
}
