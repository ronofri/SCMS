using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

using SCMS.ViewModels.GM_POC;
using SCMS.Models;
using SCMS.DAL;
using SCMS.RSolverTools;

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
        public ActionResult CreatePOC(CreateEditPOCViewModel VM, string submitButton)
        {
            //Agregar objeto de destination y de port directamente con AJAX en los typeahead
            if (VM.Alerts == null)
                VM.Alerts = new List<AlertItem>();

            else if(VM.Alerts.Count != 0)
            {
                VM.Alerts.Clear();
            }

            
            int status = 0;

            switch (submitButton)
            {
                case "Save":
                    status = 1;
                    validateCreatePost(VM, false);
                    break;
                case "Save and Send":
                    status = 2;
                    validateCreatePost(VM, true);
                    break;
            }

            if (VM.Alerts.Count > 0)
            {
                VM.Products = db.Product.ToList<Product>();
                VM.Incoterms = db.Incoterm.ToList<Incoterm>();
                return View(VM);
            }

            POC POC = new POC();
            POC = VM.POC;

            POC.Status = status;

            POC.CreationDate = DateTime.Today;

            Schedule schedule = new Schedule();

            db.POC.Add(POC);

            schedule.POC = POC;

            db.Schedule.Add(schedule);

            try
            {
                db.SaveChanges();
            }
            catch (Exception e) 
            {
                VM.Alerts.Add(new AlertItem("Unexpected database error. Changes could not be saved."));
            }

            return RedirectToAction("Inbox", new {controller = "GM_Inbox" });
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

        public void validateCreatePost(CreateEditPOCViewModel VM, bool postType)
        {
            if (VM.POC == null)
                VM.Alerts.Add(new AlertItem("Unexpected error while sending data to server."));

            List<Customer> customers = db.Customer.ToList<Customer>();
            Customer finalCustomer = new Customer();

            if (VM.CustomerProperty != null)
            {
                string queryLower = VM.CustomerProperty.ToLower();

                foreach (Customer c in customers)
                {
                    bool cond = (c.CustomerProperty).ToLower().Equals(queryLower);
                    if (cond)
                    {
                        finalCustomer = c;
                    }
                }
            }

            List<DestinationPort> destinations = db.DestinationPort.ToList<DestinationPort>();
            DestinationPort finalDestination = new DestinationPort();

            if (VM.PortProperty != null)
            {
                string queryLower = VM.PortProperty.ToLower();

                foreach (DestinationPort d in destinations)
                {
                    bool cond = (d.PortProperty).ToLower().Equals(queryLower);
                    if (cond)
                    {
                        finalDestination = d;
                    }
                }
            }

            if (finalCustomer.Name != null)
            {
                VM.POC.Customer = finalCustomer;
            }

            else
            {
                VM.Alerts.Add(new AlertItem("Selected Customer is not valid."));
            }

            if (finalDestination.Name != null)
            {
                VM.POC.DestinationPort = finalDestination;
            }
            else 
            {
                VM.Alerts.Add(new AlertItem("Selected Port is not valid."));
            }

            if (postType)
            {

                if (VM.SelectedIncotermId > 0)
                {
                    VM.POC.CustomerIncoterm = db.Incoterm.Find(VM.SelectedIncotermId);
                }
                else
                {
                    VM.Alerts.Add(new AlertItem("Selected Incoterm is not valid."));
                }
                if (VM.SelectedProductId > 0)
                {
                    VM.POC.Product = db.Product.Find(VM.SelectedProductId);
                }
                else
                {
                    VM.Alerts.Add(new AlertItem("Selected Product Type is not valid."));
                }

                if (VM.POC.AmountTotal <= 0)
                {
                    VM.Alerts.Add(new AlertItem("Amount must be a positive number."));
                }

                if (VM.POC.PricePerTon <= 0)
                {
                    VM.Alerts.Add(new AlertItem("Price Per Ton must be a positive number."));
                }
            }
        }

        protected override void Dispose(bool disposing)
        {
            db.Dispose();
            base.Dispose(disposing);
        }

    }
}
