using MehmetEgitKurumsal.DAL.DB;
using MehmetEgitKurumsal.UI.Attribute;
using MehmetEgitKurumsal.UI.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Security.Principal;
using System.Web;
using System.Web.Mvc;

namespace MehmetEgitKurumsal.UI.Controllers
{
    public class UserController : BaseController
    {
        [Auth]

        [HttpGet]
        public ActionResult ListUsers()
        {
            var users = service.UserService.GetAll().ToList();
            return View(users);
        }


        [HttpPost]
        public ActionResult getUserInfo(int? ID)
        {
            if (ID != null || ID != 0)
            {
                var info = service.UserService.Find((int)ID);
                var newBirth = info.BirthDate.Value.Year.ToString() + "-" + info.BirthDate.Value.Month.ToString() + "-" + info.BirthDate.Value.Day.ToString();
                var newMemberDate = info.MemberShipDate.Value.Year.ToString() + "-" + info.MemberShipDate.Value.Month.ToString() + "-" + info.MemberShipDate.Value.Day.ToString();


                UserVM infoReturn = new UserVM()
                {

                    sBirthDate = newBirth,
                    sMemberShipDate = newMemberDate,
                    Discount = info.Discount,
                    Email = info.Email,
                    Name = info.Name,
                    Status = (bool)info.Status,
                    Surname = info.Surname,
                    Password = info.Password,
                    UserName = info.UserName,
                    Type = (bool)info.Type,
                    Resume = info.Resume,
                    Phone = info.Phone,
                    ImageUrl = info.ImageUrl
                };

                return Json(infoReturn, JsonRequestBehavior.AllowGet);
            }
            else
            {
                return Json(false, JsonRequestBehavior.AllowGet);
            }
        }

        [HttpPost]

        public ActionResult addUser(UserVM gelen)
        {

            var varMiData = service.UserService.GetAll().Where(x => x.UserName == gelen.UserName && x.Email == gelen.Email).SingleOrDefault();

            if (varMiData != null)
            {

                return Json(gelen.Email, JsonRequestBehavior.AllowGet);

            }
            else
            {
                if (gelen.Name != null && gelen.Surname != null && gelen.UserName != null && gelen.Password != null && gelen.Email != null)
                {
                    

                    User newUser = new User()
                    {
                        Email = gelen.Email,
                        Phone = gelen.Phone,
                        UserName = gelen.UserName,
                        Surname = gelen.Surname,
                        BirthDate = gelen.BirthDate == DateTime.MinValue ? DateTime.UtcNow : gelen.BirthDate,
                        Discount = gelen.Discount,
                        Password = gelen.Password,
                        Type = gelen.Type,
                        Status = gelen.Status,
                        Name = gelen.Name,
                        MemberShipDate = DateTime.UtcNow.Date

                    };
                    service.UserService.Insert(newUser);
                    return Json(true, JsonRequestBehavior.AllowGet);
                }
                else
                {
                    return Json(false, JsonRequestBehavior.AllowGet);
                }

            }


        }


        public ActionResult makePassiveOrActiveUser(int? ID)
        {
            if (ID != null)
            {
                service.UserService.makePassOrActive((int)ID);
                return Json(true, JsonRequestBehavior.AllowGet);
            }
            else
            {

                return Json(false, JsonRequestBehavior.AllowGet);
            }



        }


