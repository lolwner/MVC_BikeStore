using System.Web;
using System.Web.Mvc;
using Microsoft.AspNet.Identity;
using BikeStore.Models;
using Microsoft.AspNet.Identity.Owin;
using BikeDataAccess;
using BikeEntities.Base;

namespace BikeStore.Controllers
{
    public class RoleManagementController : Controller
    {
        UserRepository repo;
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

        [Authorize(Roles = nameof(Roles.Admin))]
        public ActionResult RoleManagementView()
        {
            return View();
        }

        [Authorize(Roles = nameof(Roles.Admin))]
        public JsonResult GetUsersJSON()
        {
            return Json(repo.GetUserList(), JsonRequestBehavior.AllowGet);
        }
        
        [Authorize(Roles = nameof(Roles.Admin))]
        public ActionResult AssignRole(string id)
        {
            var user = UserManager.FindById(id);
            UserManager.AddToRole(user.Id, nameof(Roles.Moderator));

            return RedirectToAction("RoleManagementView");
        }
        
    }
}