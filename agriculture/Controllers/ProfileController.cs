using agriculture.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace agriculture.Controllers
{
    public class ProfileController : Controller
    {
        private readonly UserManager<IdentityUser> _userManager;

        public ProfileController(UserManager<IdentityUser> userManager)
        {
            _userManager = userManager;
        }
        
        public async Task<IActionResult>Index()
        {
            var values = await _userManager.FindByNameAsync(User.Identity.Name);
            UserViewModel userEditViewModel = new UserViewModel();
            userEditViewModel.userName = values.UserName;
            userEditViewModel.phone = values.PhoneNumber;
            userEditViewModel.mail = values.Email;
           

            return View(userEditViewModel);
        }
        [HttpPost]
        public async Task<IActionResult> Index(UserViewModel p)
        {
            var values = await _userManager.FindByNameAsync(User.Identity.Name);
            if (p.password==p.confirmpassword)
            {
                values.UserName=p.userName;
                values.Email=p.mail;
                values.PhoneNumber=p.phone;
                values.PasswordHash = _userManager.PasswordHasher.HashPassword(values, p.password);
                var result =  await _userManager.UpdateAsync(values);
                if (result.Succeeded)
                {
                    return RedirectToAction("Index", "Login");
                }
            }
            return View();
        }
        

    }
}
