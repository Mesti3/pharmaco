using System;
using System.Net.Mail;

namespace pharmaco.log
{
    public class logger
    {
        public static void send_email(Exception ex, string client_id, string subject = "error")
        {
            try
            {
                MailMessage mail = new MailMessage();
                SmtpClient SmtpServer = new SmtpClient("smtp.gmail.com");

                mail.From = new MailAddress(client_id+ ".pharmaco@gmail.com");
                mail.To.Add("zdenka.polakovicova@gmail.com");
                mail.Subject = subject;
                mail.Body = "Exception:" + Environment.NewLine + ex.ToString() + Environment.NewLine + Environment.NewLine;
                while (ex.InnerException != null)
                    mail.Body += "InnerException:" + Environment.NewLine + ex.ToString() + Environment.NewLine + Environment.NewLine;
                foreach (System.Collections.DictionaryEntry d  in ex.Data)
                    mail.Body += d.Key + ":\t"+ d.Value + Environment.NewLine + Environment.NewLine;

                SmtpServer.Port = 587;
                SmtpServer.UseDefaultCredentials = false;
                SmtpServer.Credentials = new System.Net.NetworkCredential("zdenka.polakovicova@gmail.com", "tu doplniť heslo");
            
                SmtpServer.EnableSsl = true;

                SmtpServer.Send(mail);
            }
            catch (Exception exception)
            {
                //nedá sa nič robiť - zamlčíme exception
                //iba keby sme mali textový log
            }
        }
    }
}
