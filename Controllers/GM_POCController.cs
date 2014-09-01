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

        public JsonResult CustomerSearch(string query)
        {
            // Get Tags from database
            List<Customer> customers = db.Customer.ToList<Customer>();
            List<Customer> finalCustomers = new List<Customer>();

            string queryLower = query.ToLower();

            foreach (Customer c in customers)
            {
                bool name = (c.Name).ToLower().Contains(queryLower);
                bool address = (c.Address).ToLower().Contains(queryLower);

                if (name || address)
                {
                    finalCustomers.Add(c);
                }
            }

            return new JsonResult
            {
                Data = finalCustomers.ToArray(),
                JsonRequestBehavior = JsonRequestBehavior.AllowGet
            };
        }

        public JsonResult PortSearch(string query)
        {
            // Get Tags from database
            List<DestinationPort> ports = db.DestinationPort.ToList<DestinationPort>();
            List<DestinationPort> finalPorts = new List<DestinationPort>();

            string queryLower = query.ToLower();

            foreach (DestinationPort d in ports)
            {
                bool name = (d.Name).ToLower().Contains(queryLower);
                bool address = (d.Address).ToLower().Contains(queryLower);

                if (name || address)
                {
                    finalPorts.Add(d);
                }
            }

            return new JsonResult
            {
                Data = finalPorts.ToArray(),
                JsonRequestBehavior = JsonRequestBehavior.AllowGet
            };
        }


        protected override void Dispose(bool disposing)
        {
            db.Dispose();
            base.Dispose(disposing);
        }

    }
}
