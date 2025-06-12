﻿using BusinessLayer.Abstract;
using Microsoft.AspNetCore.Mvc;

namespace agriculture.Controllers
{
	public class ContactController : Controller
	{  
		private readonly IContactService _contactService;

		public ContactController(IContactService contactService)
		{
			_contactService = contactService;
		}
		public IActionResult Index()
		{
			var values = _contactService.GetListAll();
			return View(values);
		}
		[HttpGet]
		public IActionResult Details(int id)
		{
			var values =_contactService.GetById(id);
			return View(values);
		}
		
		public IActionResult DeleteContact(int id)
		{
			var values = _contactService.GetById(id);
			_contactService.Delete(values);
			return RedirectToAction("Index");
		}
	}
}
