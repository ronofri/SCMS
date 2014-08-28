using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.ComponentModel.DataAnnotations;

namespace SCMS.Models
{
    public class BL
    {
        public int BLID { get; set; }

        public Shipment Shipment { get; set; }

        public int Amount { get; set; }

        public int Status { get; set; }

        public string ShipName { get; set; }

        public virtual ICollection<Container> Containers { get; set; }

        public virtual ICollection<Document> Documents { get; set; }

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
                        return "Sent";//podria ser shipping
                    default:
                        return "Unknown";
                }
            }
        }

        public int TotalContainers
        {
            get
            {
                if (Containers == null)
                    return 0;
                return Containers.ToList<Container>().Count;
            }
        }
    }
}
