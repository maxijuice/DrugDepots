using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Depots.BLL.Interface.DTO;
using Depots.BLL.Interface.Services;
using Depots.DAL.Interface.Repositories;
using Depots.WebUI.Models;

namespace Depots.WebUI.Controllers
{
    public class OrderController : Controller
    {
        private IDepotService depots;
        private IDrugUnitService drugUnits;

        public OrderController(IDepotService depotService, IDrugUnitService drugUnitService)
        {
            depots = depotService;
            drugUnits = drugUnitService;
        }

        [HttpGet]
        public ActionResult MakeOrder()
        {
            IEnumerable<DepotViewModel> allDepots = depots.GetAll().Select(depot => new DepotViewModel()
            {
                Depot = depot,
                DepotDrugUnits = drugUnits.GetByDepot(depot.DepotId)
            });

            return View(allDepots);
        }

        [HttpPost]
        public ActionResult MakeOrder(OrderViewModel order)
        {
            return new EmptyResult();
        }

        public JsonResult GetDepotDrugTypes(int? depotId)
        {
            DepotDTO depotDto = depots.GetById(depotId);
            DepotViewModel depotModel = new DepotViewModel()
            {
                Depot = depotDto,
                DepotDrugUnits = drugUnits.GetByDepot(depotDto?.DepotId)
            };

            return Json(depotModel.DepotDrugTypes, JsonRequestBehavior.AllowGet);
        }
    }
}