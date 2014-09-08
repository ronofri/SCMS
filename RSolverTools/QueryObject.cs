using SCMS.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SCMS.RSolverTools
{
    public class QueryObject
    {
        public QueryObject()
        {
            query = "";
        }

        public string query { get; set; }

        public bool searchByPOC { get; set; }

        public int productType { get; set; }

        public int statusPOC { get; set; }

        public int month { get; set; }

        public int year { get; set; }
    }
}