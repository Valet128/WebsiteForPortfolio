﻿using MailKit.Net.Smtp;
using MimeKit;

namespace ShvedovaAV.Services
{
    public class EmailService
    {
        public static async Task SendEmailAsync(string email, string subject, string message)
        {
           
                var emailMessage = new MimeMessage();

                emailMessage.From.Add(new MailboxAddress("АШАШ", "mail@mail.com"));
                emailMessage.To.Add(new MailboxAddress("", email));
                emailMessage.Subject = subject;
                emailMessage.Body = new TextPart(MimeKit.Text.TextFormat.Html)
                {
                    Text = message
                };
                using (var client = new SmtpClient())
                {
                    await client.ConnectAsync("smtp.mail.ru", 465, true);
                    await client.AuthenticateAsync("mail@mail.com", "password");
                    await client.SendAsync(emailMessage);

                    await client.DisconnectAsync(true);
                }
            
        }
        public static async Task SendEmailsAsync(string[] emails, string subject, string message)
        {
            foreach (var email in emails)
            {
                var emailMessage = new MimeMessage();

                emailMessage.From.Add(new MailboxAddress("АШАШ", "mail@mail.com"));
                emailMessage.To.Add(new MailboxAddress("", email));
                emailMessage.Subject = subject;
                emailMessage.Body = new TextPart(MimeKit.Text.TextFormat.Plain)
                {
                    Text = message
                };
                using (var client = new SmtpClient())
                {
                    await client.ConnectAsync("smtp.mail.ru", 465, true);
                    await client.AuthenticateAsync("mail@mail.com", "password");
                    await client.SendAsync(emailMessage);

                    await client.DisconnectAsync(true);
                }
            }
        }
    }
}
