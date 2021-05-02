using InnovaSolTest.Models.ServiceModels;
using InnovaSolTest.Services.Interfaces;
using Microsoft.Extensions.Configuration;
using System;
using System.Net.Mail;
using System.Threading.Tasks;

namespace InnovaSolTest.Services.Managers
{
    public class EmailService : IEmailService
    {
        private readonly IConfiguration _configuration;
        public EmailService(IConfiguration configuration)
        {
            _configuration = configuration;
        }
        public async Task SendEmailAsync(EmailDto emailDto)
        {

            try
            {
                await Task.Delay(1);
                var smtpSettings = GetSmtpSettings();
                var mailMessage = new MailMessage
                {
                    From = new MailAddress(smtpSettings.From, "Innnova Solution Test"),
                    BodyEncoding = System.Text.Encoding.UTF8,
                    Body = emailDto.Body,
                    Subject = emailDto.Subject,
                    IsBodyHtml = true
                };

                foreach (var toadd in emailDto.ToAddress)
                {
                    mailMessage.To.Add(toadd);
                }

                using (var smtpClient = new SmtpClient(smtpSettings.Host))
                {
                    smtpClient.EnableSsl = true;
                    smtpClient.UseDefaultCredentials = false;
                    smtpClient.Port = smtpSettings.Port;
                    smtpClient.Credentials = new System.Net.NetworkCredential(smtpSettings.User, smtpSettings.Pwd);
                    smtpClient.Send(mailMessage);
                    smtpClient.Dispose();
                }
                
            }
            catch
            {
                throw;
            }
        }

        
        private SmtpSettingsDto GetSmtpSettings()
        {
            return new SmtpSettingsDto()
            {
                From = _configuration.GetSection("Smtp:From").Value,
                Host = _configuration.GetSection("Smtp:Host").Value,
                Port = Convert.ToInt32(_configuration.GetSection("Smtp:Port").Value),
                User = _configuration.GetSection("Smtp:User").Value,
                Pwd = _configuration.GetSection("Smtp:Pwd").Value,
            };
        }
    }
}
