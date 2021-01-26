using System;
using System.Collections.Generic;
using System.Text;
using static System.Console;
using System.IO;
using System.Threading.Tasks;
using System.Net.Mail;
using System.Net;

namespace ProjectX
{
    class Scene2 : PlayerInfo
    {
        public void StartScene2()
        {
            Clear();
            WriteLine("Ура");
            WriteScore();
            SendMailMesseage();
        }

        void WriteScore()
        {
            string path = @"D:\gitHub\ProjectX\ProjectX\ProjectX\ScoreList.txt";
            string text = Name + " " + DateTime.Now;
            using (StreamWriter streamWriter = new StreamWriter(path))
            {
                streamWriter.Write(text);
            }
        }
        void SendMailMesseage()
        {
            using (MailMessage mail = new MailMessage())
            {
                
                mail.From = new MailAddress("xproject894@gmail.com");
                mail.To.Add(Mail);
                mail.Subject = "ProjectX";
                mail.Body = "<h1>You Win<h/>";
                mail.IsBodyHtml = true;
                using (SmtpClient smtp = new SmtpClient())
                {
                    smtp.UseDefaultCredentials = false;
                    smtp.Credentials = new NetworkCredential("xproject894@gmail.com", "project_X_27");
                    smtp.Host = "smtp.gmail.com";
                    smtp.Port = 587;
                    smtp.EnableSsl = true;
                    smtp.DeliveryMethod = SmtpDeliveryMethod.Network;
                    smtp.Timeout = 3000;
                    try
                    {
                        smtp.Send(mail);
                    }
                    catch (SmtpException e)
                    {
                        Console.WriteLine(e);
                    }
                }
            }
          
        }
    }
}
