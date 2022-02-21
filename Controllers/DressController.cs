using Test.Models;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Test.Controllers
{
    public class DataController : Controller
    {
        // GET: Data
        public ActionResult AllDresses()
        {
            var com = new Data();
            var model = com.GetAllDresses();
            return View(model);
        }

        public ActionResult OnEdit(string id)
        {
            int Id = Convert.ToInt32(id);
            var data = new Data();
            try
            {
                var drs = data.FindDress(Id);
                return View(drs);
            }
            catch (Exception ex)
            {
                Debug.WriteLine("ex.Message");
                throw ex;
            }
        }
        [HttpPost]
        public ActionResult OnEdit(Dress postedData)
        {
            var data = new Data();
            try
            {
                data.UpdateDress(postedData);
                return RedirectToAction("AllDresses");
            }
            catch (Exception)
            {

                throw;
            }
        }

        public ActionResult AddDresses()
        {
            var com = new Data();
            var Design = com.GetAllDresses();
            var DressesList = from in Design
                           select new SelectListItem { Text = Design.DesignName, Value = Design.DesignId.ToString() };
            ViewBag.Design = DesignList.ToList();//ViewBag is scoped to the action it is declared or used. 
            return View(new Dress());
        }
        [HttpPost]
        public ActionResult AddDresses(Dress postedRec)
        {
            var com = new Data();
            try
            {
                com.AddNewDress(postedRec);
                //throw new Exception("Testing Error!!!");
                return RedirectToAction("AllDresses");
            }
            catch (Exception ex)
            {
                string message = ex.Message;
                ViewBag.ErrorMessage = message;
                return View(new Dress());
            }
        }
    }
}