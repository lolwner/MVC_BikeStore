using BikeStore.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace BikeStore.Controllers
{
    public class StoreController : Controller
    {
        ApplicationDbContext db = new ApplicationDbContext();

        public ActionResult ShowGoods()
        {
            return View();
        }

        public JsonResult getGoods()
        {
                return Json(db.Goods.ToList(), JsonRequestBehavior.AllowGet);
            
        }
    }
}