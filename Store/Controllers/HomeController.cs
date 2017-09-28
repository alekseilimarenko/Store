using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
using System.Web;
using System.Web.Mvc;
using Store.DAL;
using Store.Models;
using Store.Classes;

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
        public ActionResult _PartView(int id=0)
        {
            //var results = from c in db.Companies
            //              join cn in db.Countries on c.CountryID equals cn.ID
            //              join ct in db.Cities on c.CityID equals ct.ID
            //              join sect in db.Sectors on c.SectorID equals sect.ID
            //              where (c.CountryID == cn.ID) && (c.CityID == ct.ID) && (c.SectorID == company.SectorID) && (company.SectorID == sect.ID)
            //              select new { country = cn.Name, city = ct.Name, c.ID, c.Name, c.Address1, c.Address2, c.Address3, c.CountryID, c.CityID, c.Region, c.PostCode, c.Telephone, c.Website, c.SectorID, Status = (ContactStatus)c.StatusID, sector = sect.Name };


            //return results.ToList();

            var res = new ViewModel();

            res.Message = id.ToString();

            return PartialView(res);
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