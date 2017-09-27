using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
using System.Web;
using System.Web.Mvc;
using Store.DAL;
using Store.Models;

namespace Store.Controllers
{
    public class HomeController : Controller
    {
        StoreEntities db = new StoreEntities();

        public ActionResult Index()
        {
            var stores = db.routine;/*("select Id, Name from dbo.routine Group By dbo.routine.Id, dbo.routine.Name");*/

            var selected = from s in db.routine
                           group s by s.Id into g
                           select new {Id = g.Key, Name = g.Key.ToString()};   
                           
            ViewBag.Stores = new SelectList(selected, "Id", "Name");

            return View();
        }

        [HttpPost]
        public ActionResult Index(int id)
        {
            var str = id;

            return View();
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}