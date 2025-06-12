using agriculture.Models;
using BusinessLayer.Abstract;
using EntityLayer.Concrete;
using Microsoft.AspNetCore.Mvc;

namespace agriculture.Controllers
{
    public class ServiceController : Controller
    {
        private readonly IServiceService _serviceService;

        public ServiceController(IServiceService serviceService)
        {
            _serviceService = serviceService;
        }

        public IActionResult Index()
        {
            var value=_serviceService.GetListAll();         
            return View(value);
        }
        [HttpGet]
        public IActionResult AddService()
        {
            return View();  
        }
        [HttpPost]
        public IActionResult AddService(Service service)
        {
            _serviceService.Insert(service);
			return RedirectToAction("Index");
			           
		}
        
        public IActionResult Delete(int id)
        {
            var value =_serviceService.GetById(id);
            _serviceService.Delete(value);
            return RedirectToAction("Index");
        }

        [HttpGet]
        public IActionResult EditService(int id) 
        {
            var value=_serviceService.GetById(id);
            return View(value);        
        }
        [HttpPost]
        public IActionResult EditService (Service service)
        {
            _serviceService.Update(service);
            return RedirectToAction("Index");
        }
       
    }
}
