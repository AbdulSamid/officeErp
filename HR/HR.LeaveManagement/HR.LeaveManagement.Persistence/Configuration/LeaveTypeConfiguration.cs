using HR.LeaveManagement.Domain;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Emit;
using System.Text;
using System.Threading.Tasks;

namespace HR.LeaveManagement.Persistence.Configuration
{
	public class LeaveTypeConfiguration : IEntityTypeConfiguration<LeaveType>
	{
		public void Configure(EntityTypeBuilder<LeaveType> builder)
		{
			builder.HasData(
					new LeaveType
					{
						Id = 1,
						Name = "Vacation",
						DefaultDays = 10,
						CreatedDate = DateTime.Now,
						LastUpdatedDate = DateTime.Now
					}
				);
			//if required at database leel validation then can use this configuration class to apply all configuration 
			//related to this class at db level
			builder.Property(q => q.Name)
				.IsRequired()
				.HasMaxLength(100);
		}
	}
}
