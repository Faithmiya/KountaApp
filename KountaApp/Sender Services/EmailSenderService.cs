using KountaApp.Sender_Settings;
using Microsoft.Extensions.Options;
using SendGrid.Helpers.Mail;
using SendGrid;
using Microsoft.AspNetCore.Identity.UI.Services;

namespace KountaApp.Sender_Services
{
    public class EmailSenderService : IEmailSender
    {

        private readonly ISendGridClient _sendGridClient;

        private readonly SendGridSettings _sendGridSettings;

        public EmailSenderService(ISendGridClient sendGridClient, IOptions<SendGridSettings> sendGridSettings)
        {
            _sendGridClient = sendGridClient;
            _sendGridSettings = sendGridSettings.Value;

        }
        public async Task SendEmailAsync(string email, string subject, string htmlMessage)
        {
            // sending logic

            var msg = new SendGridMessage()
            {
                From = new EmailAddress(_sendGridSettings.FromEmail, _sendGridSettings.EmailName),
                Subject = subject,
                HtmlContent = htmlMessage
            };
            msg.AddTo(email);
            await _sendGridClient.SendEmailAsync(msg);

        }
    }
}
