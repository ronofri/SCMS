using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace SCMS.Models
{
    public class Schedule
    {
        public int ScheduleID { get; set; }

        public POC POC { get; set; }

        public virtual ICollection<Shipment> Shipments { get; set; }

        public int TonsLeft
        {
            get
            {
                int left = POC.AmountTotal;
                if (Shipments != null)
                {
                    foreach (Shipment shipment in Shipments)
                    {
                        left -= shipment.Amount;
                    }
                }
                return left;
            }
        }
    }
}