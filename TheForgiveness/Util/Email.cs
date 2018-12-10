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
        public bool SendMail(string un, string id)
        {
            if (ValidUser(id, un))
            {

                try
                {
                    MailMessage mail = new MailMessage();
                    System.Data.DataRow email = MySQL.Querys("SELECT Email  FROM Email  WHERE Persona = (Select Persona From Usuario WHERE UserName = '" + un + "' AND State='Activo') AND State='Activo' LIMIT 1").Rows[0];
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
            return "<h1>Hola! baby!!</h1>";
        }

        public bool ValidUser(string id, string un)
        {
            return MySQL.Querys("SELECT ID FROM Persona WHERE NumIdentificacion = '" + id + "' AND ID =(SELECT Persona FROM Usuario WHERE UserName = '" + un + "' AND State='Activo' ) AND State='Activo';").Rows.Count > 0;
        }

    }
}