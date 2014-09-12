using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace SCMS.Controllers
{
    [Authorize(Roles = "LongTen")]
    public class LT_InboxController : Controller
    {
        //
        // GET: /LT_Inbox/

        public ActionResult Index()
        {
            return View();
        }

    }
}
