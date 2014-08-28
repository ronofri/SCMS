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

        public POME POME { get; set; }

        public int Amount { get; set; }

        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        public DateTime? EstimatedTimeDeparture { get; set; }

        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        public DateTime? EstimatedTimeArrival { get; set; }

        public int ShipmentNumber { get; set; }

        public virtual ICollection<BL> BLs { get; set; }

        public int TotalBL
        {
            get
            {
                int BLcount = 0;
                if (BLs == null)
                    return BLcount;
                foreach(BL b in BLs.ToList<BL>()){
                    if (b.Status != -1)
                        BLcount++;
                }
                return BLcount;
            }
        }        
    }
}