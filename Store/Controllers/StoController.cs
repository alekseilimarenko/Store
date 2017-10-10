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


            return PartialView(repCost);
        }
    }
}