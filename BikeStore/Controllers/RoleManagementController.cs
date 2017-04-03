using System.Web;
using System.Web.Mvc;
using Microsoft.AspNet.Identity;
using BikeStore.Models;
using Microsoft.AspNet.Identity.Owin;

namespace BikeStore.Controllers
{
    public class RoleManagementController : Controller
    {
        private ApplicationUserManager _userManager;
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

        // GET: RoleManagement
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult RoleManagementView()
        {
            return View();
        }



        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize(Roles = "Admin")]
        public ActionResult AssignRole(ApplicationUser username)
        {
            var user = UserManager.FindByEmail(username.Email);
            UserManager.AddToRole(user.Id, "Moderator");

            return View();
        }
        
    }
}