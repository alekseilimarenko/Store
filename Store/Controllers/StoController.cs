using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
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

            if (ordModel.Hydraulics != null)
            {
                repCost.GeneralState = (ordModel.Body + ordModel.Wheels
                        + ordModel.Engine + ordModel.Breaks + ordModel.Suspension +
                        (int)ordModel.Hydraulics) / 6;

                repCost.Amount = ordModel.Body*10 + ordModel.Wheels*10
                        + ordModel.Engine*10 + ordModel.Breaks*10 + ordModel.Suspension*10 +
                        (int)ordModel.Hydraulics * 10;
            }
            else if(ordModel.Cabin != null)
            {
                repCost.GeneralState = (ordModel.Body + ordModel.Wheels
                       + ordModel.Engine + ordModel.Breaks + ordModel.Suspension +
                       (int)ordModel.Cabin) / 6;
                if (ordModel.ChangeSeat)
                {
                    repCost.Amount = ordModel.Body * 10 + ordModel.Wheels * 10
                          + ordModel.Engine * 10 + ordModel.Breaks * 10 + ordModel.Suspension * 10 +
                          (int)ordModel.Cabin * 10 + 300;
                }
                else
                {
                    repCost.Amount = ordModel.Body * 10 + ordModel.Wheels * 10
                         + ordModel.Engine * 10 + ordModel.Breaks * 10 + ordModel.Suspension * 10 +
                         (int)ordModel.Cabin * 10;
                }
            }
            else
            {
                repCost.GeneralState = (ordModel.Body + ordModel.Wheels
                         + ordModel.Engine + ordModel.Breaks + ordModel.Suspension) / 5;
                if(ordModel.WheelBalancing)
                {
                    repCost.Amount = ordModel.Body * 10 + ordModel.Wheels * 10
                        + ordModel.Engine * 10 + ordModel.Breaks * 10 + ordModel.Suspension * 10 + 100;
                }
                else
                {
                    repCost.Amount = ordModel.Body * 10 + ordModel.Wheels * 10
                        + ordModel.Engine * 10 + ordModel.Breaks * 10 + ordModel.Suspension * 10;
                }
            }

            return PartialView(repCost);
        }
    }
}