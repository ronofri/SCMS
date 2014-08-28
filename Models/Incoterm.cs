using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace SCMS.Models
{
    public class Incoterm
    {
        public int IncotermID { get; set; }

        public string Name { get; set; }
    }
}