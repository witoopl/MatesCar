using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MatesCarSite.Models;
using MatesCarSite.ViewModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace MatesCarSite.Controllers
{
    [Authorize(Roles = "Admins")]
    public class AdminController : Controller
    {
        #region Private members/local variables
        private IUserValidator<ApplicationUser> userValidator;
        private IPasswordValidator<ApplicationUser> passwordValidator;
        private IPasswordHasher<ApplicationUser> passwordHasher;
        
        private UserManager<ApplicationUser> userManager;
        #endregion

        #region Constructor
        public AdminController(UserManager<ApplicationUser> _userManager,
            IUserValidator<ApplicationUser> _userValidator,
            IPasswordValidator<ApplicationUser> _passwordValidator,
            IPasswordHasher<ApplicationUser> _passwordHasher)
        {   
            userManager = _userManager;
            userValidator = _userValidator;
            passwordValidator = _passwordValidator;
            passwordHasher = _passwordHasher;
        }
        #endregion

        #region Actions
        
        public IActionResult Index() => View(userManager.Users);

        public ViewResult Create() => View();


        [HttpPost]
        public async Task<IActionResult> Create(CreateUserByAdminViewModel model)
        {
            if (ModelState.IsValid)
            {
                ApplicationUser user = new ApplicationUser
                {
                    UserName = model.Name,
                    Email = model.Email,
                    UserFirstName = model.UserFirstName,
                    UserSurname = model.UserSurname
                };
                IdentityResult result = await userManager.CreateAsync(user, model.Password);

                if (result.Succeeded)
                {
                    return RedirectToAction("Index");
                }
                else
                {
                    foreach (IdentityError error in result.Errors)
                    {
                        ModelState.AddModelError("", error.Description);
                    }
                }
            }
            return View(model);
        }

        [HttpPost]
        public async Task<IActionResult> Delete(string id)
        {
            ApplicationUser user = await userManager.FindByIdAsync(id);
            if (user != null)
            {
                IdentityResult result = await userManager.DeleteAsync(user);
                if (result.Succeeded)
                {
                    return RedirectToAction("Index");
                }
                else
                {
                    AddErrorsFromResult(result);
                }
            }
            else
                ModelState.AddModelError("", "User Not Found");
            return View("Index", userManager.Users);
        }

        public async Task <IActionResult> Edit(string id)
        {
            ViewData.Add("Title", "To jest tytuł tej strony z viewdaty");
            ApplicationUser user = await userManager.FindByIdAsync(id);
            if(user != null)
            {
                return View(user);
            }
            else
            {
                return RedirectToAction("Index");
            }
        }

        [HttpPost]
        public async Task<IActionResult> Edit(string id, string email, string password)
        {
            ApplicationUser user = await userManager.FindByIdAsync(id);
            if (user != null)
            {
                user.Email = email;
                IdentityResult validEmail = await userValidator.ValidateAsync(userManager, user);
                if (!validEmail.Succeeded)
                {
                    AddErrorsFromResult(validEmail);
                }
                IdentityResult validPass = null;
                if (!string.IsNullOrEmpty(password))
                {
                    validPass = await passwordValidator.ValidateAsync(userManager, user, password);
                    if (validPass.Succeeded)
                    {
                        user.PasswordHash = passwordHasher.HashPassword(user, password);
                    }
                    else
                    {
                        AddErrorsFromResult(validPass);
                    }
                }
                if ((validEmail.Succeeded && validPass == null) || (validEmail.Succeeded && password != string.Empty && validPass.Succeeded))
                {
                    IdentityResult result = await userManager.UpdateAsync(user);
                    if (result.Succeeded)
                    {
                        return RedirectToAction("Index");
                    }
                    else
                    {
                        AddErrorsFromResult(result);
                    }   
                }
            }
            else
            {
                ModelState.AddModelError("", "User Not Found");
            }
            return View(user);

        }



        #endregion

        #region local functions
        private void AddErrorsFromResult(IdentityResult result)
        {
            foreach (IdentityError error in result.Errors)
            {
                ModelState.AddModelError("", error.Description);
            }
        }
        #endregion
    }
}