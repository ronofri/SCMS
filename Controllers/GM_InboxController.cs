using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using SCMS.Models;
using SCMS.ViewModels.GM_Inbox;
using SCMS.DAL;

namespace SCMS.Controllers
{
    [Authorize(Roles = "GM")]
    public class GM_InboxController : Controller
    {
        private DataBaseContext db = new DataBaseContext();
        //
        // GET: /GM_Inbox/
        public ActionResult Inbox()
        {
            List<POC> POCs = db.POC.ToList<POC>();
            ListPOCViewModel VM = new ListPOCViewModel(POCs, "GM");
            return View(VM);
        }

    }
}
