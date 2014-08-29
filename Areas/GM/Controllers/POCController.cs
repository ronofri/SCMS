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
    public class POCController : Controller
    {
        private DataBaseContext db = new DataBaseContext();
        //
        // GET: /GM/POC/Create

        public ActionResult CreatePOC()
        {
            CreateEditPOCViewModel VM = new CreateEditPOCViewModel();
            VM.Products = db.Product.ToList<Product>();
            VM.Incoterms = db.Incoterm.ToList<Incoterm>();
            //add selecteddestinationID and incoterm
            return View(VM);
        }

        //
        // POST: /POC/CreatePOC

        //[HttpPost]
        //public ActionResult CreatePOC(CreatePOCViewModel VM, string submitButton)
        //{

        //    PurchaseOrderCustomer purchaseordercustomer = new PurchaseOrderCustomer();

        //    ModelState.Remove("SelectedIncotermId");
        //    ModelState.Remove("SelectedProductId");
        //    ModelState.Remove("Amount");
        //    ModelState.Remove("PricePerTon");
        //    ModelState.Remove("CustomerProperty");
        //    ModelState.Remove("DestinationPort");
        //    if (ModelState.IsValid)
        //    {
        //        switch (submitButton)
        //        {
        //            case "Save":
        //                purchaseordercustomer.Status = 1;
        //                break;
        //            case "Save and Send":
        //                purchaseordercustomer.Status = 2;
        //                break;
        //        }

        //        List<Customer> customers = db.Customer.ToList<Customer>();
        //        Customer finalCustomer = new Customer();

        //        if (VM.CustomerProperty != null)
        //        {
        //            string queryLower = VM.CustomerProperty.ToLower();

        //            foreach (Customer c in customers)
        //            {
        //                bool cond = (c.CustomerProperty).ToLower().Equals(queryLower);
        //                if (cond)
        //                {
        //                    finalCustomer = c;
        //                }
        //            }
        //        }

        //        List<DestinationPort> destinations = db.DestinationPort.ToList<DestinationPort>();
        //        DestinationPort finalDestination = new DestinationPort();

        //        if (VM.DestinationPort != null)
        //        {
        //            string queryLower = VM.DestinationPort.ToLower();

        //            foreach (DestinationPort d in destinations)
        //            {
        //                bool cond = (d.PortProperty).ToLower().Equals(queryLower);
        //                if (cond)
        //                {
        //                    finalDestination = d;
        //                }
        //            }
        //        }

        //        if (finalCustomer.Name != null && finalDestination.Name != null)
        //        {
        //            //si vm.customerproperty no es null, pero cae aqui, agregar un mensaje de error de destination ingresado no valido

        //            purchaseordercustomer.Customer = finalCustomer;
        //            purchaseordercustomer.DestinationPort = finalDestination;
        //        }
        //        else
        //        {
        //            if (VM.CustomerProperty != null)
        //            {
        //                VM.DestinationError = VM.CustomerProperty + " is not a valid Destination. Please try with another.";
        //                VM.Products = db.Product.ToList<Product>();
        //                VM.Incoterms = db.Incoterm.ToList<Incoterm>();
        //                return View(VM);
        //            }
        //        }

        //        if (VM.SelectedIncotermId > 0)
        //        {
        //            purchaseordercustomer.CustomerIncoterm = db.Incoterm.Find(VM.SelectedIncotermId);
        //        }
        //        if (VM.SelectedProductId > 0)
        //        {
        //            purchaseordercustomer.Product = db.Product.Find(VM.SelectedProductId);
        //        }

        //        purchaseordercustomer.Comments = VM.Comments;

        //        purchaseordercustomer.AmountTotal = VM.Amount;
        //        purchaseordercustomer.PricePerTon = VM.PricePerTon;

        //        purchaseordercustomer.CreationDate = DateTime.Today;

        //        db.PurchaseOrderCustomer.Add(purchaseordercustomer);
        //        db.SaveChanges();
        //        return RedirectToAction("Index");
        //    }

        //    VM.Products = db.Product.ToList<Product>();
        //    VM.Incoterms = db.Incoterm.ToList<Incoterm>();
        //    return View(VM);
        //}

    }
}
