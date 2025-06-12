using DataAccessLayer.Contexts;
using Microsoft.AspNetCore.Mvc;

namespace agriculture.ViewComponents
{
	public class _DashboardOverviewPartial:ViewComponent
	{
		AgricultureContext c=new AgricultureContext();
		public IViewComponentResult Invoke()
		{
			ViewBag.teamCount = c.Teams.Count();
			ViewBag.serviceCount = c.Services.Count();
			ViewBag.messageCount=c.Contacts.Count();

			ViewBag.announcementTrue = c.Announcements.Where(x => x.Status == true).Count();
			ViewBag.announcementFalse = c.Announcements.Where(x => x.Status == false).Count();

			ViewBag.ilacSorumlusu = c.Teams.Where(x => x.Title == "İlaçlama Sorumlusu").Select(y => y.PersonName).FirstOrDefault();
			ViewBag.kaliteSorumlusu = c.Teams.Where(x => x.Title == "Kalite Kontrol Sorumlusu").Select(y => y.PersonName).FirstOrDefault();
			ViewBag.uretimSorumlusu = c.Teams.Where(x => x.Title == "Üretim Sorumlusu").Select(y => y.PersonName).FirstOrDefault();
			ViewBag.makineSorumlusu = c.Teams.Where(x => x.Title == "Makine Bakımcısı").Select(y => y.PersonName).FirstOrDefault();

			return View();
		}
	}
}
