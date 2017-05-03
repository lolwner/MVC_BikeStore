using BikeDataAccess;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace BikeStore.Controllers
{
    public class StoreController : Controller
    {
        IGoodRepository repo;

        public StoreController()
        {
            repo = new GoodRepository();
        }

        public ActionResult ShowGoods()
        {
            return View();
        }

        public JsonResult getGoods()
        {
            return Json(repo.GetGoodList(), JsonRequestBehavior.AllowGet);
        }
    }
}