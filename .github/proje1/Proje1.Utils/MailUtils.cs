using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http.Headers;
using System.Net.Mail;
using System.Text;
using System.Threading.Tasks;

namespace Proje1.Utils
{
    public static class MailUtils
    {


        public static void SendMail(string mailAdress,string title,string message)
        {
            MailMessage message1 = new MailMessage();
            SmtpClient smtpClient = new SmtpClient(/*"smtp.gmail.com", 587*/);
            smtpClient.Credentials = new NetworkCredential("proje1deneme@hotmail.com", "sifre1919");
            smtpClient.Port = 587;
            smtpClient.Host = "smtp.live.com";
            smtpClient.EnableSsl = true;
            message1.To.Add(mailAdress);
            message1.From=new MailAddress("proje1deneme@hotmail.com");
            message1.Subject = title;
            message1.Body = message;
            smtpClient.Send(message1);
        }
    }
}
