﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace MatesCarSite.Controllers
{
    public class RoleAdminController : Controller
    {
        #region Private members

        private RoleManager<IdentityRole> roleManager;

        #endregion

        #region Constructor

        public RoleAdminController(RoleManager<IdentityRole> _roleManager)
        {
            roleManager = _roleManager;
        }

        #endregion

        #region Actions

        public IActionResult Index()
        {
            return View(roleManager.Roles);
        }

        public IActionResult Create() => View();

        [HttpPost]
        public async Task<IActionResult> Create([Required]string name)
        {
            if (ModelState.IsValid)
            {
                IdentityResult result = await roleManager.CreateAsync(new IdentityRole(name));
                if (result.Succeeded)
                {
                    return RedirectToAction("Index");
                }
                else AddErrorsFromResult(result);
            }
            return View(name);
        }

        [HttpPost]
        public async Task<IActionResult> Delete(string id)
        {
            IdentityRole role = await roleManager.FindByIdAsync(id);
            if (role != null)
            {
                IdentityResult result = await roleManager.DeleteAsync(role);
                if (result.Succeeded) return RedirectToAction("Index");
                else AddErrorsFromResult(result);
            }
            else ModelState.AddModelError("", "No role found");
            return View("Index", roleManager.Roles);
        }

        #endregion

        #region Helper functions

        private void AddErrorsFromResult(IdentityResult result)
        {
            foreach(IdentityError error in result.Errors)
            {
                ModelState.AddModelError("", error.Description);
            }
        }

        #endregion
    }
}