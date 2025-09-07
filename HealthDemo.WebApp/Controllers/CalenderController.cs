using HealthDemo.Data.Entities;
using HealthDemo.Data.ModelDbContext;
using HealthDemo.Model.EventVm;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Globalization;

namespace HealthDemo.WebApp.Controllers
{
    public class CalenderController : Controller
    {
        private readonly ApplicationDb _db;
        public CalenderController(ApplicationDb db)
        {
            _db = db;
        }

        [HttpGet]
        public IActionResult Index()
        {
            return View();
        }
        public IActionResult GetEvents()
        {
            var events = _db.Events.ToList();
            return  Json(events);
        }
        [HttpGet]
        public IActionResult Calendar()
        {
            return View();
        }
        [HttpPost]
      //  public IActionResult SaveEvent(Event GetData)
        public IActionResult SaveEvent(EventTest GetData)
        {
            string Datedemo = "2/08/2023 11:58:02 PM"; //22/08/2023 12:00 AM
            string sd = string.Concat(GetData.StartDate.Trim());


            DateTime dt = DateTime.ParseExact("2/22/2015 9:54:02 AM", "M/d/yyyy h:mm:ss tt", CultureInfo.InvariantCulture);
            DateTime dt2 = DateTime.ParseExact(Datedemo, "M/d/yyyy h:mm:ss tt", CultureInfo.InvariantCulture);
            //e.Start = DateTime.Now;
            //e.End = DateTime.Now;
            var status = false;  
            {
      
                //if (e.Id > 0)
                //{
                //    //Update the event
                //    var v = _db.Events.Where(a => a.Id == e.Id).FirstOrDefault();
                //    if (v != null)
                //    {
                //        v.Title = e.Title;
                //        v.Start = e.Start;
                //        v.End = e.End;
                //        v.Description = e.Description;
                //        v.IsFullDay = e.IsFullDay;                     
                //    }
                //}
                //else
                //{
                    // _db.Events.Add(GetData);
                //}
                //_db.SaveChanges();
                //status = true;
                _db.SaveChanges();
            }
            return  Json (status);
        }
       
        
        [HttpPost]
        public IActionResult DeleteEvent(int Id)
        {
            var status = false;         
            {
                var v = _db.Events.Where(a => a.Id == Id).FirstOrDefault();
                if (v != null)
                {
                     v.IsActive = Convert.ToBoolean(1) ;
                    _db.SaveChanges();
                    status = true;
                }
            }
            return Json(new { status = true, message = "Event deleted successfully." }); 
        }


        [HttpPost]
     //   public IActionResult ActionName( DatetimeModel datetimeModel)
        public IActionResult ActionName( string sdssss)
        {
            
            // Return any response if needed
            return Json(new { message = "Datetime values received and processed successfully." });
        }

        public class DatetimeModel
        {
            public DateTime Date1 { get; set; }
            public DateTime Date2 { get; set; }
            // Add more datetime properties if needed
        }

    }
}



