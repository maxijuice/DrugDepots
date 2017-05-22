using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Depots.BLL.Interface.Services;
using Depots.WebUI.Models;

namespace Depots.WebUI.Controllers
{
    public class DepotsController : Controller
    {
        private IDrugUnitService drugUnits;
        private IDepotService depots;
        public int PageSize = 10;
        public DepotsController(IDrugUnitService drugUnitService, IDepotService depotService)
        {
            drugUnits = drugUnitService;
            depots = depotService;
        }

        public ActionResult List(int page = 1)
        {
            DepotsListViewModel depotsPerPage = GetDepotsViewModel(page);

            return View(depotsPerPage);
        }

        public ActionResult DepotsCapacity(int page = 1)
        {
            DepotsListViewModel depotsPerPage = GetDepotsViewModel(page);

            return View(depotsPerPage);
        }

        private DepotsListViewModel GetDepotsViewModel(int page)
        {
            IEnumerable<DepotViewModel> depotsPerPage = depots.GetPage(page, PageSize).Select(depot => new DepotViewModel()
            {
                Depot = depot,
                DepotDrugUnits = drugUnits.GetByDepot(depot.DepotId)
            });

            DepotsListViewModel model = new DepotsListViewModel()
            {
                Depots = depotsPerPage,
                PagingInfo = new PagingInfo()
                {
                    CurrentPage = page,
                    ItemsPerPage = PageSize,
                    TotalItems = depots.Count
                }
            };

            return model;
        } 
    }
}