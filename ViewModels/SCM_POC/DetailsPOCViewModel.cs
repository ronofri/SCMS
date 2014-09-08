using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using SCMS.Models;
using System.ComponentModel.DataAnnotations;
using System.Web.Mvc;
using SCMS.RSolverTools;

namespace SCMS.ViewModels.SCM_POC
{
    public class DetailsPOCViewModel
    {
        public DetailsPOCViewModel()
        {
            alert = new AlertItem("No shipments added yet", "Warning");
        }
        public Schedule Schedule { get; set; }

        public AlertItem alert { get; set; }
    }
}