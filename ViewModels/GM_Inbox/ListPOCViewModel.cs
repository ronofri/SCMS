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
        public AlertItem alert = new AlertItem("No Recent Customer PO's to show", "Warning");
        public TablesHelper tablesHelper { get; set; }

        public ListPOCViewModel(List<POC> source, string user)
        {
            tablesHelper = new TablesHelper(source, user);
        }

        public List<Product> Products { get; set; }
        [Display(Name = "Product Type")]
        public int SelectedProductId { get; set; }
        public IEnumerable<SelectListItem> ProductItems
        {
            get { return new SelectList(Products, "ProductID", "Name"); }
        }

        public List<string> listStatus { get; set; }
        [Display(Name = "Status")]
        public int SelectedListStatusId { get; set; }
        public IEnumerable<SelectListItem> StatusItems
        {
            get { return new SelectList(listStatus); }
        }

        public List<string> months { get; set; }
        [Display(Name = "Month")]
        public int SelectedMonthsId { get; set; }
        public IEnumerable<SelectListItem> MonthItems
        {
            get { return new SelectList(months); }
        }

        public List<int> years { get; set; }
        [Display(Name = "Year")]
        public int SelectedYearsId { get; set; }
        public IEnumerable<SelectListItem> YearsItems
        {
            get { return new SelectList(years); }
        }



    }
}