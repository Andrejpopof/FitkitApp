using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FitKitApp.Data;
using FitKitApp.Models;
using FitKitApp.ViewModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace FitKitApp.Controllers
{

    [Authorize]
    public class AccountController : Controller
    {

        private UserManager<AppUser> userManager;
        private SignInManager<AppUser> signInManager;
        private IPasswordValidator<AppUser> passwordValidator;
        private IPasswordHasher<AppUser> passwordHasher;
        private IUserValidator<AppUser> userValidator;
        private readonly FitKitAppContext _context;

        public AccountController(UserManager<AppUser> userMgr, SignInManager<AppUser> signinMgr, IPasswordHasher<AppUser> passwordHash, IPasswordValidator<AppUser> passwordVal, IUserValidator<AppUser> userValid, FitKitAppContext context)
        {
            userManager = userMgr;
            signInManager = signinMgr;
            passwordHasher = passwordHash;
            passwordValidator = passwordVal;
            userValidator = userValid;
            _context = context;

        }

        [AllowAnonymous]
        public IActionResult Login(string returnUrl)
        {
            Login login = new Login();
            login.ReturnUrl = returnUrl;
            return View(login);
        }

        [HttpPost]
        [AllowAnonymous]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Login(Login login)
        {
            if (ModelState.IsValid)
            {
                AppUser appUser = await userManager.FindByEmailAsync(login.Email);
                if (appUser != null)
                {
                    await signInManager.SignOutAsync();
                    Microsoft.AspNetCore.Identity.SignInResult result = await signInManager.PasswordSignInAsync(appUser, login.Password, false, false);
                    if (result.Succeeded)
                    {
                        if(await userManager.IsInRoleAsync(appUser,"Admin"))
                        {
                            return RedirectToAction("Index", "Objekts", null);
                        }
                        if(await userManager.IsInRoleAsync(appUser,"User"))
                        {
                            return RedirectToAction("KorisnikUvid", "Zaclenuvanjes", new { id = appUser.UserId});
                        }
                        if(await userManager.IsInRoleAsync(appUser,"Coach"))
                        {
                            return RedirectToAction("TrenerUvid", "Zaclenuvanjes", new { id = appUser.CoachId});
                        }

                    }
                }
                ModelState.AddModelError(nameof(login.Email), "Login Failed: Invalid Email or password");
            }
            return View(login);
        }
        public async Task<IActionResult>Logout()
        {
            await signInManager.SignOutAsync();
            return RedirectToAction("Login", "Account");
        }

     


        public IActionResult Index()
        {
            return View();
        }
    }
}
