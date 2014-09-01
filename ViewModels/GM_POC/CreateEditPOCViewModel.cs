using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using SCMS.Models;
using System.ComponentModel.DataAnnotations;
using System.Web.Mvc;

namespace SCMS.ViewModels.GM_POC
{
    public class CreateEditPOCViewModel
    {
        public POC POC { get; set; }

        public List<Incoterm> Incoterms { get; set; }

        public List<Product> Products { get; set; }

        [Display(Name = "Incoterm")]
        public int SelectedIncotermId { get; set; }

        public IEnumerable<SelectListItem> IncotermItems
        {
            get { return new SelectList(Incoterms, "IncotermID", "Name"); }
        }

        [Display(Name = "Product Type (Ball Inches)")]
        public int SelectedProductId { get; set; }

        public IEnumerable<SelectListItem> ProductItems
        {
            get { return new SelectList(Products, "ProductID", "Name"); }
        }

        public string DestinationError { get; set; }

        public string PortError { get; set; }
    }
}