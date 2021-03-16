using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using BuySpecsProject.Models;

namespace BuySpecsProject.Controllers
{
    public class UserRegisterController : Controller
    {
        OnlineSpecsDetailsEntities specsDetailsEntities = new OnlineSpecsDetailsEntities();
        // GET: UserRegister
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult UserRegister()
        {
            return View();
        }
        [HttpPost]
        public ActionResult UserRegister(USERREGISTER uSERREGISTER)
        {
            try
            {
                specsDetailsEntities.USERREGISTERs.Add(uSERREGISTER);
                specsDetailsEntities.SaveChanges();
                ViewBag.message = "Registered Successfully";
                return RedirectToAction("UserLogin");
            }
            catch (Exception e)
            {
                return View("Error" + e.Message);
                
            }
        }
        [HttpPost]
        public JsonResult IsRegisteredMobile(string mobile)
        {

            return Json(!specsDetailsEntities.USERREGISTERs.Any(u => u.MOBILENUMBER == mobile), JsonRequestBehavior.AllowGet);
        }
        public ActionResult UserLogin()
        {
            return View();
        }
        [HttpPost]
        public ActionResult UserLogin(USERREGISTER uSERREGISTER)
        {
            try
            {
                USERREGISTER user = specsDetailsEntities.USERREGISTERs.FirstOrDefault
                    (un => un.FIRSTNAME == uSERREGISTER.FIRSTNAME && un.PASSWORD == uSERREGISTER.PASSWORD);
                TempData["CUSTOMER_NAME"] = user.FIRSTNAME;
                TempData["CUSTOMER_EMAIL"] = user.EMAILID;
                return RedirectToAction("ViewSpecs");
            }
            catch(Exception e)
            {
                return View("Error" + e.Message);
            }
            //return View();
        }
        public ActionResult Logout()
        {
            Session.Clear();
            return RedirectToAction("UserLogin");
        }
        public ActionResult ViewUserDetails(USERREGISTER uSERREGISTER)
        {
            try
            {
                return View(specsDetailsEntities.USERREGISTERs.ToList());
            }
            catch (Exception ex)
            {
                return View("Error" + ex.Message);
            }
        }
        [Route("Specs Details")]
        public ActionResult ViewSpecs()
        {
            try
            {
                return View(specsDetailsEntities.SPECS_DETAILS.ToList());
            }
            catch(Exception ex)
            {
                return View("Error"+ex.Message);
            }
        }
        public ActionResult Add_to_cart(int SPECS_ID)
        {

           
                SPECS_DETAILS specs = specsDetailsEntities.SPECS_DETAILS.FirstOrDefault(id => id.SPECS_ID == SPECS_ID);
                ViewCart view = new ViewCart();
            try
            {

                if (specs != null)
                {
                    view.SPECS_ID = specs.SPECS_ID;
                    view.SPECS_NAME = specs.SPECS_NAME;
                    view.SPECS_PRICE = specs.SPECS_PRICE;

                }
            }

            catch (Exception )
            {
                return View("Error");
            }
            return View(view);
        }
        [HttpPost]
        public ActionResult Add_To_cart(ViewCart view)
        {
            try
            {
                
                SPECS_DETAILS specs = specsDetailsEntities.SPECS_DETAILS.FirstOrDefault(id => id.SPECS_ID == view.SPECS_ID);
                ADD_TO_CART add = new ADD_TO_CART();
                add.SPECS_ID = view.SPECS_ID;
                add.SPECS_NAME = view.SPECS_NAME;
                add.QUANTITY = view.QUANTITY;
                add.SPECS_PRICE = (view.QUANTITY)*(view.SPECS_PRICE);
                add.EMAILID= TempData.Peek("CUSTOMER_EMAIL").ToString();
                specsDetailsEntities.ADD_TO_CART.Add(add);
                specsDetailsEntities.SaveChanges();
                ViewBag.Message = "Added To cart Sucessfully";
                return RedirectToAction("ViewSpecs");
            }
            catch(Exception e)
            {
                return View("Error" + e.Message);
            }
        }
        public ActionResult Viewcart()

        {
            
            return View(specsDetailsEntities.ADD_TO_CART.ToList());
        }
        public ActionResult OrderNow()
        {
           
                string email = TempData.Peek("CUSTOMER_EMAIL").ToString();
                USERREGISTER user = specsDetailsEntities.USERREGISTERs.FirstOrDefault(eid => eid.EMAILID == email);
                ADD_TO_CART cart = specsDetailsEntities.ADD_TO_CART.FirstOrDefault(id=>id.EMAILID == email);
                OrderModel orderModel = new OrderModel();
            if (cart != null)
            {

                orderModel.SPECS_ID = cart.SPECS_ID;
                orderModel.SPECS_NAME = cart.SPECS_NAME;
                orderModel.SPECS_PRICE = cart.SPECS_PRICE;
                orderModel.EMAILID = cart.EMAILID;

            }
            else
            {

                ViewBag.Message = "Cart is Empty";
            }
            return View(orderModel);
            
            
        }
        [HttpPost]
        public ActionResult OrderNow(OrderModel orderModel)
        {
            ORDER_DETAILS order = new ORDER_DETAILS();
            try
            {
                order.ORDER_ID = orderModel.ORDER_ID;
                order.SPECS_ID = orderModel.SPECS_ID;
                order.SPECS_NAME = orderModel.SPECS_NAME;
                order.FRAME_TYPE = orderModel.FRAME_TYPE;
                order.LEFT_EYEPOWER= orderModel.LEFT_EYEPOWER;
                order.RIGHT_EYEPOWER = orderModel.RIGHT_EYEPOWER;
                order.SPECS_PRICE= orderModel.SPECS_PRICE;
                order.EMAILID = orderModel.EMAILID;
                specsDetailsEntities.ORDER_DETAILS.Add(order);
                specsDetailsEntities.SaveChanges();
                ViewBag.Message = "Placed Your order Sucessfully";

            }
            catch(Exception)
            {
                ViewBag.message = "Error";
            }
            return RedirectToAction("ViewOrderedDetails");
        }
        public ActionResult ViewOrderedDetails()
        {
            string mailid = TempData.Peek("CUSTOMER_EMAIL").ToString();
            var data = specsDetailsEntities.ORDER_DETAILS.Where(b => b.EMAILID == mailid);
            return View(data);
        }
        public ActionResult Remove_from_cart(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ADD_TO_CART cart = specsDetailsEntities.ADD_TO_CART.Find(id);
            if (cart == null)
            {
                return HttpNotFound();
            }
            return View(cart);
        }

        [HttpPost, ActionName("Remove_from_cart")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            ADD_TO_CART cart = specsDetailsEntities.ADD_TO_CART.Find(id);
            specsDetailsEntities.ADD_TO_CART.Remove(cart);
            specsDetailsEntities.SaveChanges();
            return RedirectToAction("ViewCart");
        }

        
    }

}

