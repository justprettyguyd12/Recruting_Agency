using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Recruting_Agency_POP.Data.Models;
using Recruting_Agency_POP.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;

namespace Recruting_Agency_POP.Controllers
{
    public class AccountController : Controller
    {
        private UserManager<AppUser> UserMgr;
        private SignInManager<AppUser> SignInMgr;

        public AccountController(UserManager<AppUser> userManager, 
            SignInManager<AppUser> signInManager)
        {
            UserMgr = userManager;
            SignInMgr = signInManager;
        }

        public async Task<IActionResult> Logout()
        {
            await SignInMgr.SignOutAsync();
            return RedirectToAction("Index", "Home");
        }

        [HttpPost]
        public async Task<IActionResult> Login(LoginViewModel model)
        {
            if (ModelState.IsValid)
            {
                var result = await SignInMgr.PasswordSignInAsync("TestUser", "Test123!", true, true);
                if (result.Succeeded)
                {
                    var claims = new List<Claim>
                    {
                        new Claim("demo", "value")
                    };
                    var claimPrincipal = new ClaimsPrincipal(new ClaimsIdentity(claims, "Cookie"));
                    await HttpContext.SignInAsync("Cookie", claimPrincipal);
                    

                    return RedirectToAction("Index", "Home");
                }
                else
                {
                    ViewBag.Result = "result is: " + result.ToString();
                }
                return View();
            }
            else
                return View();
        }

        
        public IActionResult Login()
        {
            return View();
        }

        public IActionResult Register()
        {
            return View();
        }

        
        [HttpPost]
        public async Task<IAsyncResult> Register(AppUser user, string password)
        {
            try
            {
                ViewBag.Message = "Пользователь уже зарегистрирован";

                AppUser findUser = await UserMgr.FindByNameAsync(user.UserName);
                if (ModelState.IsValid && findUser == null)
                {
                    IdentityResult result = await UserMgr.CreateAsync(user, password);
                    ViewBag.Message = "Пользователь добавлен!";
                }
            }
            catch (Exception ex)
            {
                ViewBag.Message = ex.Message;
            }

            /* Здесь у меня возникли трудности, которые я пока не решил - чтобы я не прописывал в return, 
             * ничего не приводится к типу ISyncResult*/
            return (IAsyncResult)RedirectToAction("Home", "Index");
        }
        
    }
}
