using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace SCMS.Models
{
    public class POME
    {
        public int POMEID { get; set; }

        public POC POC { get; set; }

        public int Amount { get; set; }        

        public int Status { get; set; }

        public string SpecialRequirements { get; set; }

        public virtual ICollection<Shipment> Shipments { get; set; }

        public string StatusString
        {
            get
            {
                switch (Status)
                {
                    case -1:
                        return "Cancelled";
                    case 1:
                        return "Incomplete";
                    case 2:
                        return "Sent";
                    case 3:
                        return "Dividing";
                    case 4:
                        return "Scheduled";
                    default:
                        return "Unknown";
                }
            }
        }
    }
}