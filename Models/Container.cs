using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SCMS.Models
{
    public class Container
    {
        public int ContainerID { get; set; }

        public BL BL { get; set; }

        public int Amount { get; set; }

        public int Status { get; set; }

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
                    default:
                        return "Unknown";
                }
            }
        }
    }
}