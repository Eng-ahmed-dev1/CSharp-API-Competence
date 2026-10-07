using HR_System.BLL.DTOs.AttendanceDTOs;
using HR_System.BLL.DTOs.CheckInDTOs;
using HR_System.BLL.DTOs.CheckOutDTOs;
using HR_System.DAL;
using HR_System.DAL.Entities;

namespace HR_System.BLL.Services.IAttendanceServices
{
    public class AttendanceService : IAttendanceService
    {
        private readonly IAttendanceRepository _repo;
        private readonly IEmployeeRepository _employeeRepository;

        public AttendanceService(IAttendanceRepository repo, IEmployeeRepository repoemp)
        {
            _repo = repo;
            _employeeRepository = repoemp;
        }

        public async Task<int> AddAsync(AttendanceWriteDto dto)
        {
            if (dto is null)
            {
                return 0;
            }
            var Attendance = new Attendance()
            {
                CheckIn = dto.CheckIn,
                CheckOut = dto.CheckOut,
                EmployeeId = dto.EmployeeId,
                Date = dto.Date
            };

            _repo.Add(Attendance);
            await _repo.SaveChangesAsync();
            return Attendance.Id;
        }

        public async Task<bool> DeleteAsync(int id)
        {
            var Attendance = await _repo.GetByIdAsync(id);
            if (Attendance is null)
                return false;

            _repo.Delete(Attendance);
            await _repo.SaveChangesAsync();
            return true;

        }

        public async Task<IEnumerable<AttendanceReadDto>> GetAllAsync()
        {
            return (await _repo.GetAllAsync()).Select(x => new AttendanceReadDto()
            {
                Id = x.Id,
                CheckIn = x.CheckIn,
                CheckOut = x.CheckOut,
                EmployeeId = x.EmployeeId,
                Date = x.Date
            });

        }

        public async Task<AttendanceReadDto?> GetByIdAsync(int id)
        {
            var attendance = await _repo.GetByIdAsync(id);

            if (attendance is null)
                return null;
            return new AttendanceReadDto
            {
                CheckIn = attendance.CheckIn,
                CheckOut = attendance.CheckOut,
                EmployeeId = attendance.EmployeeId,
                Date = attendance.Date
            };


        }

        public async Task<CheckInDto> MakeCheckIn(CheckInDto dto)
        {
            if (dto.EmployeeId <= 0)
                return null!;

            var checkIn = dto.CheckIn ?? DateTimeOffset.Now;
            var date = checkIn.Date;

            var atts = (await _repo.GetAllAsync())
                .FirstOrDefault(x => x.EmployeeId == dto.EmployeeId && x.Date == date);

            if (atts is not null)
                return null!;

            var attendance = new Attendance
            {
                CheckIn = checkIn,
                Date = date,
                EmployeeId = dto.EmployeeId,
                CheckOut = null
            };

            _repo.Add(attendance);
            await _repo.SaveChangesAsync();

            return new CheckInDto
            {
                Id = dto.Id,
                CheckIn = attendance.CheckIn,
                EmployeeId = attendance.EmployeeId
            };
        }

        public async Task<CheckOutDto> MakeCheckOut(CheckOutDto dto)
        {
            if (dto.EmployeeId <= 0)
                return null!;

            var checkOut = dto.CheckOut ?? DateTimeOffset.Now;
            var date = checkOut.Date;

            var att = (await _repo.GetAllAsync())
                .FirstOrDefault(x => x.EmployeeId == dto.EmployeeId && x.Date == date);

            if (att is null)
                return null!;

            if (att.CheckOut is not null)
                return null!;

            if (checkOut <= att.CheckIn)
                return null!;

            att.CheckOut = checkOut;
            _repo.Update(att);
            await _repo.SaveChangesAsync();

            return new CheckOutDto
            {
                Id = dto.Id,
                EmployeeId = att.EmployeeId,
                CheckOut = att.CheckOut
            };
        }

        public async Task<bool> UpdateAsync(int id, AttendanceUpdateDto dto)
        {
            var attendance = await _repo.GetByIdAsync(id);
            if (attendance is null)
                return false;

            attendance.CheckIn = dto.CheckIn;
            attendance.CheckOut = dto.CheckOut;

            _repo.Update(attendance);
            await _repo.SaveChangesAsync();
            return true;
        }
    }
}
