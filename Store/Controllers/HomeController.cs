using System.Data.SqlClient;
using System.Linq;
using System.Web.Mvc;
using Store.DAL;
using Store.Models;
using System.Collections.Generic;

namespace Store.Controllers
{
    public class HomeController : Controller
    {
        StoreEntities db = new StoreEntities();

        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Store()
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

            var res = new ViewModel();

            foreach (var item in scheduleRes)
            {
                if (item.intervalfrom.Value.TimeOfDay != item.intervalto.Value.TimeOfDay)
                {
                    res.Message = res.Message + item.Shortname + 
                        " " + item.workfrom.Value.ToShortTimeString() + " - " + item.workto.Value.ToShortTimeString() + 
                        " (" + item.intervalfrom.Value.ToShortTimeString() + "-" + item.intervalfrom.Value.ToShortTimeString() + ");";
                }
                else
                {
                    res.Message = res.Message + item.Shortname +
                               " " + item.workfrom.Value.ToShortTimeString() + " - " + item.workto.Value.ToShortTimeString() + ";";
                }
                res.Id = item.id.Value.ToString();
            }
            return PartialView(res);
        }
    }
}