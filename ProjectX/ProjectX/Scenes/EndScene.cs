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
    class EndScene : PlayerInfo
    {
        public void StartScene2()
        {
            Clear();
            WriteLine($"Поздравляем {Name}, вы победили!");
            WriteScore();
            if (Mail != null)
            {
                SendMailMesseage();
            }
            WriteLine("Для выхода введите любую кнопку...");
            ReadLine();
            Environment.Exit(0);
        }
        void WriteScore()
        {
            string path = @"D:\gitHub\ProjectX\ProjectX\ProjectX\ScoreList.txt";
            string text = "Игрок: " + Name + " Время и дата победы: " + DateTime.Now;
            using (StreamWriter streamWriter = new StreamWriter(path, true))
            {
                streamWriter.WriteLine(text);
            }
        }
        void SendMailMesseage()
        {
            SendEmailAsync().GetAwaiter();
            
        }
            private static async Task SendEmailAsync()
            { 
            using (MailMessage mail = new MailMessage())
            {
                
                mail.From = new MailAddress("xproject894@gmail.com", "Team ProjectX");
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
                    try
                    {
                       await smtp.SendMailAsync(mail);
                    }
                    catch (SmtpException)
                    {
                       WriteLine("Что то пошло не так...");
                    }
                }
}
            }     
    }
}
