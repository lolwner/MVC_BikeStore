using BikeStore.Models.Store;
using Microsoft.AspNet.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace BikeStore.Controllers
{
    public class StoreController : Controller
    {
        private static StoreContext DB = new StoreContext();

        public static string User_Id = System.Web.HttpContext.Current.User.Identity.GetUserId();

        // GET: Store
        public ActionResult ShowGoods()
        {
            return View();
        }

        public JsonResult getGoods()
        {
            IEnumerable<Good> goods = DB.Goods;
            var JsonGoods = goods.ToList();
            return Json(JsonGoods, JsonRequestBehavior.AllowGet);
        }
    }
}