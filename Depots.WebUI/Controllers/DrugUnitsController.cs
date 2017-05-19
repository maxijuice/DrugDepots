using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Depots.BLL.Interface.DTO;
using Depots.BLL.Interface.Services;
using Depots.DAL.Interface.Repositories;
using Depots.ORM.Entities;
using Depots.WebUI.Models;

namespace Depots.WebUI.Controllers
{
    public class DrugUnitsController : Controller
    {
        private readonly IDrugUnitService drugUnits;
        private readonly IDepotService depots;
        public int PageSize = 10;

        public DrugUnitsController(IDrugUnitService drugUnitService, IDepotService depotService)
        {
            drugUnits = drugUnitService;
            depots = depotService;
        }

        public ActionResult List(int page = 1)
        {
            DrugUnitsListViewModel model = new DrugUnitsListViewModel()
            {
                DrugUnits = drugUnits.GetPage(page, PageSize),
                PagingInfo = new PagingInfo()
                {
                    CurrentPage = page,
                    ItemsPerPage = PageSize,
                    TotalItems = drugUnits.CountUnits
                },
                ExistingDepots = depots.GetAll()
            };

            return View(model);
        }
        
        [HttpPost]
        public ActionResult AssociateUnitToDepot(string drugUnitId, int? depotId, int page = 1)
        {
            if (drugUnitId != null)
            {
                DrugUnitDTO unitToUpdate = drugUnits.GetById(drugUnitId);
                if (depotId == null)
                    unitToUpdate.Depot = null;
                else
                {
                    if (unitToUpdate.Depot == null)
                    {
                        unitToUpdate.Depot = new DepotDTO() {DepotId = (int) depotId};
                    }
                    else
                    {
                        unitToUpdate.Depot.DepotId = (int)depotId;
                    }                   
                }
                    
                drugUnits.UpdateUnit(unitToUpdate);
            } 

            return RedirectToAction("List", new { page });
        }
    }
}