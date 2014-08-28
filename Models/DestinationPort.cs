using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace SCMS.Models
{
    public class DestinationPort
    {
        public int DestinationPortID { get; set; }

        public string Name { get; set; }

        public string Address { get; set; }

        public string PortProperty { get { return Name + " - " + Address; } }

        public string ContactInfo { get; set; }
    }
}