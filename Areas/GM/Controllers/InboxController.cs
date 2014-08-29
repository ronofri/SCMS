using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

using System.Data;
using System.Data.Entity;

using SCMS.Models;
using SCMS.DAL;
using System.Web.Script.Serialization;
using SCMS.RSolverTools;

using SCMS.Areas.GM.ViewModels;

namespace SCMS.Areas.GM.Controllers
{
    public class InboxController : Controller
    {

        private DataBaseContext db = new DataBaseContext();
        //
        // GET: /GM/Inbox/

        public ActionResult Index()
        {
            List<POC> POCs = db.POC.ToList<POC>();

            return View(POCs);
        }

        protected override void Dispose(bool disposing)
        {
            db.Dispose();
            base.Dispose(disposing);
        }
    }
}
