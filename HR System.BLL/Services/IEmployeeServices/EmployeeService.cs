using HR_System.BLL.DTOs.EmployeeDTOs;
using HR_System.DAL;
using HR_System.DAL.Entities;

namespace HR_System.BLL.Services.IEmployeeServices
{
    public class EmployeeService : IEmployeeService
    {
        private readonly IEmployeeRepository _repo;
        private readonly IAttendanceRepository attendanceRepository;

        public EmployeeService(IEmployeeRepository repo, IAttendanceRepository attendance)
        {
            _repo = repo;
            attendanceRepository = attendance;
        }

        public async Task<int> AddAsync(EmployeeWriteDto dto)
        {
            if (dto is null)
            {
                return 0;
            }
            var emp = new Employee
            {
                Department = dto.Department,
                Email = dto.Email,
                HireDate = dto.HireDate,
                Name = dto.Name,
            };
            _repo.Add(emp);
            await _repo.SaveChangesAsync();
            return emp.Id;

        }

        public async Task<bool> DeleteAsync(int id)
        {
            var emp = await _repo.GetByIdAsync(id);
            if (emp is null)
                return false;
            _repo.Delete(emp);
            await _repo.SaveChangesAsync();
            return true;
        }

        public async Task<IEnumerable<EmployeeReadDto>> GetAllAsync()
        {
            return (await _repo.GetAllAsync()).Select(x => new EmployeeReadDto()
            {
                Id = x.Id,
                Department = x.Department,
                Email = x.Email,
                Name = x.Name,
            });

        }

        public async Task<EmployeeReadDto?> GetByIdAsync(int id)
        {
            var emp = await _repo.GetByIdAsync(id);
            if (emp is null)
                return null;
            var records = await attendanceRepository.GetCompletedByEmployeeAsync(id);

            var totalHours = records.Sum(a => (a.CheckOut!.Value - a.CheckIn).TotalHours);
            return new EmployeeReadDto
            {
                Department = emp.Department,
                Email = emp.Email,
                Name = emp.Name,
                TotalWorkingHours = Math.Round(totalHours, 2),
                Id = emp.Id

            };
        }

        public async Task<bool> UpdateAsync(int id, EmployeeUpdateDto dto)
        {
            var emp = await _repo.GetByIdAsync(id);
            if (emp is null)
                return false;
            emp.Department = dto.Department;
            emp.Email = dto.Email;
            emp.Name = dto.Name;
            await _repo.SaveChangesAsync();
            return true;
        }
    }
}
