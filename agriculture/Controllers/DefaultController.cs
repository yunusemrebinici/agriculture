﻿using BusinessLayer.Abstract;
using EntityLayer.Concrete;
using FluentValidation.Validators;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace agriculture.Controllers
{
	[AllowAnonymous]
	public class DefaultController : Controller
	{
		private readonly IContactService _contactService;

		public DefaultController(IContactService contactService)
		{
			_contactService = contactService;
		}

		public IActionResult Index()
		{
			return View();
		}

		[HttpGet]
		public PartialViewResult SendMessage()
		{
			return PartialView(); 
		}
		[HttpPost]
		public IActionResult SendMessage(Contact contact)
		{
			_contactService.Insert(contact);
			return RedirectToAction("Index","Default"); 
		}
		public PartialViewResult ScriptPartial()
		{

			return PartialView();
		}


	}

	
}
