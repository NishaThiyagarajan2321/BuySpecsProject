using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.IO;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using BuySpecsProject.Models;

namespace BuySpecsProject.Controllers
{
    public class AddSpecsController : Controller
    {
        OnlineSpecsDetailsEntities DB = new OnlineSpecsDetailsEntities();
        [HttpGet]
        // GET: AddSpecs
        public ActionResult AddSpecs()
        {
            return View();
        }

        [HttpPost]
        public ActionResult AddSpecs(SPECS_DETAILS sPECS_DETAILS)
        {
            try
            {
                string filename = Path.GetFileNameWithoutExtension(sPECS_DETAILS.ImageFile.FileName);
                string extension = Path.GetExtension(sPECS_DETAILS.ImageFile.FileName);
                filename = filename + DateTime.Now.ToString("yymmssfff") + extension;
                sPECS_DETAILS.SPECS_IMAGE = "~/Images/" + filename;
                filename = Path.Combine(Server.MapPath("~/Images/"), filename);
                sPECS_DETAILS.ImageFile.SaveAs(filename);
                using (OnlineSpecsDetailsEntities cimage = new OnlineSpecsDetailsEntities())
                {
                    cimage.SPECS_DETAILS.Add(sPECS_DETAILS);
                    cimage.SaveChanges();
                    ViewBag.message = "Details Added Sucessfully";
                    //return View();
                    //ModelState.Clear();
                    //return RedirectToAction("SPECS_DETAILS");
                    return RedirectToAction("ViewSpecs", "UserRegister");
                }
               
            }
            catch (Exception ex)
            {
                return View("Error" + ex.Message);
            }


        }

        }
    }
