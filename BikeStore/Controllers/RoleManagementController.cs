using System.Web;
using System.Web.Mvc;
using Microsoft.AspNet.Identity;
using BikeStore.Models;
using Microsoft.AspNet.Identity.Owin;
using BikeDataAccess;

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

        public ActionResult RoleManagementView()
        {
            return View();
        }

        [Authorize(Roles = "Admin")]
        public JsonResult GetUsersJSON()
        {
            return Json(repo.GetUserList(), JsonRequestBehavior.AllowGet);
        }
        
        [Authorize(Roles = "Admin")]
        public ActionResult AssignRole(string id)
        {
            var user = UserManager.FindById(id);
            UserManager.AddToRole(user.Id, "Moderator");

            return RedirectToAction("RoleManagementView");
        }
        
    }
}