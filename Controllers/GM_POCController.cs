using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

using SCMS.ViewModels.GM_POC;
using SCMS.Models;
using SCMS.DAL;

namespace SCMS.Controllers
{
    public class GM_POCController : Controller
    {
        private DataBaseContext db = new DataBaseContext();
        //
        // GET: /GM_POC/

        public ActionResult CreatePOC()
        {
            CreateEditPOCViewModel VM = new CreateEditPOCViewModel();
            VM.Products = db.Product.ToList<Product>();
            VM.Incoterms = db.Incoterm.ToList<Incoterm>();

            return View(VM);
        }

        [HttpPost]
        public ActionResult CreatePOC(CreateEditPOCViewModel VM)
        {
            //Agregar objeto de destination y de port directamente con AJAX en los typeahead
            VM.Products = db.Product.ToList<Product>();
            VM.Incoterms = db.Incoterm.ToList<Incoterm>();

            return View(VM);
        }


        protected override void Dispose(bool disposing)
        {
            db.Dispose();
            base.Dispose(disposing);
        }

    }
}
