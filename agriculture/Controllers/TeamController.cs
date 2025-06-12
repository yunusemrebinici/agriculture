using BusinessLayer.Abstract;
using BusinessLayer.ValidationRules;
using EntityLayer.Concrete;
using FluentValidation.Results;
using Microsoft.AspNetCore.Mvc;


namespace agriculture.Controllers
{
    public class TeamController : Controller
    {
        private readonly ITeamService _service;

        public TeamController(ITeamService service)
        {
            _service = service;
        }

        public IActionResult Index()
        {
            var values =_service.GetListAll();
            return View(values);
        }
        [HttpGet]
        public IActionResult AddTeam() 
        {
            return View();
        }
        [HttpPost]
		public IActionResult AddTeam(Team team)
		{
            TeamValidator validationRules = new TeamValidator();
            ValidationResult result = validationRules.Validate(team);
            if (result.IsValid)
            {
				_service.Insert(team);
				return RedirectToAction("Index");
			}
            else
            {
                foreach (var item in result.Errors)
                {
                    ModelState.AddModelError(item.PropertyName, item.ErrorMessage);
                }
            }
			return View();  
		}
        public IActionResult DeleteTeam(int id)
        {
            var values=_service.GetById(id);
            _service.Delete(values);
            return RedirectToAction("Index");
        }
        [HttpGet]
        public IActionResult EditTeam(int id)
        {
            var values=_service.GetById(id);
            return View(values);
        }
        [HttpPost]
        public IActionResult EditTeam(Team team)
        {
            TeamValidator validator = new TeamValidator();
            ValidationResult result = validator.Validate(team);
            if (result.IsValid)
            {
                _service.Update(team);
				return RedirectToAction("Index");
			}
            else
            {
                foreach (var item in result.Errors)
                {
                    ModelState.AddModelError(item.PropertyName, item.ErrorMessage);
                }
            }
			return View();
		}
	}
}
