using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using BuySpecsProject.Models;

namespace BuySpecsProject.Controllers
{
    public class AdminloginController : Controller
    {
        OnlineSpecsDetailsEntities specsDetailsEntities = new OnlineSpecsDetailsEntities();
        // GET: Adminlogin
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult adminlogin()
        {

            return View();
        }
        [HttpPost]
        public ActionResult adminlogin(LOGINADMIN lOGINADMIN)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    LOGINADMIN admin = specsDetailsEntities.LOGINADMINs.FirstOrDefault
                        (a => a.USERNAME == lOGINADMIN.USERNAME && a.PASSWORD == lOGINADMIN.PASSWORD);
                    if(admin !=null && admin.ROLE=="ADMIN")
                    {
                        ViewBag.Message = "WELCOME ADMIN";
                        Session["admin_username"] = admin.USERNAME;
                        return RedirectToAction("AddSpecs", "AddSpecs");
                    }
                }
            }

            catch (Exception e)
            {
                return View("ERROR" + e.Message);
            }
            return View();
        }
        public ActionResult Logout()
        {
            Session.Clear();
            return RedirectToAction("adminlogin");
        }
    }
}