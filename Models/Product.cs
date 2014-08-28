using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SCMS.Models
{
    public class Product
    {
        public int ProductID { get; set; }

        public string Name { get; set; }

        public virtual Alloy Alloy { get; set; }
    }
}