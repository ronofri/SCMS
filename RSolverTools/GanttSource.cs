using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using SCMS.Models;

namespace SCMS.RSolverTools
{
    public class GanttSource
    {
        public GanttSource(Shipment shipment) 
        {
            name = "Shipment " + shipment.ShipmentNumber;
            values = new List<GanttValue>();

            values.Add(new GanttValue(shipment));
        }

        public string name { get; set; } //may add other properties such as desc to use in conjunction with Jquery.Gantt
        public List<GanttValue> values { get; set; }
    }

    public class GanttValue
    {
        public GanttValue(Shipment shipment) 
        {
            @from = shipment.EstimatedTimeDeparture; // @ is needed to escape the from keyword
            to = shipment.EstimatedTimeArrival;
            desc = shipment.Amount + " Tons";
            label = "Shipment " + shipment.ShipmentNumber;

            DateTime today = DateTime.Today;

            string colorClass = "ganttGreen";//ganttFuture

            if (today >= @from)
            {
                if (today >= to) //ganttPast
                {
                    colorClass = "ganttRed";
                }

                else //ganttPresent
                {
                    colorClass = "ganttOrange";
                }
            }

            customClass = colorClass; //if some status equals something, then change the colors for the shipment.

            dataObj = shipment;
        }

        public DateTime? @from { get; set; }
        public DateTime? to { get; set; }
        public string desc { get; set; }
        public string label { get; set; }
        public string customClass { get; set; }
        public Shipment dataObj { get; set; }
    }
}