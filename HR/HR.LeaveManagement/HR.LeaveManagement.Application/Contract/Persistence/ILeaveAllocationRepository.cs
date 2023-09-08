using HR.LeaveManagement.Domain;

namespace HR.LeaveManagement.Application.Contract.Persistence
{
	public interface ILeaveAllocationRepository : IGenericRepository<LeaveAllocation>
	{
		Task<LeaveAllocation> GetLeaveAllocationWithDetailsAsync(int id);
		Task<List<LeaveAllocation>> GetLeaveAllocationsWithDetailsAsync();
		Task<List<LeaveAllocation>> GetLeaveAllocationsWithDetailsAsync(string userId);
		Task<bool> LeaveAllocationExist(string userId, int leaveTypeId,int period);
		Task AddAllocation(List<LeaveAllocation> allocation);
		Task<LeaveAllocation> GetUserAllocation(string userId, int leaveTypeId);
	}
}
