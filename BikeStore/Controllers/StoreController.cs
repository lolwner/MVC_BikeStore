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
        public ActionResult ShowGoods()
        {
            return View();
        }

        public JsonResult getGoods()
        {
            using (var db = new StoreContext())
            {
                return Json(db.Goods.ToList(), JsonRequestBehavior.AllowGet);
            }
        }
    }
}