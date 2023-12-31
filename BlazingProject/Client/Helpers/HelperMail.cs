﻿using Microsoft.Extensions.Configuration;
using System.Net;
using System.Net.Mail;

namespace BlazingProject.Client.Helpers
{
    public class HelperMail
    {
        private IConfiguration configuration;
        public HelperMail(IConfiguration configuration)
        {
            this.configuration = configuration;
        }

        private MailMessage ConfigureMail(string destinatario,string asunto,string mensaje)
        {
            string from = this.configuration.GetValue<string>("MailSettings:user");
            MailMessage mail = new MailMessage();
            mail.From = new MailAddress(from);
            mail.To.Add(new MailAddress(from));
            mail.Subject = asunto;
            mail.Body = mensaje;
            mail.IsBodyHtml = true;
            return mail;
        }
        private void ConfigureSmtp(MailMessage mail) {
            string user = this.configuration.GetValue<string>("MailSettings:user");
            string password = this.configuration.GetValue<string>("MailSettings:password");
            string host = this.configuration.GetValue<string>("MailSettings:host");
            SmtpClient client = new SmtpClient();
            client.Port = 587;
            client.EnableSsl=true;
            client.UseDefaultCredentials = false;
            client.Host = host;
            NetworkCredential credentials = new NetworkCredential(user, password);
            client.Credentials = credentials;
            client.Send(mail);
        }
        public void SendMail(string destinatario,string asunto,string mensaje)
        {
            MailMessage mail = this.ConfigureMail(destinatario,asunto,mensaje);
            this.ConfigureSmtp(mail);
        }
    }
}
