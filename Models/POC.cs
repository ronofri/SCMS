﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace SCMS.Models
{
    public class POC
    {

        public int POCID { get; set; }

        //Only 3 bigs
        public virtual Customer Customer { get; set; }

        public int AmountTotal { get; set; }

        public double PricePerTon { get; set; }

        public virtual Product Product { get; set; }

        //Only FCA, FOB, EXW
        public virtual Incoterm CustomerIncoterm { get; set; }

        public int Status { get; set; }

        public string Comments { get; set; }

        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        public DateTime? CreationDate { get; set; }

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
    }
}