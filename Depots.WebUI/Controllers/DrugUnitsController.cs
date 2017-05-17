using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
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
        public int PageSize = 5;

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
                ExistingDepots = depots.GetAllDepots()
            };

            return View(model);
        }
    }
}