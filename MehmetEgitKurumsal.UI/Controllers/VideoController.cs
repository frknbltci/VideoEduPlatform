using MehmetEgitKurumsal.UI.Attribute;
using MehmetEgitKurumsal.UI.Models;
using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MehmetEgitKurumsal.UI.Controllers
{
    public class VideoController : BaseController
    {
        [Auth]
        public ActionResult VideoAddPage()
        {
            return View();
        }



        [HttpPost]
        public ActionResult getVideo(VideoVM gelen)
        {

            if (gelen.VideoUrl!= null)
            {
                HttpPostedFileBase MyFile = gelen.VideoUrl;

                // Setting location to upload files
                string TargetLocation = Server.MapPath("/Assets/Videos/");

                try
                {
                    if (MyFile.ContentLength > 0)
                    {
                        // Get File Extension
                        string Extension = Path.GetExtension(MyFile.FileName);

                        // Determining file name. You can format it as you wish.
                        string FileName = Path.GetFileName(MyFile.FileName);
                        FileName = Guid.NewGuid().ToString().Substring(0, 8);

                        // Determining file size.
                        int FileSize = MyFile.ContentLength;

                        // Creating a byte array corresponding to file size.
                        byte[] FileByteArray = new byte[FileSize];

                        // Basic validation for file extension
                        string[] AllowedExtension = { ".mp4", ".webm", ".ogg" };
                        string[] AllowedMimeType = { "video/mp4", "video/webm", "video/ogg" };

                        if (AllowedExtension.Contains(Extension) && AllowedMimeType.Contains(MimeMapping.GetMimeMapping(MyFile.FileName)))
                        {
                            // Posted file is being pushed into byte array.
                            MyFile.InputStream.Read(FileByteArray, 0, FileSize);

                            // Uploading properly formatted file to server.
                            MyFile.SaveAs(TargetLocation + FileName + Extension);
                   

                        }
                        else
                        {
                            return Json(false, JsonRequestBehavior.AllowGet);
                        }
                    }
                }

                catch (Exception)
                {
                    return Json(false, JsonRequestBehavior.AllowGet);
                }
            }
            return Json(true, JsonRequestBehavior.AllowGet);
        }

    }
}