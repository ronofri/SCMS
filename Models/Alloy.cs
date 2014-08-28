using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SCMS.Models
{
    public class Alloy
    {
        public int AlloyID { get; set; }

        public string Name { get; set; }

        public int Hardness { get; set; }

        public int Breakage { get; set; }

        public int Material { get; set; }
    }
}