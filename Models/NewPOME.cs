using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace SCMS.Models
{
    public class NewPOME
    {
        public int NewPOMEID { get; set; }

        /*LongTen Client:
         * Elecmetal Chile
         * USA
         * Hong Kong         
         */
        public virtual Customer Customer { get; set; }

        //Only associated with the customers
        public virtual DestinationPort DestinationPort { get; set; }

        public int AmountTotal { get; set; }
         
        public double PricePerTon { get; set; }

        public virtual Product Product { get; set; }

        /*Only:
         * FOB
         * FCA
         * EXW
         */
        public virtual Incoterm CustomerIncoterm { get; set; }

        public int Status { get; set; }

        public string SpecialRequirements { get; set; }

        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        public DateTime? CreationDate { get; set; }

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