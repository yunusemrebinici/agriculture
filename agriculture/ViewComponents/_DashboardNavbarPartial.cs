using Microsoft.AspNetCore.Mvc;

namespace agriculture.ViewComponents
{
    public class _DashboardNavbarPartial:ViewComponent
    {
        public IViewComponentResult Invoke()
        {
            return View();
        }
    }
}