        public ActionResult editUser(UserVM gelen)
        {
            var usernameFind = service.UserService.FindUserName(gelen.UserName);
            var emailFind = service.UserService.FindEmail(gelen.Email);

            if (gelen.Email == null && gelen.Email == "" && gelen.UserName == null && gelen.UserName == "" && gelen.Name == null && gelen.Name == "" && gelen.Surname == null && gelen.Surname == "" && gelen.Phone == null && gelen.Phone == "" && gelen.BirthDate == null)
            {
                return Json(false, JsonRequestBehavior.AllowGet);

            }
            else
            {
                if (usernameFind != null)     
                {
                    if (emailFind !=null)
                    {
                        if (usernameFind.ID == emailFind.ID && usernameFind.ID == gelen.ID && emailFind.ID == gelen.ID)
                        {
                            User u = new User()
                            {
                                ID = gelen.ID,
                                BirthDate = gelen.BirthDate == DateTime.MinValue ? DateTime.UtcNow : gelen.BirthDate,
                                Discount = gelen.Discount,
                                Email = gelen.Email,
                                Name = gelen.Name,
                                Status = gelen.Status,
                                Type = gelen.Type,
                                UserName = gelen.UserName,
                                Surname = gelen.Surname,
                                Phone = gelen.Phone,
                                Password = gelen.Password
                            };

                            service.UserService.updateUser(u);

                            return Json(true, JsonRequestBehavior.AllowGet);
                        }
                        else { 
                            return Json(gelen.UserName, JsonRequestBehavior.AllowGet);
                        }
                    }
                    else
                    {  //emailboşgeldi yazılabilir ama user var içeride kontrol yapılmalı aynı user sa güncellenmeli
                        if (usernameFind.ID == gelen.ID) {
                            User u = new User()
                            {
                                ID = gelen.ID,
                                BirthDate = gelen.BirthDate == DateTime.MinValue ? DateTime.UtcNow : gelen.BirthDate,
                                Discount = gelen.Discount,
                                Email = gelen.Email,
                                Name = gelen.Name,
                                Status = gelen.Status,
                                Type = gelen.Type,
                                UserName = gelen.UserName,
                                Surname = gelen.Surname,
                                Phone = gelen.Phone,
                                Password = gelen.Password
                            };

                            service.UserService.updateUser(u);
                            return Json(true, JsonRequestBehavior.AllowGet);
                        }
                        else { 
                            //içeride bu user var 
                        return Json(gelen.UserName, JsonRequestBehavior.AllowGet);
                        }
                    }
            
                }
                else
                {
                 // username yazılabilir 
                    if (emailFind == null)  // email boş geldi hepsi güncellenecek
                    { 
                        User u = new User()
                        {
                            ID = gelen.ID,
                            BirthDate = gelen.BirthDate == DateTime.MinValue ? DateTime.UtcNow : gelen.BirthDate,
                            Discount = gelen.Discount,
                            Email = gelen.Email,
                            Name = gelen.Name,
                            Status = gelen.Status,
                            Type = gelen.Type,
                            UserName = gelen.UserName,
                            Surname = gelen.Surname,
                            Phone = gelen.Phone,
                            Password = gelen.Password
                        };

                        service.UserService.updateUser(u);

                        return Json(true, JsonRequestBehavior.AllowGet);

                    }
                    else
                    {
                        // email dolu geldi
                        if (emailFind.ID == gelen.ID)
                        {
                            User u = new User()
                            {
                                ID = gelen.ID,
                                BirthDate = gelen.BirthDate == DateTime.MinValue ? DateTime.UtcNow : gelen.BirthDate,
                                Discount = gelen.Discount,
                                Email = gelen.Email,
                                Name = gelen.Name,
                                Status = gelen.Status,
                                Type = gelen.Type,
                                UserName = gelen.UserName,
                                Surname = gelen.Surname,
                                Phone = gelen.Phone,
                                Password = gelen.Password
                            };

                            service.UserService.updateUser(u);

                            return Json(true, JsonRequestBehavior.AllowGet);
                        }
                        else
                        { //email var yazamazsın
                            return Json(gelen.Email, JsonRequestBehavior.AllowGet);
                        }
                        
                    }

                    
                }
            }
            
        }



