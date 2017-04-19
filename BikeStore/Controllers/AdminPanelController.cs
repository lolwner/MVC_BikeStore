using BikeStore.Models.Store;
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
        private static StoreContext DB = new StoreContext();

        // GET: AdminPanel
        [Authorize(Roles = "Moderator, Admin")]
        public ActionResult ControlPanel()
        {
            return View(DB.Goods.ToList());
        }

        [Authorize(Roles = "Moderator, Admin")]
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Good good = DB.Goods.Find(id);
            IEnumerable<Manufacturer> manufacturers = DB.Manufacturers.ToList();
            IEnumerable<Models.Store.Type> types = DB.Types.ToList();
            GoodViewModel goodVM = new GoodViewModel
            {
                Good_ID = good.Good_ID,
                Name = good.Name,
                Price = good.Price,
                Manufacturer_ID = good.Manufacturer_ID,
                Amount = good.Amount,
                Type_ID = good.Type_ID,
                Description = good.Description,
                ManufacturerVM = manufacturers,
                TypeVM = types
            };

            if (good == null)
            {
                return HttpNotFound();
            }
            return View(goodVM);
        }

        [Authorize(Roles = "Moderator, Admin")]
        [HttpPost, ActionName("Edit")]
        [ValidateAntiForgeryToken]
        public ActionResult EditPost(GoodViewModel goodVM)
        {
            if (goodVM == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            var good = DB.Goods.Find(goodVM.Good_ID);

            if (TryUpdateModel(good, "",
               new string[] { "Name", "Price", "Description", "Manufacturer_ID", "Type_ID", "Amount" }))
            {
                try
                {
                    DB.SaveChanges();
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
            IEnumerable<Manufacturer> manufacturers = DB.Manufacturers.ToList();
            IEnumerable<Models.Store.Type> types = DB.Types.ToList();

            GoodViewModel goodVM = new GoodViewModel
            {
                ManufacturerVM = manufacturers,
                TypeVM = types
            };
            return View(goodVM);
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
                    DB.Goods.Add(good);
                    DB.SaveChanges();
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
                Good good = DB.Goods.Find(id);
                DB.Goods.Remove(good);
                DB.SaveChanges();
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