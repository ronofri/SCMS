using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using SCMS.Models;
using System.ComponentModel.DataAnnotations;
using System.Web.Mvc;
using SCMS.RSolverTools;

namespace SCMS.ViewModels.GM_Inbox
{
    public class ListPOCViewModel
    {
        public TablesHelper tablesHelper { get; set; }

        public ListPOCViewModel(List<POC> source)
        {
            tablesHelper = new TablesHelper(source, "GM");
        }

        public ListPOCViewModel(List<POC> source, string user)
        {
            tablesHelper = new TablesHelper(source, user);
        }
    }
}