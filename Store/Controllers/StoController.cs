using System.Collections.Generic;
using System.Web.Mvc;
using Store.Models;

namespace Store.Controllers
{
    public class StoController : Controller
    {
        // GET: Sto
        public ActionResult Index()
        {
            ViewBag.TransportType = new SelectList(
                new List<SelectListItem>
                {
                    new SelectListItem { Text = "Легковые", Value = "1"},
                    new SelectListItem { Text = "Грузовые", Value = "2"},
                    new SelectListItem { Text = "Автобусы", Value = "3"},
                }, "Value", "Text");


            return View();
        }

        [HttpPost]
        public ActionResult GetTransportType(int? id)
        {
            switch (id)
            {
                case 1:
                    return View("_PartCar", new OrderModel());
                case 2:
                    return View("_PartTruck", new OrderModel());
                case 3:
                    return View("_PartBus", new OrderModel());
            }

            return new EmptyResult();
        }

        public ActionResult GetRepearCost(OrderModel ordModel)
        {
            var repCost = new ResultModel();

            if (ModelState.IsValid)
            {
                switch (ordModel.Type)
                {
                    case 1:
                        repCost.RepearCost = ordModel.Body * 10 + ordModel.Wheels * 10
                                             + ordModel.Engine * 10 + ordModel.Breaks * 10 + ordModel.Suspension * 10;

                        repCost.GeneralState = (ordModel.Body + ordModel.Wheels
                                                + ordModel.Engine + ordModel.Breaks + ordModel.Suspension) / 5;

                        if (ordModel.WheelBalancing)
                        {
                            repCost.Amount = repCost.RepearCost + 100;
                            repCost.AddServ = "балансировка колес";
                        }
                        else
                        {
                            repCost.Amount = repCost.RepearCost;
                            repCost.AddServ = "";
                        }
                        break;
                    case 2:
                        repCost.GeneralState = (ordModel.Body + ordModel.Wheels
                                                + ordModel.Engine + ordModel.Breaks + ordModel.Suspension +
                                                ordModel.Hydraulics) / 6;

                        repCost.Amount = repCost.RepearCost = ordModel.Body * 10 + ordModel.Wheels * 10
                                                              + ordModel.Engine * 10 + ordModel.Breaks * 10 +
                                                              ordModel.Suspension * 10 +
                                                              ordModel.Hydraulics * 10;

                        repCost.AddServ = "";
                        break;
                    case 3:
                        repCost.RepearCost = ordModel.Body * 10 + ordModel.Wheels * 10
                                             + ordModel.Engine * 10 + ordModel.Breaks * 10 + ordModel.Suspension * 10 +
                                             ordModel.Cabin * 10;

                        repCost.GeneralState = (ordModel.Body + ordModel.Wheels
                                                + ordModel.Engine + ordModel.Breaks + ordModel.Suspension +
                                                ordModel.Cabin) / 6;

                        if (ordModel.ChangeSeat)
                        {
                            repCost.Amount = repCost.RepearCost + 300;
                            repCost.AddServ = "смена обивки сидений в салоне";
                        }
                        else
                        {
                            repCost.Amount = repCost.RepearCost;
                            repCost.AddServ = "";
                        }
                        break;
                }

            }

            return PartialView(repCost);
        }
    }
}