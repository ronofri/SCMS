using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using SCMS.DAL;

using System.Data;
using System.Data.Entity;
using SCMS.ViewModels.GM_Inbox;
using SCMS.Models;
using System.Web.Script.Serialization;
using SCMS.RSolverTools;
using System.IO;
using GhostscriptSharp;

namespace SCMS.Controllers
{
    [Authorize]
    public class UploadController : Controller
    {
        private DataBaseContext db = new DataBaseContext();
        //

        // GET: /Upload/TestUpload/5
        public ActionResult TestUpload(int BLID = 0)
        {
            BL testBL = db.BL.Include(x => x.Documents).Where(x => x.BLID == 1).ToList<BL>()[0];

            //string path = docs[0].parentFolder;

            //string serverPath = Server.MapPath(path);
            //bool exists = Directory.Exists(serverPath);

            //if(exists){
            //    var dir = new System.IO.DirectoryInfo(serverPath); 
            //    System.IO.FileInfo[] fileNames = dir.GetFiles("*.*"); 
             
            //    foreach (var file in fileNames) 
            //    { 
            //        items.Add(path + file.Name); 
            //    } 
            //}
            //return View(items);

            return View(testBL.Documents);
        }

        [HttpPost]
        public ActionResult TestUpload(HttpPostedFileBase file, Document docPartial)
        {
            Document doc = db.Document.Include(x => x.BL).Where(x => x.DocumentID == docPartial.DocumentID).ToList<Document>()[0];

            if (file != null && file.ContentLength > 0)
            {
                //var fileName = Path.GetFileName(file.FileName);
                //string fileExtension = Path.GetExtension(file.FileName);
                //add BL identifier as folder, and the type of document (like packing list, or invoice) as the name of the file
                var fileName = doc.Name;
                //Directory.CreateDirectory(Server.MapPath("~/UploadedFiles/" + BLID + "/"));
                Directory.CreateDirectory(Server.MapPath(doc.parentFolder));
                //var path = Path.Combine(Server.MapPath("~/UploadedFiles/" + BLID + "/"), fileName + fileExtension);
                var path = Server.MapPath(doc.pdfFileLocation);
                file.SaveAs(path);

                //Directory.CreateDirectory(Server.MapPath("~/UploadedFiles/" + BLID + "/Thumbs/"));
                Directory.CreateDirectory(Server.MapPath(doc.thumbFolder));
                //var thumbPath = Path.Combine(Server.MapPath("~/UploadedFiles/" + BLID + "/Thumbs/"), fileName + ".jpeg");
                var thumbPath = Server.MapPath(doc.thumbFileLocation);
                
                GhostscriptWrapper.GeneratePageThumb(path, thumbPath, 1, 70, 70);//int width and height go in percentages
                
                doc.UploadDate = DateTime.Now;
                db.Entry(doc).State = EntityState.Modified;
                db.SaveChanges();
                //add a whole lot of try and catch blocks
            }

            //var dir = new System.IO.DirectoryInfo(Server.MapPath("~/UploadedFiles/" + BLID + "/Thumbs/"));
            //System.IO.FileInfo[] fileNames = dir.GetFiles("*.*");
            //List<string> items = new List<string>();
            //foreach (var f in fileNames)
            //{
            //    items.Add(f.Name);
            //}
            //BL testBL = db.BL.Include(x => x.Documents).Where(x => x.BLID == doc.BL.BLID).ToList<BL>()[0];

            return View(doc.BL.Documents);
        }

        public JsonResult AjaxUploadFile(HttpPostedFileBase fileName) 
        {
            return null;
        }


        public FileResult Download(int docID)//, int BLID)
        {
            Document docFull = db.Document.Include(x => x.BL).Where(x => x.DocumentID == docID).ToList<Document>()[0];

            return File(Server.MapPath(docFull.pdfFileLocation), System.Net.Mime.MediaTypeNames.Application.Octet, docFull.downloadName + ".pdf");
        }
    }
}
