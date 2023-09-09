using HR.LeaveManagement.Application.Contract.Email;
using HR.LeaveManagement.Application.Model.Email;
using Microsoft.Extensions.Options;
using SendGrid;
using SendGrid.Helpers.Mail;

namespace HR.LeaveManagement.Infrastructure.EmailService
{
    public class EmailSender : IEmailSender
	{
		public EmailSettings _emailSetting { get; }
        public EmailSender(IOptions<EmailSettings> emailSetting)
        {
            _emailSetting = emailSetting.Value;
        }
        public async Task<bool> SendEmailAsync(EmailMessage email)
		{
			var client = new SendGridClient(_emailSetting.ApiKey);
			var to = new EmailAddress(email.To);
			var from = new EmailAddress {
				Email = _emailSetting.FromAddress,
				Name=_emailSetting.FromName
			
			};
			var message = MailHelper.CreateSingleEmail(from, to,email.Subject,email.Body,email.Body);
			var respone=await client.SendEmailAsync(message);
			return respone.IsSuccessStatusCode;
		}
	}
}
