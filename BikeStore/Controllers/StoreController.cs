using BikeDataAccess;
using BikeDataAccess.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace BikeStore.Controllers
{
    public class StoreController : Controller
    {
        private GoodRepository _goodRepository;
        private ApplicationDbContext _context;

        public StoreController()
        {
            _context = new ApplicationDbContext();
            _goodRepository = new GoodRepository(_context);
        }

        public ActionResult ShowGoods()
        {
            return View();
        }

        public JsonResult getGoods()
        {
            return Json(_goodRepository.Get(), JsonRequestBehavior.AllowGet);
        }
    }
}