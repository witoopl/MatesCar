﻿using MatesCarSite.Models;
using MatesCarSite.ViewModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace MatesCarSite.Controllers
{
    [Authorize]
    public class AccountController : Controller
    {
        #region Private members

        private UserManager<ApplicationUser> userManager;
        private SignInManager<ApplicationUser> signInManager;

        #endregion

        #region Contructor

        public AccountController(UserManager<ApplicationUser> _userManager, SignInManager<ApplicationUser> _signInManager)
        {
            userManager = _userManager;
            signInManager = _signInManager;
        }

        #endregion

        #region Actions
        [AllowAnonymous]
        public IActionResult Login(string returnUrl)
        {
            //TODO: securing redirection to logout
            ViewBag.returnUrl = returnUrl;
            return View();
        }
        /// <summary>
        /// Recives login details and url from which user was redirected and attemps to login a user.
        /// In case of fail specific error is displayed.
        /// </summary>
        /// <param name="details">Login details provided by the model</param>
        /// <param name="returnUrl">Url from which user was redirected</param>
        /// <returns></returns>
        [HttpPost]
        [AllowAnonymous]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Login(LoginViewModel details, string returnUrl)
        {
            if (ModelState.IsValid)
            {
                ApplicationUser user = await userManager.FindByEmailAsync(details.Email);
                if(user != null)
                {
                    await signInManager.SignOutAsync();

                    Microsoft.AspNetCore.Identity.SignInResult result = await signInManager.PasswordSignInAsync(user, details.Password, false, false);

                    if (result.Succeeded)
                    {
                        return Redirect(returnUrl ?? "/");
                    }
                }
                ModelState.AddModelError(nameof(LoginViewModel.Email), "Invalid user or passowrd");
            }
            return View(details);
        }

        [Authorize]
        public async Task<IActionResult> Logout()
        {
            await signInManager.SignOutAsync();
            return RedirectToAction("Index", "Home");
        }

        [AllowAnonymous]
        public IActionResult AccessDenied()
        {
            return View();
        }
        #endregion

    }
}