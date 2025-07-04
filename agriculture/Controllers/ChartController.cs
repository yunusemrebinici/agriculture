﻿using agriculture.Models;
using BusinessLayer.Abstract;
using Microsoft.AspNetCore.Mvc;

namespace agriculture.Controllers
{
	public class ChartController : Controller
	{
		private readonly IProductService _productService;

		public ChartController(IProductService productService)
		{
			_productService = productService;
		}

		public IActionResult Index()
		{
			var values = _productService.GetListAll();
			return View(values);
		}
	
	}
}
