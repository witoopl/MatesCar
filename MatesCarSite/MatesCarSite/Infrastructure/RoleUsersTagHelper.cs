﻿using System.Collections.Generic;
using System.Threading.Tasks;
using MatesCarSite.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Razor.TagHelpers;

namespace MatesCarSite.Infrastructure
{
    [HtmlTargetElement("td", Attributes = "identity-role")]
    public class RoleUsersTagHelper : TagHelper
    {
        #region Private members

        private UserManager<ApplicationUser> userManager;
        private RoleManager<IdentityRole> roleManager;

        #endregion

        #region Constructor

        public RoleUsersTagHelper(UserManager<ApplicationUser> _userManager, RoleManager<IdentityRole> _roleManager)
        {
            userManager = _userManager;
            roleManager = _roleManager;
        }

        #endregion

        [HtmlAttributeName("identity-role")]
        public string Role { get; set; }

        public override async Task ProcessAsync(TagHelperContext context, TagHelperOutput output)
        {
            List<string> names = new List<string>();
            IdentityRole role = await roleManager.FindByIdAsync(Role);
            if (role != null)
            {
                foreach (var user in userManager.Users)
                {
                    if (user!=null && await userManager.IsInRoleAsync(user, role.Name))
                    {
                        names.Add(user.UserName);
                    }
                }
            }

            output.Content.SetContent(names.Count == 0 ? "No users" : string.Join(", ", names));
        }

    }
}