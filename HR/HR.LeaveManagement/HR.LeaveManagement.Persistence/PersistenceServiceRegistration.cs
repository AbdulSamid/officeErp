﻿using HR.LeaveManagement.Application.Contract.Persistence;
using HR.LeaveManagement.Persistence.DatabaseContext;
using HR.LeaveManagement.Persistence.Repository;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.SqlServer.Query.Internal;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace HR.LeaveManagement.Persistence
{
	public static class PersistenceServiceRegistration
	{
		public static IServiceCollection AddPersistenceService(this IServiceCollection services, IConfiguration configuration)
		{
			services.AddDbContext<HRDatabaseContext>(options =>
			{
				options.UseSqlServer(configuration.GetConnectionString("HRDatabaseConnectionString"));
			});
			services.AddScoped(typeof(IGenericRepository<>),typeof(GenericRepository<>));
			services.AddScoped<ILeaveTypeRepository,LeaveTypeRepository>();
			services.AddScoped<ILeaveRequestRepository,LeaveRequestRepository>();
			services.AddScoped<ILeaveAllocationRepository,LeaveAllocationRepository>();
			return services;
		}
	}
}