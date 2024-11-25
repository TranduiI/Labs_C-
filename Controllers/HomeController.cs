using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
//using LabASP.DAL;
using LabASP.ViewModels;


namespace LabASP.Controllers
{
    public class HomeController : Controller
    {
        //private AgreementContext db = new AgreementContext();


        public ActionResult Index()
        {
            return View();
        }

        public ActionResult About()
        {
            return View();

        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
        protected override void Dispose(bool disposing)
        {
            //db.Dispose();
            base.Dispose(disposing);
        }

    }
}