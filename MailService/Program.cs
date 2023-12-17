using System;
using System.Net;
using System.Net.Mail;

namespace MailService
{
    class Program
    {
        static void Main(string[] args)
        {
            string senderEmail = "sender@gmail.com";
            string senderPassword = "password";
          
            string toEmail = "receiver@gmail.com";

            string subject = "Test e-mail";
            string body = "Hello, This is a test e-mail";
          
            string smtpServer = "smtp.gmail.com";
            int smtpPort = 587;    //It can be changes. (25,465) 

            try
            {
                using (MailMessage mail = new MailMessage())
                {
                    mail.From = new MailAddress(senderEmail);
                    mail.To.Add(toEmail);
                    mail.Subject = subject;
                    mail.Body = body;
                    mail.IsBodyHtml = false;

                    using (SmtpClient smtp = new SmtpClient(smtpServer, smtpPort))
                    {
                        smtp.Credentials = new NetworkCredential(senderEmail, senderPassword);
                        smtp.EnableSsl = true;

                        smtp.Send(mail);
                    }

                    Console.WriteLine("E-mail has been sent successfully");
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("An error occurred while sending the email: " + ex.Message);
            }
        }
    }
}
