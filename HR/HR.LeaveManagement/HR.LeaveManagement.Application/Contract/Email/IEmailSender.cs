using HR.LeaveManagement.Application.Model.Email;

namespace HR.LeaveManagement.Application.Contract.Email
{
    public interface IEmailSender
	{
		Task<bool> SendEmailAsync(EmailMessage email);
	}
}
