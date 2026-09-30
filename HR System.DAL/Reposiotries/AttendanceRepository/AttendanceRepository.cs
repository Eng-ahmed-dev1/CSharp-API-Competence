using HR_System.DAL.Data;
using HR_System.DAL.Entities;
using Microsoft.EntityFrameworkCore;

namespace HR_System.DAL
{
    public class AttendanceRepository : IAttendanceRepository
    {
        private readonly DB _context;
        public AttendanceRepository(DB context)
        => _context = context;
        public async Task<IEnumerable<Attendance>> GetAllAsync()
        => await _context.Attendances.AsNoTracking().ToListAsync();
        public async Task<Attendance?> GetByIdAsync(int Id)
        =>await _context.Attendances.FindAsync(Id);
        public void Add(Attendance attendance)
        => _context.Attendances.Add(attendance);
        public void Update(Attendance attendance)
        =>  _context.Attendances.Update(attendance);
        public void Delete(Attendance attendance)
        => _context.Attendances.Remove(attendance);
        public async Task<int> SaveChangesAsync()
        => await _context.SaveChangesAsync();

        public async Task<List<Attendance>> GetCompletedByEmployeeAsync(int employeeId)
        {
            return await _context.Attendances
                  .AsNoTracking()
                  .Where(a => a.EmployeeId == employeeId && a.CheckOut != null)
                  .ToListAsync();
        }
    }
}
