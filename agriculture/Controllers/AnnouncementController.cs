using BusinessLayer.Abstract;
using EntityLayer.Concrete;
using Microsoft.AspNetCore.Mvc;

namespace agriculture.Controllers
{
	public class AnnouncementController : Controller
	{
		private readonly IAnnouncementService _announcementService;

		public AnnouncementController(IAnnouncementService announcementService)
		{
			_announcementService = announcementService;
		}

		public IActionResult Index()
		{
			var values = _announcementService.GetListAll();
			return View(values);
		}
		[HttpGet]
		public IActionResult Addannouncement()
		{
			return View();
		}
		[HttpPost]
		public IActionResult Addannouncement(Announcement p)
		{
			p.Date= DateTime.Parse(DateTime.Now.ToShortDateString());
			p.Status = false;
			_announcementService.Insert(p);
			return RedirectToAction("Index");
		}
		public IActionResult Deleteannouncement(int id)
		{
			var values=_announcementService.GetById(id);
			_announcementService.Delete(values);
			return RedirectToAction("Index");
		}
		[HttpGet]
		public ActionResult Editannouncement(int id)
		{
			var values = _announcementService.GetById(id);
			return View(values);
		}
		[HttpPost]
		public IActionResult Editannouncement(Announcement p)
		{
			_announcementService.Update(p);
			return RedirectToAction("Index");
		}
		public IActionResult ChangeStatusToTrue(int id) 
		{
			_announcementService.AnnouncementStatusToTrue(id);
			return RedirectToAction("Index");
		}

		public IActionResult ChangeStatusFalse(int id)
		{
			_announcementService.AnnouncementStatusToFalse(id);
			return RedirectToAction("Index");
		}
	}
}
