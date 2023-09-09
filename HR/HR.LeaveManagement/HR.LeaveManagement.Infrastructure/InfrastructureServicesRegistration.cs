using HR.LeaveManagement.Application.Contract.Email;
using HR.LeaveManagement.Application.Contract.Logging;
using HR.LeaveManagement.Application.Model.Email;
using HR.LeaveManagement.Infrastructure.EmailService;
using HR.LeaveManagement.Infrastructure.Logging;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace HR.LeaveManagement.Infrastructure
{
	public static class InfrastructureServicesRegistration
	{
		public static IServiceCollection InfrastructureServices(this IServiceCollection services,IConfiguration configuration )
		{ 
			services.Configure<EmailSettings>(configuration.GetSection("EmailSettings"));
			services.AddTransient<IEmailSender, EmailSender>();
			services.AddScoped(typeof(IAppLogger<>), typeof(LoggerAdapter<>));
			return services;
		}
	}
}