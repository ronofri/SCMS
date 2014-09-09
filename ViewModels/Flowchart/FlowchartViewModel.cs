using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using SCMS.Models;
using SCMS.RSolverTools;

namespace SCMS.ViewModels.Flowchart
{
    public class FlowchartViewModel
    {
        public FlowchartViewModel()
        {
            alert = new AlertItem("No shipments to show", "Warning");
            ShipmentCount = 0;
        }
        public int ShipmentCount { get; set; }
        public AlertItem alert { get; set; }
    }
}