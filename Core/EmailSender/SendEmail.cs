using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Mail;
using System.Text;
using System.Threading.Tasks;

namespace Core
{
    public class SendEmail
    {

        public static void Send(string to, string subject, string body)
        {

            MailMessage mail = new MailMessage();
            mail.From = new MailAddress("hesamehsani211@gmail.com", "فروشگاه اینترنتی حسام");
            mail.To.Add(to);
            mail.Subject = subject;
            mail.Body = body;
            mail.IsBodyHtml = true;

            ////System.Net.Mail.Attachment attachment;
            //// attachment = new System.Net.Mail.Attachment("c:/textfile.txt");
            //// mail.Attachments.Add(attachment);


            SmtpClient SmtpServer = new SmtpClient();
            SmtpServer.Host = "smtp.gmail.com";
            SmtpServer.Port = 587;

            SmtpServer.Credentials = new System.Net.NetworkCredential("hesamehsani211@gmail.com", "sdpbtaysactqipnr");
            SmtpServer.EnableSsl = true;
            SmtpServer.Send(mail);


        }

    }
}
