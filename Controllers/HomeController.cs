﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Transactions;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;
using WebMatrix.WebData;
using SCMS.DAL;
using SCMS.Filters;

namespace SCMS.Controllers
{
    public class HomeController : Controller
    {
        //
        // GET: /Home/

        public ActionResult Index()
        {
            if (User.IsInRole("GM")) 
            {
                return RedirectToAction("Inbox", "GM_Inbox");
            }

            if (User.IsInRole("Admin"))
            {
                return RedirectToAction("Solver", "R");
            }

            return View();
        }

    }
}
