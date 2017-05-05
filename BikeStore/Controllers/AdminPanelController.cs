using BikeDataAccess;
using BikeEntities;
using BikeStore.Models;
using BikeViewModels;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;

namespace BikeStore.Controllers
{


    public class AdminPanelController : Controller
    {
        IGoodRepository repo;

        public AdminPanelController()
        {
            repo = new GoodRepository();
        }

        [Authorize(Roles = "Moderator, Admin")]
        public ActionResult ControlPanel()
        {
            return View();
        }

        [Authorize(Roles = "Moderator, Admin")]
        public JsonResult GetGoodsJSON()
        {
            //return Json(new { items = repo.GetGoodList().Select(item => new { Name = item.Name, ID = item.Good_ID, Price = item.Price, Amount = item.Amount }) },
            //    JsonRequestBehavior.AllowGet);
            return Json(repo.GetGoodList(), JsonRequestBehavior.AllowGet);
        }

        [Authorize(Roles = "Moderator, Admin")]
        public ActionResult Edit(int? id)
        {
            Good good = new Good();
            GoodViewModel goodViewModel = new GoodViewModel();

            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            good = repo.GetGood(id);

            if (good == null)
            {
                return HttpNotFound();
            }

            goodViewModel.Good_ID = good.Good_ID;
            goodViewModel.Name = good.Name;
            goodViewModel.Price = good.Price;
            goodViewModel.Manufacturer_ID = good.Manufacturer_ID;
            goodViewModel.Amount = good.Amount;
            goodViewModel.Type_ID = good.Type_ID;
            goodViewModel.Description = good.Description;
            goodViewModel.ManufacturerVM = repo.GetManufacturersList();
            goodViewModel.TypeVM = repo.GetTypesList();
            
            return View(goodViewModel);
        }

        [Authorize(Roles = "Moderator, Admin")]
        [HttpPost, ActionName("Edit")]
        [ValidateAntiForgeryToken]
        public ActionResult EditPost(GoodViewModel goodViewModel)
        {
            var good = new Good();

            if (goodViewModel == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            good = repo.GetGood(goodViewModel.Good_ID);

            if (TryUpdateModel(good, "",
               new string[] { "Name", "Price", "Description", "Manufacturer_ID", "Type_ID", "Amount" }))
            {
                try
                {
                    repo.Save();
                    return RedirectToAction("ControlPanel");
                }
                catch (RetryLimitExceededException /* dex */)
                {
                    //Log the error (uncomment dex variable name and add a line here to write a log.
                    ModelState.AddModelError("", "Unable to save changes. Try again, and if the problem persists, see your system administrator.");
                }
            }
            return View(good);
        }

        [Authorize(Roles = "Moderator, Admin")]
        public ActionResult Create()
        {
            GoodViewModel goodViewModel = new GoodViewModel();

            goodViewModel.ManufacturerVM = repo.GetManufacturersList();
            goodViewModel.TypeVM = repo.GetTypesList();

            return View(goodViewModel);
        }

        [Authorize(Roles = "Moderator, Admin")]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Name, Price, Description, Amount, Manufacturer_ID, Type_ID")]Good good)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    repo.CreateGood(good);
                    repo.Save();
                    return RedirectToAction("ControlPanel");
                }
            }
            catch (DataException /* dex */)
            {
                //Log the error (uncomment dex variable name and add a line here to write a log.
                ModelState.AddModelError("", "Unable to save changes. Try again, and if the problem persists see your system administrator.");
            }
            return View(good);
        }

        [Authorize(Roles = "Moderator, Admin")]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id)
        {
            try
            {
                Good good = repo.GetGood(id);
                repo.Delete(good.Good_ID);
                repo.Save();
            }
            catch (RetryLimitExceededException/* dex */)
            {
                //Log the error (uncomment dex variable name and add a line here to write a log.
                return RedirectToAction("Delete", new { id = id, saveChangesError = true });
            }
            return RedirectToAction("ControlPanel");
        }

    }
}