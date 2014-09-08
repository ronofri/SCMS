using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace SCMS.Models
{
    public class Shipment
    {
        public int ShipmentID { get; set; }

        public Schedule Schedule { get; set; }

        public DestinationPort DestinationPort { get; set; }

        public int Amount { get; set; }

        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        public DateTime? EstimatedTimeDeparture { get; set; }

        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        public DateTime? EstimatedTimeArrival { get; set; }

        public int ShipmentNumber { get; set; }

        public BL BL { get; set; }

        public int Status { get; set; }

        public string StatusString
        {
            get
            {
                return "";
            }
        }
    }
}