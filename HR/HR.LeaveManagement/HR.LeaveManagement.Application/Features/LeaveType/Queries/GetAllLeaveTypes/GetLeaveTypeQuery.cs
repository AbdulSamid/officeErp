using HR.LeaveManagement.Application.Features.LeaveType.Queries.GetAllLeaveTypes;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HR.LeaveManagement.Application.Features.LeaveType.Queries.GetAllLeaveTypes
{
	public class GetLeaveTypeQuery : IRequest<List<LeaveTypeDto>>
	{
	}
	//since its a internal record and not going to change we can use record type
	//once you create an instance of a class, you can change its properties. However, once you create an instance of a record, you cannot change its properties.
	//Classes are mutable, while records are immutable:
	//Records have automatic properties
	//Records have value-based equality
	//Records are reference types, while classes are value types


}

