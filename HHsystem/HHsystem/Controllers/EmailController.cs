using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.Mail;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace HHsystem.Controllers
{
    class EmailController
    {
        DatabaseManager manager = new DatabaseManager();

        public void sendEmail(int id, string client, string employee, string date, string time)
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
                mail.To.Add("eric_odding@hotmail.com, swabe@live.co.za");
                mail.Subject = "Confirmation of Appointment for";
                //mail.Body = "Dear " + client + "\n\n" +
                //    "We hereby confirm your appointment at Heydt of Hair Design as follows:\n\n" +
                //    "Hairdresser: " + employee + "\n" +
                //    "Date: " + date + "\n" +
                //    "Time: " + time + "\n\n" +
                //    "If you wish to change your appointment, please contact us again.\n\n" + 
                //    "Kind regards\n" +
                //    "Heydt of Hair";
                using (StreamReader reader = File.OpenText("C:\\Users\\Andrew\\Documents\\Projects\\HairSalonManagementSystem\\basic.html"))
                {
                    body = reader.ReadToEnd();
                    
                }
                body = body.Replace("?@client", employee);
                body =body.Replace("?@employee", employee);
                body=body.Replace("?@date", date);
                body=body.Replace("?@time", time);
                mail.Body = body;
                mail.IsBodyHtml = true;
                SmtpServer.Port = 587;
                SmtpServer.Credentials = new System.Net.NetworkCredential("SP300Test".Trim(), "cTIgROUP5".Trim());
                SmtpServer.EnableSsl = true;

                SmtpServer.Send(mail);
                MessageBox.Show("Confirmation Sent to " + toAddess);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }
    }
}
