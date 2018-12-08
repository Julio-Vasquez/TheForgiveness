using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Mail;
using System.Web;


namespace TheForgiveness.Util
{
    public class Email
    {
        private static ConnectionDB.ConnectionMySQL MySQL = new ConnectionDB.ConnectionMySQL();
        public bool SendMail(string un)
        {
           MailMessage mail = new MailMessage();
            
            System.Data.DataRow id = MySQL.Querys("SELECT Persona AS ID FROM Usuario WHERE UserName='" + un + "' AND State='Activo'").Rows[0], email = MySQL.Querys("SELECT Email FROM Email WHERE Persona = " + int.Parse(id["ID"].ToString()) + " AND State='Activo' LIMIT 1").Rows[0];
            mail.To.Add(email["Email"].ToString());
            mail.From = new MailAddress("TheForgiveness@gmail.com");
            mail.Subject = "Reset Password";
            mail.Body = bodySMS();
            mail.IsBodyHtml = true;
            mail.Priority = MailPriority.High;
            SmtpClient smtp = new SmtpClient
            {
                UseDefaultCredentials = false,
                Host = "smtp.live.com",
                Port = 587,
                EnableSsl = true,
                DeliveryMethod = SmtpDeliveryMethod.Network,
                Credentials = new System.Net.NetworkCredential("jualvali@live.com", "halo2vasquez")
            };
            try
            {
                smtp.Send(mail);
                return true;
            }
            catch (Exception e)
            {
                Console.Write("ush algo malo paso" + e.ToString());
                return false;
            }
            
        }

        public string bodySMS()
        {
            return "<h1>Hola! baby!!</h1>";
        }

    }
}