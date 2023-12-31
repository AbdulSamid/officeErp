﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HR.LeaveManagement.Application.Features.LeaveType.Queries.GetLeaveTypeDetails
{
	public class LeaveTypeDetailsDto
	{
        public int Id { get; set; }
        public string Name { get; set; } = string.Empty;
		public int DefaultDays { get; set; }
		public DateTime? CreatedDate { get; set; }
		public string CreatedBy { get; set; } = string.Empty;
		public DateTime? LastUpdatedDate { get; set; }
		public string LastUpdatedBy { get; set; } = string.Empty;
	}
}
