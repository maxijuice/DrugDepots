using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Depots.DAL.Interface.Repositories;
using Depots.ORM.Entities;
using Depots.WebUI.Models;

namespace Depots.WebUI.Controllers
{
    public class DrugUnitsController : Controller
    {
        private readonly IDrugUnitRepository drugUnits;
        private readonly IDepotRepository depots;
        public int PageSize = 5;

        public DrugUnitsController(IDepotRepository depotRepo, IDrugUnitRepository drugUnitRepo)
        {
            drugUnits = drugUnitRepo;
            depots = depotRepo;
        }

        public ActionResult List(int page = 1)
        {
            DrugUnitsListViewModel model = new DrugUnitsListViewModel()
            {
                DrugUnits = drugUnits.GetAll()
                    .OrderBy(u => u.DrugTypeId)
                    .Skip((page - 1)*PageSize)
                    .Take(PageSize),
                PagingInfo = new PagingInfo()
                {
                    CurrentPage = page,
                    ItemsPerPage = PageSize,
                    TotalItems = drugUnits.GetAll().Count()
                },
                ExistingDepots = depots.GetAll()
            };

            return View(model);
        }

        [HttpPost]
        public ActionResult AssingDrugUnitToDepot(string drugUnitId, int? depotId, string returnUrl)
        {
            DrugUnit drugUnitToUpdate = drugUnits.GetById(drugUnitId);
            drugUnitToUpdate.DepotId = depotId;
            drugUnits.Update(drugUnitToUpdate);

            return RedirectToAction("List", new { returnUrl });
        }
    }
}