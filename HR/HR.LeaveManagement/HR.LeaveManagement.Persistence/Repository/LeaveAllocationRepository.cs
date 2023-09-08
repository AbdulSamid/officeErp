using Azure;
using HR.LeaveManagement.Application.Contract.Persistence;
using HR.LeaveManagement.Domain;
using HR.LeaveManagement.Persistence.DatabaseContext;
using Microsoft.EntityFrameworkCore;

namespace HR.LeaveManagement.Persistence.Repository
{
	public class LeaveAllocationRepository : GenericRepository<LeaveAllocation>, ILeaveAllocationRepository
	{
		public LeaveAllocationRepository(HRDatabaseContext context) : base(context)
		{
		}

		public async Task AddAllocation(List<LeaveAllocation> allocation)
		{
			await _context.LeaveAllocations.AddRangeAsync(allocation);
			await _context.SaveChangesAsync();
		}

		public async Task<List<LeaveAllocation>> GetLeaveAllocationsWithDetailsAsync()
		{
			var leaveAllocations=await _context.LeaveAllocations.Include(q=>q.LeaveTypeId).ToListAsync();
			return leaveAllocations;
		}

		public async Task<List<LeaveAllocation>> GetLeaveAllocationsWithDetailsAsync(string userId)
		{
			var leaveAllocations=await _context.LeaveAllocations.Where(q=>q.EmployeeId==userId)
																.Include(q=>q.LeaveTypeId)
																.ToListAsync();
			return leaveAllocations;
		}

		public async Task<LeaveAllocation> GetLeaveAllocationWithDetailsAsync(int id)
		{
			var leaveAllocation=await _context.LeaveAllocations.Include(q=>q.LeaveTypeId).FirstOrDefaultAsync(q=>q.Id==id);
			return leaveAllocation;
		}

		public async Task<LeaveAllocation> GetUserAllocation(string userId, int leaveTypeId)
		{
			var leaveAllocation = await _context.LeaveAllocations
												.FirstOrDefaultAsync(q=>q.EmployeeId==userId && q.LeaveTypeId == leaveTypeId);
			return leaveAllocation;
		}

		public async Task<bool> LeaveAllocationExist(string userId, int leaveTypeId, int period)
		{
			return await _context.LeaveAllocations
				.AnyAsync(q => q.EmployeeId == userId && q.LeaveTypeId == leaveTypeId && q.Period == period);
		}
	}
}
