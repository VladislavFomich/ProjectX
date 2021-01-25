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
            MailAddress from = new MailAddress("projectxproject@yandex.by", "Team ProjectX");
            MailAddress to = new MailAddress(Mail);
            MailMessage m = new MailMessage (from, to );
            m.Subject = "ProjectX";
            m.Body = "You Win";
            m.IsBodyHtml = true;
            SmtpClient smtp = new SmtpClient("smtp.yandex.ru", 465);
            smtp.Credentials = new NetworkCredential("projectXproject", "projectX");
            smtp.EnableSsl = true;
            smtp.Send(m);
        }
    }
}
