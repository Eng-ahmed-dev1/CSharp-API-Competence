using HR_System.DAL.Entities;

namespace HR_System.DAL
{
    public interface    IAttendanceRepository
    {
        Task<IEnumerable<Attendance>> GetAllAsync();
        Task<Attendance?> GetByIdAsync(int Id);
        void Add(Attendance attendance);
        void Update(Attendance attendance);
        void Delete(Attendance attendance);
        Task<int> SaveChangesAsync();
        Task<List<Attendance>> GetCompletedByEmployeeAsync(int employeeId);


    }
}
