using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

using SCMS.ViewModels.Flowchart;
using SCMS.Models;
using SCMS.DAL;
using SCMS.RSolverTools;

using System.Data;
using System.Data.Entity;
using System.Web.Script.Serialization;
using SCMS.Mailers;

namespace SCMS.Controllers
{
    [Authorize(Roles = "GM,SCM,Admin")]
    public class FlowchartController : Controller
    {
        private DataBaseContext db = new DataBaseContext();
        //
        // GET: /Flowchart/
        
        public ActionResult Flowchart()
        {
            List<Shipment> shipments = db.Shipment.Where(x => x.Status != -1).ToList<Shipment>();

            FlowchartViewModel VM = new FlowchartViewModel();
            VM.ShipmentCount = shipments.Count;
            return View(VM);
        }

        public JsonResult loadShipments(string jsonQuery) 
        {
            //JavaScriptSerializer serializer = new JavaScriptSerializer();
            //QueryShipment shipment = serializer.Deserialize<QueryShipment>(jsonQuery);

            List<Shipment> shipments = db.Shipment.Where(x => x.Status != -1).ToList<Shipment>();

            List<GanttSource> source = new List<GanttSource>();

            foreach (Shipment s in shipments)
            {
                source.Add(new GanttSource(s));
            }

            return Json(source, JsonRequestBehavior.AllowGet);
        }

    }
}
