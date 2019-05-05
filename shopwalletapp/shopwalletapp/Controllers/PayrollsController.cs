using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using shopwalletapp.Models;

namespace shopwalletapp.Controllers
{
    public class PayrollsController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: Payrolls
        public ActionResult Index()
        {
            ViewBag.topheadding = "Payroll";
            List<Payroll> payrolls = new List<Payroll>();
            var timsheet = (from t in db.Timesheets
                           group t by new { t.Date, t.EmployeeId }).ToList();


            foreach (var item in timsheet)
            {
                Payroll payroll = new Payroll();
                payroll.EmployeeId = item.FirstOrDefault().EmployeeId;
                payroll.PayrollDate = item.FirstOrDefault().Date;
                payroll.PayAmount = 0;
                
                
                foreach (var subitem in item)
                {
                    payroll.PayAmount = payroll.PayAmount + subitem.HourlyRate * subitem.Hours;
                }
                payroll.Employee = db.Employees.FirstOrDefault(e=>e.Id == payroll.EmployeeId);
                payrolls.Add(payroll);
            }
            return View(payrolls.ToList());
        }

        
        
    }
}
