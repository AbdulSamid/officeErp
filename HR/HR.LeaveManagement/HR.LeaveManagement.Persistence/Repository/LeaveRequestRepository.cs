using HR.LeaveManagement.Application.Contract.Persistence;
using HR.LeaveManagement.Domain;
using HR.LeaveManagement.Persistence.DatabaseContext;
using Microsoft.EntityFrameworkCore;

namespace HR.LeaveManagement.Persistence.Repository
{
	public class LeaveRequestRepository : GenericRepository<LeaveRequest>, ILeaveRequestRepository
	{
		public LeaveRequestRepository(HRDatabaseContext context) : base(context)
		{
		}

		public async Task<List<LeaveRequest>> GetLeaveRequestsWithDetailsAsync()
		{
			var leaveRequest = await _context.LeaveRequests.Include(q => q.LeaveType).ToListAsync();
			return leaveRequest;
		}

		public async Task<List<LeaveRequest>> GetLeaveRequestsWithDetailsAsync(string userId)
		{
			var leaveRequest=await _context.LeaveRequests.Where(q=>q.RequestingEmployeeId==userId)
															.Include(q=>q.LeaveType).ToListAsync();
			return leaveRequest;
		}

		public async Task<LeaveRequest> GetLeaveRequestWithDetailsAsync(int id)
		{
			var leaveRequest= await _context.LeaveRequests.Include(q => q.LeaveType).FirstOrDefaultAsync(q=>q.Id==id);
			return leaveRequest;
		}
	}
}
