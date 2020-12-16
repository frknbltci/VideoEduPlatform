using MehmetEgitKurumsal.DAL.DB;
using MehmetEgitKurumsalWeb.UI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Text;
using System.Text.RegularExpressions;
using System.Web;
using System.Web.Mvc;

namespace MehmetEgitKurumsalWeb.UI.Controllers
{
    public class HomeController : BaseController
    {

        
        //Eğtiimler kısmı dinamikleştirilebilir istek üzerine 
        //Mail gönderimi "fbaltaci.34@gmail.com" 'dan yapılıyor ona güzenleme getirip mail içeriği düzeltilecek 

        //Footer'da statik kısımlar var

    
        // GET: Home
        public ActionResult Index()
        {

            var generalSet = service.GeneralSettingsService.GetAll().FirstOrDefault();
            var sliderData = service.SliderService.GetAll().ToList();

           var announcementList = service.AnnouncementService.GetAll().Where(x=>x.ActOrPass==true).OrderBy(x => x.SortNumber).Take(5).ToList();

           var blogList = service.BlogService.GetAll().Where(x=>x.Status==true).OrderByDescending(x => x.ID).Take(10).ToList();

            var bilgiSayfalariList = service.PageService.GetAll().Where(x => x.Category == 1 && x.Status == true).OrderByDescending(x=>x.ID).Take(9).ToList();

            var sistemBilgiSayfalari = service.PageService.GetAll().Where(x => x.Category == 2 && x.Status == true).OrderByDescending(x => x.ID).Take(4).ToList();


            var blogTarihList = service.BlogService.GetAll().Where(x => x.CategoryID == 1 && x.Status == true).OrderByDescending(x => x.ID).Take(5).ToList();
            var blogCogList = service.BlogService.GetAll().Where(x => x.CategoryID == 2 && x.Status==true).OrderByDescending(x => x.ID).Take(5).ToList();

            var teacherList= service.VideoEducationTeacherService.GetAll().OrderByDescending(x => x.ID).Take(5).ToList();

            foreach (var item in blogTarihList )
            {
                string noHTML = strOp.FormatString(item.BlogContent);
                
                item.BlogContent = noHTML;

            }

            foreach (var item in blogCogList)
            {
                string noHTML = strOp.FormatString(item.BlogContent);

                item.BlogContent = noHTML;
            }

            foreach (var item in sistemBilgiSayfalari)
            {
                string noHTML = strOp.FormatString(item.Text);

                item.Text = noHTML;
            }


            var VmList = new HomeVM() { 
                
                Slider = sliderData[0],
                AnnouncementList= announcementList,
                BlogList=blogList,
                BilgiSayfalariList=bilgiSayfalariList,
                SistemBilgiList=sistemBilgiSayfalari,
                cografyaList=blogCogList,
                tarihList=blogTarihList,
                TeacherList=teacherList,
                GeneralSettings=generalSet
               
            };

            return View(VmList);
        }



        [HttpPost]
        public ActionResult findAnnoun(int? ID)
        {
            if (ID !=null)
            {
             //null dönüşü istenilen gibi alınamıyor bakılabilir çok önemli değil  
                    return Json(service.AnnouncementService.Find((int)ID).AnContent, JsonRequestBehavior.AllowGet);
              
            }
            else
            {
                return Json(false,JsonRequestBehavior.AllowGet);
            }
            
        }


        public ActionResult sendContactInfo(ContactMainVM gelen)
        {

            if (ModelState.IsValid)
            {
                ContactMain data = new ContactMain()
                {
                    Mail = gelen.Email,
                    NameSurname = gelen.NameSurname,
                    Phone = gelen.Phone,
                    CreatedAt=DateTime.Now
                };

                var fromAddress = new MailAddress(gelen.Email);
                var toAddress = new MailAddress(gelen.Email);
                const string subject = "wwww.mehmetegit.com | Sitenizden Gelen İletişim Formu";

                string body = "Adı Soyadı :" + gelen.NameSurname + "Telefon Numarası" + gelen.Phone + "Email Adresi : " + gelen.Email;
                using (var smtp = new SmtpClient
                {
                    Host = "smtp.gmail.com",
                    Port = 587,
                    EnableSsl = true,
                    DeliveryMethod = SmtpDeliveryMethod.Network,
                    UseDefaultCredentials = false,
                    Credentials = new NetworkCredential("fbaltaci.34@gmail.com", "furkan_B")
                })
                {
                    using (var message = new MailMessage(fromAddress, toAddress) { Subject = subject, Body = body })
                    {
                        try
                        {
                            service.ContactMainService.Insert(data);
                            smtp.Send(message);
                        }
                        catch (Exception)
                        {
                            service.ContactMainService.Insert(data);
                            return Json("err", JsonRequestBehavior.AllowGet);
                        }
                       
                    }
                }
                return Json(true, JsonRequestBehavior.AllowGet);
            }
            else
            {
                return Json(false, JsonRequestBehavior.AllowGet);
            }



            
        }
    }
}