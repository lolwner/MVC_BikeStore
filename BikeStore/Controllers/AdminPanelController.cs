using BikeDataAccess;
using BikeDataAccess.Repositories;
using BikeEntities;
using BikeEntities.Base;
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
        private ApplicationDbContext _context;
        private ManufacturerRepository _manufacturerRepository;
        private TypeRepository _typeRepository;
        private GoodRepository _goodRepository;

        public AdminPanelController()
        {
            _context = new ApplicationDbContext();
            _manufacturerRepository = new ManufacturerRepository(_context);
            _typeRepository = new TypeRepository(_context);
            _goodRepository = new GoodRepository(_context);
        }

        [Authorize(Roles = nameof(Roles.Moderator))]
        public ActionResult ControlPanel()
        {
            return View();
        }

        [Authorize(Roles = nameof(Roles.Moderator))]
        public JsonResult GetGoodsJSON()
        {
            return Json(_goodRepository.Get(), JsonRequestBehavior.AllowGet);
        }

        [Authorize(Roles = nameof(Roles.Moderator))]
        public ActionResult Edit(string id)
        {
            Good good = new Good();
            GoodViewModel goodViewModel = new GoodViewModel();

            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            good = _goodRepository.GetByID(id);

            if (good == null)
            {
                return HttpNotFound();
            }

            goodViewModel.Good_ID = good.Id;
            goodViewModel.Name = good.Name;
            goodViewModel.Price = good.Price;
            goodViewModel.Manufacturer_ID = good.Manufacturer_ID;
            goodViewModel.Amount = good.Amount;
            goodViewModel.Type_ID = good.Type_ID;
            goodViewModel.Description = good.Description;
            goodViewModel.ManufacturerVM = _manufacturerRepository.Get();
            goodViewModel.TypeVM = _typeRepository.Get();
            
            return View(goodViewModel);
        }

        [Authorize(Roles = nameof(Roles.Moderator))]
        [HttpPost, ActionName("Edit")]
        [ValidateAntiForgeryToken]
        public ActionResult EditPost(GoodViewModel goodViewModel)
        {
            var good = new Good();

            if (goodViewModel == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            good = _goodRepository.GetByID(goodViewModel.Good_ID);

            if (TryUpdateModel(good, "",
               new string[] { "Name", "Price", "Description", "Manufacturer_ID", "Type_ID", "Amount" }))
            {
                try
                {
                    _goodRepository.Save();
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

        [Authorize(Roles = nameof(Roles.Moderator))]
        public ActionResult Create()
        {
            GoodViewModel goodViewModel = new GoodViewModel();

            goodViewModel.ManufacturerVM = _manufacturerRepository.Get();
            goodViewModel.TypeVM = _typeRepository.Get();

            return View(goodViewModel);
        }

        [Authorize(Roles = nameof(Roles.Moderator))]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Name, Price, Description, Amount, Manufacturer_ID, Type_ID")]Good good)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    _goodRepository.Insert(good);
                    _goodRepository.Save();
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

        [Authorize(Roles = nameof(Roles.Moderator))]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(string id)
        {
            try
            {
                _goodRepository.Delete(id);
                _goodRepository.Save();
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