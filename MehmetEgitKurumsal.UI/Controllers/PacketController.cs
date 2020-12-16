using MehmetEgitKurumsal.DAL.DB;
using MehmetEgitKurumsal.UI.Attribute;
using MehmetEgitKurumsal.UI.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MehmetEgitKurumsal.UI.Controllers
{
    public class PacketController : BaseController
    {
        [Auth]

        // GET: Packet
        public ActionResult Index()
        {
            var packetList = service.PacketService.GetAll().ToList();

            return View(packetList);
        }


        [HttpPost]
        public ActionResult makePassiveOrActive(int? ID)
        {

            if (ID ==null)
            {
                return Json(false, JsonRequestBehavior.AllowGet);
            }
            else
            {
                try
                {
                    var updateData = service.PacketService.GetAll().Where(x => x.ID == ID).FirstOrDefault();
                    if (updateData.ActOrPass == false)
                    {
                        updateData.ActOrPass = true;
                        service.PacketService.Save();
                    }
                    else
                    {
                        updateData.ActOrPass = false;
                        service.PacketService.Save();
                    }

                    return Json(true, JsonRequestBehavior.AllowGet);
                }
                catch (Exception)
                {
                    return Json(false, JsonRequestBehavior.AllowGet);
                }
   
            }  
        }


        [HttpPost]
        public ActionResult getPacketInfo(int? ID)
        {
            if (ID==null)
            {
                return Json(false, JsonRequestBehavior.AllowGet);
            }
            else
            {
                try
                {
                    var data = service.PacketService.GetAll().Where(x => x.ID == ID).FirstOrDefault();

                    var getInfoData = new PacketVM()
                    {
                        ID=data.ID,
                        PackageName=data.PackageName,
                        PacketDesc=data.PacketDesc,
                        hiddenOldImg=data.PacketImgUrl,
                        PacketPrice=(double)data.PacketPrice,
                        SeoUrlLink=data.SeoUrlLink
                    };

                    return Json(getInfoData, JsonRequestBehavior.AllowGet);


                }
                catch (Exception)
                {

                    return Json(false, JsonRequestBehavior.AllowGet);
                }
            }

        }


        [HttpPost]
        public ActionResult editPacket(PacketVM gelen)
        {

            string resimAdi;

            if (gelen.PacketImgUrl != null)
            {
                var file = gelen.PacketImgUrl;
                var uzanti = Path.GetExtension(file.FileName);
                resimAdi = "/Assets/Images/PacketImages/" + Guid.NewGuid() + uzanti;
                file.SaveAs(Server.MapPath(resimAdi));
            }
            else
            {
                resimAdi = gelen.hiddenOldImg;
            }

            var newSeoUrl = strOp.ToSlug(gelen.SeoUrlLink);
            var varMi = service.PacketService.GetAll().Where(x => x.SeoUrlLink == newSeoUrl).FirstOrDefault();
            if (varMi == null)
            {
                try
                {
                    var UpdatePacket = service.PacketService.Find(gelen.hiddenPacketId);
                    UpdatePacket.PacketImgUrl = resimAdi;
                    UpdatePacket.PackageName = gelen.PackageName;
                    UpdatePacket.SeoUrlLink = newSeoUrl;
                    UpdatePacket.PacketDesc = gelen.PacketDesc;
                    UpdatePacket.PacketPrice = gelen.PacketPrice;

                    service.PacketService.Save();

                    return Json(true, JsonRequestBehavior.AllowGet);
                }
                catch (Exception)
                {

                    return Json(false, JsonRequestBehavior.AllowGet);
                }

            }
            else
            {
                if (varMi.ID == gelen.hiddenPacketId)
                {
                    try
                    {
                        var UpdatePacket = service.PacketService.Find(gelen.hiddenPacketId);
                        UpdatePacket.PacketImgUrl = resimAdi;
                        UpdatePacket.PackageName = gelen.PackageName;
                        UpdatePacket.SeoUrlLink = newSeoUrl;
                        UpdatePacket.PacketDesc = gelen.PacketDesc;
                        UpdatePacket.PacketPrice = gelen.PacketPrice;

                        service.PacketService.Save();

                        return Json(true, JsonRequestBehavior.AllowGet);
                    }
                    catch (Exception)
                    {

                        return Json(false, JsonRequestBehavior.AllowGet);
                    }
                }

                return Json(gelen.SeoUrlLink, JsonRequestBehavior.AllowGet);
            }
        }


        [HttpPost]

        public ActionResult addPacket(PacketVM gelen)
        {
            string resimAdi;

            try
            {

                var newSeoUrl = strOp.ToSlug(gelen.SeoUrlLink);
                var varMi = service.BlogService.GetAll().Where(x => x.SeoUrl == newSeoUrl).FirstOrDefault();
                if (varMi != null) { return Json(gelen.SeoUrlLink, JsonRequestBehavior.AllowGet); }

                if (gelen.PacketImgUrl != null)
                {
                    var file = gelen.PacketImgUrl;
                    var uzanti = Path.GetExtension(file.FileName);

                    resimAdi = "/Assets/Images/PacketImages/" + Guid.NewGuid() + uzanti;
                    file.SaveAs(Server.MapPath(resimAdi));
                }
                else
                {
                    resimAdi = null;
                }

                Packet newPacket = new Packet()
                {
                    
                    SeoUrlLink = newSeoUrl,
                    PackageName = gelen.PackageName,
                    PacketImgUrl = resimAdi,
                    ActOrPass=false,
                    PacketPrice=gelen.PacketPrice,
                    PacketDesc=gelen.PacketDesc

                };
                service.PacketService.Insert(newPacket);
            }
            catch (Exception)
            {

                return Json(false, JsonRequestBehavior.AllowGet);
            }

            return Json(true, JsonRequestBehavior.AllowGet);


        }








    }
}