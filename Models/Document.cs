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

        public string Name { get; set; }//path to parent folder

        public BL BL { get; set; }

        public string File { get; set; }//path to file in server

        public string Thumbnail { get; set; }//path to thumbnail in server

        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        public DateTime? UploadDate { get; set; }
    }
}