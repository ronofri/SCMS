using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using SCMS.Models;

namespace SCMS.Controllers
{
    public class GM_InboxController : Controller
    {
        //
        // GET: /GM_Inbox/

        public ActionResult Inbox()
        {
            List<POC> POCs = new List<POC>();
            return View(POCs);
        }

    }
}
