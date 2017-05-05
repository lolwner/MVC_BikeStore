﻿using System.Web;
using System.Web.Mvc;
using Microsoft.AspNet.Identity;
using BikeStore.Models;
using Microsoft.AspNet.Identity.Owin;
using BikeDataAccess;

namespace BikeStore.Controllers
{
    public class RoleManagementController : Controller
    {
        IUserRepository repo;
        private ApplicationUserManager _userManager;

        public RoleManagementController()
        {
            repo = new UserRepository();
        }
        
        public ApplicationUserManager UserManager
        {
            get
            {
                return _userManager ?? Request.GetOwinContext().GetUserManager<ApplicationUserManager>();
            }
            private set
            {
                _userManager = value;
            }
        }

        public ActionResult RoleManagementView()
        {
            return View(repo.GetUserList());
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize(Roles = "Admin")]
        public ActionResult AssignRole(ApplicationUser username)
        {
            var user = UserManager.FindByEmail(username.Email);
            UserManager.AddToRole(user.Id, "Moderator");

            return RedirectToAction("RoleManagementView");
        }
        
    }
}