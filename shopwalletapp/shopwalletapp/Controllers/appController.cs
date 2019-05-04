using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace shopwalletapp.Controllers
{
    public class appController : Controller
    {
        // GET: app
        public ActionResult Index()
        {
            return View();
        }

        // GET: Customer
        public ActionResult Customer()
        {
            return View();
        }
        // GET: Customer
        public ActionResult login()
        {
            return View();
        }
        // GET: Customer
        public ActionResult Payroll()
        {
            return View();
        }
        // GET: Customer
        public ActionResult Vendors()
        {
            return View();
        }
    }
}