﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using redbus;
namespace redbus.Controllers
{
    public class HomeController : Controller
    {
        // GET: Home

        RedbusEntities1 ent = new RedbusEntities1();
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Register()
        {
            User u= new User();
            
            
            return View(u);
        }


        [HttpPost]

        public ActionResult Register(User uq)
        {
            ent.Users.Add(uq);
            ent.SaveChanges();  

            return RedirectToAction("Login");
        }


        public ActionResult Login()
        {
            User uw = new User();

            return View(uw);
        }
        [HttpPost]
        public ActionResult Login(User ue)
        {
          var a=   ent.Users.FirstOrDefault(m => m.Email.Equals(ue.Email) && m.Password.Equals(ue.Password));
            if (a != null) {

                Session["userid"] = ue.UserId;


                return RedirectToAction("Index");
            
            }
            return View();
        }

         
        
        public ActionResult Userdash()
        {


            return View();
        }

        public ActionResult About()
        {
            return View();
        }
        public ActionResult Contact()
        {
            return View();
        }

    }
}