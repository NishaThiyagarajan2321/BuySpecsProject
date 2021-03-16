using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using BuySpecsProject.Models;

namespace BuySpecsProject.Controllers
{
    public class SearchSpecsController : Controller
    {
        OnlineSpecsDetailsEntities db = new OnlineSpecsDetailsEntities();
        // GET: SearchSpecs
        public ActionResult Index(string searching)
        {
            try
            {
                var specs = from data in db.SPECS_DETAILS
                            select data;
                if (!String.IsNullOrEmpty(searching))
                {
                    specs = specs.Where(s => s.SPECS_NAME.Contains(searching));
                }
                return View(specs.ToList());
            }
            catch (Exception ex)
            {
                return View("Error" + ex.Message);
            }
        }
        [HttpGet]
        public ActionResult SearchByType(string searching)
        {
            try
            {
                var specs = from data in db.SPECS_DETAILS
                            select data;
                if (!String.IsNullOrEmpty(searching))
                {
                    specs = specs.Where(s => s.FRAME_TYPE.Contains(searching));
                }
                return View(specs.ToList());
            }
            catch (Exception ex)
            {
                return View("Error" + ex.Message);
            }
        }
    }
}