        [HttpPost]   //FORMDATA İLE DEĞİŞECEK
        public ActionResult editAdmin(UserVM gelen) 
        {
            
            var usernameFind = service.UserService.FindUserName(gelen.UserName);
            var emailFind = service.UserService.FindEmail(gelen.Email);
            string resimAdi = null;
            if (gelen.file != null)
            {
                string uzanti = Path.GetExtension(gelen.file.FileName);
                 resimAdi = "/Assets/Images/AdminImages/" + Guid.NewGuid() + uzanti;
                gelen.file.SaveAs(Server.MapPath(resimAdi));  
            }
            else
            {
                resimAdi = gelen.hiddenImage;
                
            }
           
            if (gelen.Email == null || gelen.Email == "" || gelen.UserName == null || gelen.UserName == "" || gelen.Name == null || gelen.Name == "" || gelen.Surname == null && gelen.Surname == "" || gelen.Phone == null || gelen.Phone == "" || gelen.BirthDate == null)
            {

                     return Json(false, JsonRequestBehavior.AllowGet);

            }
            else
            {
                if (usernameFind != null)
                {
                    if (emailFind != null)
                    {
                        if (usernameFind.ID == emailFind.ID && usernameFind.ID == gelen.hiddenId && emailFind.ID == gelen.hiddenId)
                        {

                            try
                            {
                                User u = new User()
                                {
                                    ID = gelen.hiddenId,
                                    Email = gelen.Email,
                                    Name = gelen.Name,
                                    Resume = gelen.Resume,
                                    UserName = gelen.UserName,
                                    Surname = gelen.Surname,
                                    Phone = gelen.Phone,
                                    Password = gelen.Password,
                                    ImageUrl = resimAdi
                                };

                                service.UserService.updateAdmin(u);


                                return Json(true, JsonRequestBehavior.AllowGet);
                            }
                            catch (Exception)
                            {

                                return Json(false, JsonRequestBehavior.AllowGet);
                            } 
                        }
                        else
                        {
            
                             return Json(gelen.UserName, JsonRequestBehavior.AllowGet);
                        }
                    }
                    else
                    {  //emailboşgeldi yazılabilir ama user var içeride kontrol yapılmalı aynı user sa güncellenmeli

                        
                        if (usernameFind.ID == gelen.hiddenId)
                        {


                            try
                            {
                                User u = new User()
                                {
                                    ID = gelen.hiddenId,
                                    Email = gelen.Email,
                                    Name = gelen.Name,
                                    Resume = gelen.Resume,
                                    UserName = gelen.UserName,
                                    Surname = gelen.Surname,
                                    Phone = gelen.Phone,
                                    Password = gelen.Password,
                                    ImageUrl = resimAdi
                                };

                                service.UserService.updateAdmin(u);

                                return Json(true, JsonRequestBehavior.AllowGet);
                            }
                            catch (Exception)
                            {

                                return Json(false, JsonRequestBehavior.AllowGet);
                            }
                        }
                        else
                        {
                            //içeride bu user var 
                          return Json(gelen.UserName, JsonRequestBehavior.AllowGet);
                        }
                    }

                }
                else
                {
                    // username yazılabilir 
                    if (emailFind == null)  // email boş geldi hepsi güncellenecek
                    {

                        try
                        {
                            User u = new User()
                            {
                                ID = gelen.hiddenId,
                                Email = gelen.Email,
                                Name = gelen.Name,
                                Resume = gelen.Resume,
                                UserName = gelen.UserName,
                                Surname = gelen.Surname,
                                Phone = gelen.Phone,
                                Password = gelen.Password,
                                ImageUrl = resimAdi
                            };

                            service.UserService.updateAdmin(u);



                            return Json(true, JsonRequestBehavior.AllowGet);
                        }
                        catch (Exception)
                        {

                            return Json(false, JsonRequestBehavior.AllowGet);
                        }

                       

                    }
                    else
                    {
                        // email dolu geldi
                        if (emailFind.ID == gelen.hiddenId)
                        {

                            try
                            {
                                User u = new User()
                                {
                                    ID = gelen.hiddenId,
                                    Email = gelen.Email,
                                    Name = gelen.Name,
                                    Resume = gelen.Resume,
                                    UserName = gelen.UserName,
                                    Surname = gelen.Surname,
                                    Phone = gelen.Phone,
                                    Password = gelen.Password,
                                    ImageUrl = resimAdi
                                };

                                return Json(true, JsonRequestBehavior.AllowGet);
                            }
                            catch (Exception)
                            {

                                return Json(false, JsonRequestBehavior.AllowGet);
                            }
                        }
                        else
                        { 
                            //email var yazamazsın

                       return Json(gelen.Email, JsonRequestBehavior.AllowGet);
                        }

                    }
                }
            }

        }

    }
}