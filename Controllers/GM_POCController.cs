using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

using SCMS.ViewModels.GM_POC;
using SCMS.Models;
using SCMS.DAL;
using SCMS.RSolverTools;

using System.Data;
using System.Data.Entity;


namespace SCMS.Controllers
{
    public class GM_POCController : Controller
    {
        private DataBaseContext db = new DataBaseContext();
        //
        // GET: /GM_POC/DetailsPOC/5
        public ActionResult DetailsPOC(int id)
        {
            DetailsPOCViewModel VM = new DetailsPOCViewModel();
            foreach (Schedule schedule in db.Schedule.Include(p => p.POC).ToList<Schedule>())
            {
                if(schedule.POC.POCID == id)
                    VM.Schedule = schedule;
            }
            return View(VM);
        }

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

        public ActionResult EditPOC(int id = 0)
        {
            var purchaseordercustomerFull = db.POC.Include(x => x.Product).Include(x => x.Customer).Include(x => x.DestinationPort);
            var result = purchaseordercustomerFull.Where(p => p.POCID == id);
            List<POC> purchaseordercustomerList = result.ToList<POC>();

            if (purchaseordercustomerList.Count == 0)
            {
                return HttpNotFound();
            }

            POC POC = purchaseordercustomerList[0];
            CreateEditPOCViewModel VM = new CreateEditPOCViewModel();

            VM.Products = db.Product.ToList<Product>();
            VM.Incoterms = db.Incoterm.ToList<Incoterm>();

            VM.POC = POC;

            if(POC.CustomerIncoterm != null)
                VM.SelectedIncotermId = POC.CustomerIncoterm.IncotermID;
            if(POC.Product != null)
                VM.SelectedProductId = POC.Product.ProductID;

            if (POC.Customer != null) 
            {
                VM.CustomerProperty = POC.Customer.CustomerProperty;
            }

            if (POC.DestinationPort != null)
            {
                VM.PortProperty = POC.DestinationPort.PortProperty;
            }

            return View(VM);
        }

        [HttpPost]
        public ActionResult EditPOC(CreateEditPOCViewModel VM, string submitButton, int id)
        {
            POC POC = db.POC.Find(id);

            if (VM.Alerts == null)
                VM.Alerts = new List<AlertItem>();

            else if (VM.Alerts.Count != 0)
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
                reloadEditPOC(VM);
                return View(VM);
            }

            POC.AmountTotal = VM.POC.AmountTotal;
            POC.Comments = VM.POC.Comments;
            POC.PricePerTon = VM.POC.PricePerTon;

            POC.Customer = VM.POC.Customer;
            POC.CustomerIncoterm = VM.POC.CustomerIncoterm;

            POC.DestinationPort = VM.POC.DestinationPort;

            POC.Product = VM.POC.Product;

            POC.Status = status;

            db.Entry(POC).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (Exception e)
            {
                VM.Alerts.Add(new AlertItem("Unexpected database error. Changes could not be saved."));
            }

            return RedirectToAction("Inbox", new { controller = "GM_Inbox" });
        }

        public void reloadEditPOC(CreateEditPOCViewModel VM) 
        {
            VM.Products = db.Product.ToList<Product>();
            VM.Incoterms = db.Incoterm.ToList<Incoterm>();
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
            else if (postType)
            {
                VM.Alerts.Add(new AlertItem("Selected Port is not valid."));
            }


            if (VM.SelectedIncotermId > 0)
            {
                VM.POC.CustomerIncoterm = db.Incoterm.Find(VM.SelectedIncotermId);
            }
            else if(postType)
            {
                VM.Alerts.Add(new AlertItem("Selected Incoterm is not valid."));
            }
            if (VM.SelectedProductId > 0)
            {
                VM.POC.Product = db.Product.Find(VM.SelectedProductId);
            }
            else if (postType)
            {
                VM.Alerts.Add(new AlertItem("Selected Product Type is not valid."));
            }

            if (VM.POC.AmountTotal <= 0)
            {
                if (postType)
                {
                    VM.Alerts.Add(new AlertItem("Amount must be a positive number."));
                }
                    
                else
                    VM.POC.AmountTotal = 0;
            }

            if (VM.POC.PricePerTon <= 0)
            {
                if (postType)
                {
                    VM.Alerts.Add(new AlertItem("Price Per Ton must be a positive number."));
                }
                else
                    VM.POC.PricePerTon = 0;
            }
            
        }

        public JsonResult ShipmentTest(int scheduleID)
        {
            Schedule schedule = db.Schedule.Find(scheduleID);
            List<Shipment> shipments = schedule.Shipments.ToList<Shipment>();
            //shipments = db.Shipment.ToList<Shipment>();
            List<GanttSource> source = new List<GanttSource>();

            foreach (Shipment s in shipments)
            {
                source.Add(new GanttSource(s));
            }

            return Json(source, JsonRequestBehavior.AllowGet);
        }

        protected override void Dispose(bool disposing)
        {
            db.Dispose();
            base.Dispose(disposing);
        }

    }
}
