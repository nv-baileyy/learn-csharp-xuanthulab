using System.Net.Mail;
using System;
using System.Threading.Tasks;
using System.Net;
using Microsoft.Extensions.Options;

namespace MailUtils
{
    public class MailUtils
    {
        // send mail from local server : install Mail Transpoter required
        public static async Task<string> SendMail(string _from, string _to, string _subject, string _body)
        {
            // Setting up Mail message
            MailMessage message = new MailMessage(_from, _to, _subject, _body);
            message.BodyEncoding = System.Text.Encoding.UTF8;
            message.SubjectEncoding = System.Text.Encoding.UTF8;
            // all body content is html file
            message.IsBodyHtml = true;
            message.BodyEncoding = System.Text.Encoding.UTF8;
            // chooose who can reply message
            message.ReplyToList.Add(new MailAddress(_from));
            message.Sender = new MailAddress(_from);
            /// -------------------------- END setting Mail Message
            // Use LOCAL SERVER
            using var smtpclient = new SmtpClient("localhost");
            try
            {
                await smtpclient.SendMailAsync(message);
                return "Gui email thanh cong";
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                return "Gui email that bai";
            }
        }
        // Send mail using GMail Server
        public static async Task<string> SendGMail(string _from, string _to, string _subject, string _body, string _gmail, string _password)
        {
            // Setting up Mail message
            MailMessage message = new MailMessage(_from, _to, _subject, _body);
            message.BodyEncoding = System.Text.Encoding.UTF8;
            message.SubjectEncoding = System.Text.Encoding.UTF8;
            // all body content is html file
            message.IsBodyHtml = true;
            message.BodyEncoding = System.Text.Encoding.UTF8;
            // chooose who can reply message
            message.ReplyToList.Add(new MailAddress(_from));
            message.Sender = new MailAddress(_from);
            /// -------------------------- END setting Mail Message

            // USE GMAIL SERVER
            using var smtpclient = new SmtpClient("smtp.gmail.com");
            // filling connection by google
            smtpclient.Port = 587;
            smtpclient.EnableSsl = true;
            smtpclient.Credentials = new NetworkCredential(_gmail, _password);

            try
            {
                await smtpclient.SendMailAsync(message);
                return "Gui email thanh cong";
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                return "Gui email that bai";
            }   
        }
    }
}