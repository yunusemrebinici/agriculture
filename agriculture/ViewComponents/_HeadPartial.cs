using Microsoft.AspNetCore.Mvc;

namespace agriculture.ViewComponents
{
	public class _HeadPartial : ViewComponent
	{
		public IViewComponentResult Invoke()
		{
			return View(); 
		}
	}
}
