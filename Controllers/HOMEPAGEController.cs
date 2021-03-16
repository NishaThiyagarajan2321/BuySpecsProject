using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using BuySpecsProject.Models;

namespace BuySpecsProject.Controllers
{
    public class HOMEPAGEController : Controller
    {
        // GET: HOMEPAGE
        public ActionResult HomePage()
        {
            OnlineSpecsDetailsEntities db = new OnlineSpecsDetailsEntities();
            
            return View(db.SPECS_DETAILS.ToList());
        }
    }
}