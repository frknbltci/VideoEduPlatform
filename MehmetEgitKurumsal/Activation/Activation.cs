using MehmetEgitKurumsal.BLL.Repository.Service;
using System;
using System.Web;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Net.Mail;
using System.Net;

namespace MehmetEgitKurumsal.Activation
{
   public class Activation
    {

        protected EntityService service = new EntityService();

        public bool SendConfirmationEmail(string email)
        {

            var user = service.UserService.GetAll().Where(x => x.Email == email).FirstOrDefault();
            if (user !=null)
            {
                if (user.Status == false)
                {
                    string confirmationGuid = Guid.NewGuid().ToString();
                    string verifyUrl = System.Web.HttpContext.Current.Request.Url.GetLeftPart(UriPartial.Authority) +
                                       "/Account/Verify?Id=" +
                                       confirmationGuid;

                    user.MailKey = confirmationGuid;
                    service.UserService.Save();

                    string bodyMessage = string.Format("üyeliğiniz başarıyla oluşturulmuştur. Aşağıdaki linke tıkladığınızda hesabınızın aktif olacaktır.\n");
                    bodyMessage += verifyUrl;

                    var fromAddress = new MailAddress("fbaltaci.34@gmail.com");
                    var toAddress = new MailAddress(user.Email);


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
                        using (var message = new System.Net.Mail.MailMessage("fbaltaci.34@gmail.com", user.Email)
                        {
                            Subject = "Üyeliğinizi doğrulayın.",
                            Body = bodyMessage
                        })
                        {
                            try
                            {
                                smtp.Send(message);
                                return true;
                            }
                            catch (Exception)
                            {
                                return false;

                            }

                        }
                    }
                }
                else
                {
                    return false;
                }
            }
            else
            {
                return false;
            }


            

        }
    }
}
