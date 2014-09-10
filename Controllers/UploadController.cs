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
        // GET: /Upload/

        public ActionResult TestUpload()
        {
            int BLID = 666;
            List<string> items = new List<string>();

            string path = "~/UploadedFiles/" + BLID + "/Thumbs/";

            string serverPath = Server.MapPath(path);
            bool exists = Directory.Exists(serverPath);

            if(exists){
                var dir = new System.IO.DirectoryInfo(serverPath); 
                System.IO.FileInfo[] fileNames = dir.GetFiles("*.*"); 
             
                foreach (var file in fileNames) 
                { 
                    items.Add(path + file.Name); 
                } 
            }
            return View(items);
        }

        [HttpPost]
        public ActionResult TestUpload(HttpPostedFileBase file)
        {
            int BLID = 666;

            if (file != null && file.ContentLength > 0)
            {
                var fileName = Path.GetFileName(file.FileName);
                string fileExtension = Path.GetExtension(file.FileName);
                //add BL identifier as folder, and the type of document (like packing list, or invoice) as the name of the file
                fileName = "PackingList";
                Directory.CreateDirectory(Server.MapPath("~/UploadedFiles/" + BLID + "/"));
                var path = Path.Combine(Server.MapPath("~/UploadedFiles/" + BLID + "/"), fileName + fileExtension);
                file.SaveAs(path);

                Directory.CreateDirectory(Server.MapPath("~/UploadedFiles/" + BLID + "/Thumbs/"));
                var thumbPath = Path.Combine(Server.MapPath("~/UploadedFiles/" + BLID + "/Thumbs/"), fileName + ".jpeg");

                GhostscriptWrapper.GeneratePageThumb(path, thumbPath, 1, 30, 30);//int width and height go in percentages

                //add a whole lot of try and catch blocks
            }

            var dir = new System.IO.DirectoryInfo(Server.MapPath("~/UploadedFiles/" + BLID + "/Thumbs/"));
            System.IO.FileInfo[] fileNames = dir.GetFiles("*.*");
            List<string> items = new List<string>();
            foreach (var f in fileNames)
            {
                items.Add(f.Name);
            }

            return View(items);
        }

        public JsonResult AjaxUploadFile(HttpPostedFileBase fileName) 
        {
            return null;
        }


        public FileResult Download(string fileName)//, int BLID)
        {
            int BLID = 666;
            return File(Server.MapPath("~/UploadedFiles/" + BLID + "/") + fileName, System.Net.Mime.MediaTypeNames.Application.Octet,fileName);
        }
    }
}
