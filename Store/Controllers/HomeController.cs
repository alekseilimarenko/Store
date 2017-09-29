using System;
using System.Collections.Generic;
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
            //var results = from c in db.Companies
            //              join cn in db.Countries on c.CountryID equals cn.ID
            //              join ct in db.Cities on c.CityID equals ct.ID
            //              join sect in db.Sectors on c.SectorID equals sect.ID
            //              where (c.CountryID == cn.ID) && (c.CityID == ct.ID) && (c.SectorID == company.SectorID) && (company.SectorID == sect.ID)
            //              select new { country = cn.Name, city = ct.Name, c.ID, c.Name, c.Address1, c.Address2, c.Address3, c.CountryID, c.CityID, c.Region, c.PostCode, c.Telephone, c.Website, c.SectorID, Status = (ContactStatus)c.StatusID, sector = sect.Name };


            //return results.ToList();

            var result = db.routine.Select(rt => new
            {
                rt.Id,
                shortName = rt.pn_daynames.short_name,
                workFrom = rt.workfrom,
                workTo = rt.workto,
                intervalFrom = rt.intervalfrom,
                intervalTo = rt.intervalto
                
            }).Where(d => d.Id == id).GroupBy(g => g.Id ).ToList();

            var schedule = String.Empty;

            //foreach (var item in result)
            //{
            //    if (item.workFrom.Value.TimeOfDay )
            //    {
            //        item.
            //    }
            //}

            var res = new ViewModel();

            res.Message = id.ToString();

            return PartialView(res);
        }
    }
}


//declare @tmp table(id int, Shortname nvarchar(50), workfrom datetime, workto datetime,
//intervalfrom datetime, intervalto datetime )
//insert into @tmp(id, Shortname, workfrom, workto,
//intervalfrom, intervalto )
//select WorkTime.id,
//ShortName = (select case when DayNames.id< 5 then 'пн-чт'

//when  DayNames.id< 6 then 'пт' else Short_name end

//from dbo.pn_daynames as DayNames

//where WorkTime.dayofweek = DayNames.id),
//WorkTime.workfrom, WorkTime.workto, WorkTime.intervalfrom, WorkTime.intervalto
//from dbo.routine as WorkTime
//where WorkTime.id = 4052
//select* from @tmp
//group by ID, ShortName, workfrom, workto, intervalfrom, intervalto