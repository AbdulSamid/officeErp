﻿using HR.LeaveManagement.Application.Contract.Persistence;
using HR.LeaveManagement.Domain;
using HR.LeaveManagement.Persistence.DatabaseContext;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HR.LeaveManagement.Persistence.Repository
{
	public class LeaveTypeRepository : GenericRepository<LeaveType>, ILeaveTypeRepository
	{
		public LeaveTypeRepository(HRDatabaseContext context) : base(context)
		{
		}

		public async Task<bool> IsLeaveTypeUnique(string name)
		{
			return await _context.LeaveTypes.AnyAsync(q=>q.Name== name);
		}
	}
}
