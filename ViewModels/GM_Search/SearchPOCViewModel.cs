using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using SCMS.RSolverTools;
using SCMS.Models;

namespace SCMS.ViewModels.GM_Search
{
    public class SearchPOCViewModel
    {
        public TablesHelper tablesHelper { get; set; }

        public SearchPOCViewModel(List<POC> source)
        {
            tablesHelper = new TablesHelper(source, "All");
        }
    }
}