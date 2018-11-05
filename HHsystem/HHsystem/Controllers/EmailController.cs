using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.Mail;
using System.Net.Mime;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace HHsystem.Controllers
{
    class EmailController
    {
        DatabaseManager manager = new DatabaseManager();

        public void sendEmail(int id, string client, string employee, string date, string time, string service)
        {
            new Thread(() =>
            {
                String[,] details = manager.getClientDetails();
            string body;

            string toAddess = "";

            for (int i = 0; i < details.Length; i++)
            {
                if (int.Parse(details[i,0]) == id)
                {
                    toAddess = details[i, 4];
                    break;
                }
            }

            try
            {
                MailMessage mail = new MailMessage();
                SmtpClient SmtpServer = new SmtpClient("smtp.gmail.com");

                mail.From = new MailAddress("SP300Test@gmail.com");
                mail.To.Add(toAddess);  //swabe@live.co.za , eric_odding@hotmail.com
                mail.Subject = "Confirmation of Appointment for " + client;
                using (StreamReader reader = File.OpenText("..\\..\\..\\..\\bookingConfirmation.html"))
                {
                    body = reader.ReadToEnd();
                    
                }
                body = body.Replace("?@client", client);
                body = body.Replace("?@employee", employee);
                body = body.Replace("?@date", date);
                body = body.Replace("?@time", time);
                body = body.Replace("?@service", service);
                mail.IsBodyHtml = true;

                AlternateView htmlView = AlternateView.CreateAlternateViewFromString(body, null, "text/html");
                LinkedResource theEmailImage1 = new LinkedResource("..\\..\\..\\..\\Docs\\heydt-Logo.jpg");
                theEmailImage1.ContentId = "headerlogo";
                LinkedResource theEmailImage2 = new LinkedResource("..\\..\\..\\..\\Docs\\heydt-270x200.jpg");
                theEmailImage2.ContentId = "contentlogo";
                htmlView.LinkedResources.Add(theEmailImage1);
                htmlView.LinkedResources.Add(theEmailImage2);
                mail.AlternateViews.Add(htmlView);

                SmtpServer.Port = 587;
                SmtpServer.Credentials = new System.Net.NetworkCredential("SP300Test".Trim(), "2018Group5".Trim());
                SmtpServer.EnableSsl = true;

                SmtpServer.Send(mail);
                MessageBox.Show("Confirmation Sent to " + toAddess);
                SmtpServer.Dispose();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
            }).Start();
        }

        public void sendRescheduleEmail(int id, string client, string employee, string date, string time, string service)
        {
            String[,] details = manager.getClientDetails();
            string body;

            string toAddess = "";

            for (int i = 0; i < details.Length; i++)
            {
                if (int.Parse(details[i, 0]) == id)
                {
                    toAddess = details[i, 4];
                    break;
                }
            }

            try
            {
                MailMessage mail = new MailMessage();
                SmtpClient SmtpServer = new SmtpClient("smtp.gmail.com");

                mail.From = new MailAddress("SP300Test@gmail.com");
                mail.To.Add(toAddess);  //swabe@live.co.za , eric_odding@hotmail.com
                mail.Subject = "Confirmation for change of Appointment for " + client;
                using (StreamReader reader = File.OpenText("..\\..\\..\\..\\rescheduleConfirmation.html"))
                {
                    body = reader.ReadToEnd();

                }
                body = body.Replace("?@client", client);
                body = body.Replace("?@employee", employee);
                body = body.Replace("?@date", date);
                body = body.Replace("?@time", time);
                body = body.Replace("?@service", service);
                mail.Body = body;
                mail.IsBodyHtml = true;

                AlternateView htmlView = AlternateView.CreateAlternateViewFromString(body, null, "text/html");
                LinkedResource theEmailImage1 = new LinkedResource("..\\..\\..\\..\\Docs\\heydt-Logo.jpg");
                theEmailImage1.ContentId = "headerlogo";
                LinkedResource theEmailImage2 = new LinkedResource("..\\..\\..\\..\\Docs\\heydt-270x200.jpg");
                theEmailImage2.ContentId = "contentlogo";
                htmlView.LinkedResources.Add(theEmailImage1);
                htmlView.LinkedResources.Add(theEmailImage2);
                mail.AlternateViews.Add(htmlView);

                SmtpServer.Port = 587;
                SmtpServer.Credentials = new System.Net.NetworkCredential("SP300Test".Trim(), "2018Group5".Trim());
                SmtpServer.EnableSsl = true;

                SmtpServer.Send(mail);
                MessageBox.Show("Confirmation Sent to " + toAddess);
                SmtpServer.Dispose();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }
    }
}
