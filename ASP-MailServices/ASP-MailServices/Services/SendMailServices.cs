using System;
using System.Net.Mail;
using System.Threading.Tasks;
using Microsoft.Extensions.Options;
using MimeKit;

public class SendMailServices
{
    MailSettings _mailSettings { get; set; }
    public SendMailServices(IOptions<MailSettings> mailSettings)
    {
        _mailSettings = mailSettings.Value;
    }
    public async Task<string> SendMail(MailContent content)
    {
        var email = new MimeMessage(); // using MimeKit

        // contact infor
        email.Sender = new MailboxAddress(_mailSettings.DisplayName, _mailSettings.Mail);
        email.From.Add(new MailboxAddress(_mailSettings.DisplayName, _mailSettings.Mail));
        email.To.Add(new MailboxAddress(content.To, content.To));

        // content
        email.Subject = content.Subject;
        var builder = new BodyBuilder();
        builder.HtmlBody = content.Body;
        email.Body = builder.ToMessageBody();
        // config server smtp
        using var smtp = new MailKit.Net.Smtp.SmtpClient();
        try
        {
            // open connect to email server
            await smtp.ConnectAsync(_mailSettings.Host, _mailSettings.Port, MailKit.Security.SecureSocketOptions.StartTls);
            // authenticate username and password to connect server
            await smtp.AuthenticateAsync(_mailSettings.Mail, _mailSettings.Password);
            // 
            await smtp.SendAsync(email);
            return "Gui mail thanh cong";
        }
        catch (Exception e)
        {
            return $"Gui mail khong thanh cong, loi: {e.Message}";
        }
        finally
        {
            smtp.Disconnect(true);
        }
    }
}
public class MailContent
{
    public string To { get; set; }
    public string Subject { get; set; }
    public string Body { get; set; }
}