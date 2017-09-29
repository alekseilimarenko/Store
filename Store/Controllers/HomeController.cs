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
            var scheduleRes = db.Database.SqlQuery<routine>("GetSchedule", param);

            var resId = scheduleRes.FirstOrDefaultAsync().Result.Id;

            var schedule = String.Empty;

            foreach (var item in scheduleRes)
            {
                if (item.intervalfrom.Value.TimeOfDay != item.intervalto.Value.TimeOfDay)
                {
                    schedule = item.pn_daynames.short_name + 
                        " " + item.workfrom.Value.ToShortTimeString() + item.workto.Value.ToShortTimeString() + 
                        " (" + item.intervalfrom.Value.ToShortTimeString() + "-" + item.intervalfrom.Value.ToShortTimeString() + ";";
                }
                else
                {
                    schedule = item.pn_daynames.short_name +
                               " " + item.workfrom.Value.ToShortTimeString() + item.workto.Value.ToShortTimeString() +
                               " (" + item.intervalfrom.Value.ToShortTimeString() + "-" + item.intervalfrom.Value.ToShortTimeString() + ";";
                }
            }

            schedule = resId + schedule;

            var res = new ViewModel();

            res.Message = id.ToString();

            return PartialView(res);
        }
    }
}