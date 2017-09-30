using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
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
            var selected = db.routine.GroupBy(s => s.Id).Select(g => new {Id = g.Key, Name = g.Key.ToString()});   
                           
            ViewBag.Stores = new SelectList(selected, "Id", "Name");

            return View();
        }

        [HttpPost]
        public ActionResult _PartView(int id=0)
        {
            SqlParameter param = new SqlParameter("@Id", id);
            var scheduleRes = db.Database.SqlQuery<GetSchedule_Result>("GetSchedule @Id", param);

            var schedule = String.Empty;
            var resId = String.Empty;

            foreach (var item in scheduleRes)
            {
                if (item.intervalfrom.Value.TimeOfDay != item.intervalto.Value.TimeOfDay)
                {
                    schedule = schedule + item.Shortname + 
                        " " + item.workfrom.Value.ToShortTimeString() + " - " + item.workto.Value.ToShortTimeString() + 
                        " (" + item.intervalfrom.Value.ToShortTimeString() + "-" + item.intervalfrom.Value.ToShortTimeString() + ");";
                }
                else
                {
                    schedule = schedule + item.Shortname +
                               " " + item.workfrom.Value.ToShortTimeString() + " - " + item.workto.Value.ToShortTimeString() + ";";
                }
                resId = item.id.Value.ToString();
            }

            schedule = resId  + " " + schedule;

            var res = new ViewModel();

            res.Message = schedule;

            return PartialView(res);
        }
    }
}