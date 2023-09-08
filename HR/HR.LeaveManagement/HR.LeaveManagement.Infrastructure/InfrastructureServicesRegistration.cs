using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace HR.LeaveManagement.Infrastructure
{
	public static class InfrastructureServicesRegistration
	{
		public static IServiceCollection InfrastructureServices(this IServiceCollection services, IConfiguration configuration)
		{

			return services;
		}
	}
}