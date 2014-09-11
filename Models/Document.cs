using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace SCMS.Models
{
    public class Document
    {
        public int DocumentID { get; set; }

        //when a BL is created, all available documents are also created, and their names are given by the Incoterm (some dictionary in it maybe).
        //This way all possible names are only 5: "Packing List", "Invoice", "Origin Certificate", "Insurance", "Original BL"

        public string Name { get; set; }

        public BL BL { get; set; }

        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        public DateTime? UploadDate { get; set; }

        public string SaveName 
        {
            get
            {
                return Name.Replace(' ', '-'); //Add some other logic like removing '.'
            }
        }

        public string parentFolder 
        { 
            get 
            {
                return "~/UploadedFiles/" + BL.BLID + "/";
            }
        }

        public string placeholderLocation 
        {
            get 
            {
                return "~/Content/images/placeholder.jpg";
            }
        }

        public string thumbFolder
        {
            get
            {
                return this.parentFolder + "Thumbs/";
            }
        }

        public string thumbFileLocation
        {
            get 
            {
                return this.thumbFolder + this.SaveName + ".jpeg";
            }
        }

        public string pdfFileLocation
        {
            get
            {
                return this.parentFolder + this.SaveName + ".pdf";
            }
        }

        public string downloadName
        {
            get
            {
                return this.SaveName + "-BL-" + BL.BLID;
            }
        }
    }
}