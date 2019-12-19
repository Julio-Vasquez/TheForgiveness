using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Mail;
using System.Web;


namespace TheForgiveness.Util
{
    public class Email
    {
        public bool SendMail(string un, string id)
        {
            Services.UserService services = new Services.UserService();
            if (services.ValidUser(id, un))
            {
                try
                {
                    MailMessage mail = new MailMessage();
                    System.Data.DataRow email = services.InfoEMailUser(un);
                    mail.To.Add(email["Email"].ToString());
                    mail.From = new MailAddress("TheForgiveness@TheForgiveness.co");
                    mail.Subject = "Reset Password";
                    mail.Body = bodySMS();
                    mail.IsBodyHtml = true;
                    mail.Priority = MailPriority.High;
                    SmtpClient smtp = new SmtpClient
                    {
                        UseDefaultCredentials = false,
                        Host = "smtp.gmail.com",
                        Port = 587,
                        EnableSsl = true,
                        DeliveryMethod = SmtpDeliveryMethod.Network,
                        Credentials = new System.Net.NetworkCredential("TheForgivenessOficial@gmail.com", "phurion123")
                    };

                    smtp.Send(mail);
                    return true;
                }
                catch (Exception e)
                {
                    Console.Write("ush algo malo paso" + e.ToString());
                    return false;
                }
            }
            else
            {
                return false;
            }

        }

        public string bodySMS()
        {
            return "<!DOCTYPE html>" +
                        "<html style='padding: 0;margin: 0;'>" +
                            "<head>" +
                                "<meta http-equiv='Content-Type' content='text/html; charset=utf-8'>" +
                                "<meta name='viewport' content='width=device-width, initial-scale=1'>" +
                            "</head>" +
                            "<body style='padding: 0;margin: 0;'>" +
                                "<table width='100%' height='100%'>" +
                                    "<tr>" +
                                        "<td width='100%' height='500px' bgcolor='#e2e3e7'>" +
                                            "<div style='padding: 0;margin: 0;width: 100%;color: #959595;font: normal 12px/2.0em Sans-Serif;height: -webkit-fill-available;background: url('https://firebasestorage.googleapis.com/v0/b/panamazonico-2e754.appspot.com/o/REGISTRO-03.png?alt=media&token=3262e4da-f677-4a53-96d5-7e963c4f574a') no-repeat center right rgba(239, 242, 247);background-color: rgba(239, 242, 247);background-size: 300px;'>" +
                                                "<header style='margin: 0;padding: 0;'>" +
                                                    "<div style='margin: 0 auto;padding: 0;max-width: 970px;' >" +
                                                        "<div style='padding: 0;width: auto;float: left;'>" +
                                                            "<h1>" +
                                                                "<a href='#'>" +
                                                                    "<img style='width: 100px;' src='https://firebasestorage.googleapis.com/v0/b/panamazonico-2e754.appspot.com/o/REGISTRO-09.png?alt=media&token=ad9a8eb4-8fc5-4112-a061-78e9795675f2' alt=''>" +
                                                                "</a>" +
                                                            "</h1>" +
                                                        "</div>" +
                                                        "<div style='clear: both;padding: 0;margin: 0;width: 100%;font-size: 0px;line-height: 0px;'>" +
                                                        "</div>" +
                                                    "</div>" +
                                                "</header>" +
                                                "<div style='margin: 0;padding: 0;'>" +
                                                    "<div style='margin: 0 auto;padding: 10px 0;max-width: 970px;'>" +
                                                        "<main style='margin: 0;padding: 0;'>" +
                                                            "<div style='margin: 0 0 24px;padding: 0 20px 0 15px;'>" +
                                                                "<span style='color: #3c1012a8;font-family: Proxima Nova, 'proxima_nova_regular', Helvetica, Arial, sans-serif;font-size: 30px;display: block;text-align: center;margin-bottom: 6px;'>" +
                                                                    "Recupera tu contraseña" +
                                                                "</span>" +
                                                                "<span style='color: #8392a7;font-family: Proxima Nova, 'proxima_nova_regular', Helvetica, Arial, sans-serif;font-size: 18px;display: block;text-align: center;margin-bottom: 30px;'>" +
                                                                    "Si quieres cambiar tu contraseña, haz click acá" +
                                                                "</span>" +
                                                                "<a style='background-color: #9c2820cc;border: none;color: white;padding: 15px 32px;text-align: center;text-decoration: none;display: inline-block;font-size: 16px;margin: 4px 2px;cursor: pointer;border-radius: 6px;margin: 0px auto;display: block;' href='{{url}}'>" +
                                                                    "Recuperar Contraseña" +
                                                                "</a>" +
                                                            "</div>" +
                                                        "</main>" +
                                                    "<div class='clr'>" +
                                                "</div>" +
                                            "</div>" +
                                        "</div>" +
                                        "<footer style='margin: 0;padding: 0;'>" +
                                            "<div style='margin: auto;text-align: center;padding: 12px;max-width: 922px;'>" +
                                                "<p>" +
                                                    "&copy; Copyright " +
                                                    "<a style='color: #aa433e;text-decoration: none;' href='#'>" +
                                                        "TheForgivenes" +
                                                    "</a> " +
                                                    "&#124;" +
                                                "</p>" +
                                                "<div class='clr'>" +
                                                "</div>" +
                                            "</div>" +
                                        "</footer>" +
                                    "</div>" +
                                "</td>" +
                            "</tr>" +
                        "</table>" +
                    "</body>" +
                "</html>";
        }
    }
}