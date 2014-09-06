using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace SCMS.Models
{
    public class NewPOC
    {

        public int NewPOCID { get; set; }

        public virtual Customer Customer { get; set; }

        public virtual DestinationPort DestinationPort { get; set; }

        //Get from Shipments
        public int AmountTotal { get; set; }

        //From Contract
        public double PricePerTon { get; set; }

        //From Contract
        public virtual Product Product { get; set; }

        //From Contract
        public virtual Incoterm CustomerIncoterm { get; set; }

        public int Status { get; set; }

        public string Comments { get; set; }

        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        public DateTime? CreationDate { get; set; }

        public virtual ICollection<Shipment> Shipments { get; set; }

        public int ShipmentCount
        {
            get
            {
                int count = 0;
                if (Shipments != null)
                {
                    foreach (Shipment Shipment in Shipments)
                    {
                        //For when shipment have status
                        //if (Shipment.Status != -1)
                            count++;
                    }
                }
                return count;
            }
        }

        public string StatusString { get 
            { 
                switch(Status){
                    case -1:
                        return "Cancelled";
                    case 1:
                        return "Incomplete";
                    case 2:
                        return "Sent";
                    case 3:
                        return "Dividing";//Is being divided into POMEs
                    case 4:
                        return "Scheduled";//Has been divided into POMEs
                    default:
                        return "Unknown";
                }
            } 
        }

        public int TonsLeft { 
            get 
            {
                int left = AmountTotal;
                if (Shipments != null)
                {
                    foreach (Shipment Shipment in Shipments)
                    {
                        //if (Shipment.Status != -1)
                            left -= Shipment.Amount;
                    }
                }
                return left;
            } 
        }
    }
}