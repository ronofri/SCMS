﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using SCMS.Models;
using SCMS.ViewModels.SCM_Inbox;
using SCMS.DAL;

namespace SCMS.Controllers
{
    public class SCM_InboxController : Controller
    {
        private DataBaseContext db = new DataBaseContext();
        //
        // GET: /SCM_Inbox/
        public ActionResult Inbox()
        {
            List<POC> POCs = db.POC.ToList<POC>();
            List<Shipment> Shipments = db.Shipment.ToList<Shipment>();
            List<BL> BLs = db.BL.ToList<BL>();
            ListPOCViewModel VM = new ListPOCViewModel(POCs, Shipments, BLs, "SCM");
            return View(VM);
        }

    }
}
