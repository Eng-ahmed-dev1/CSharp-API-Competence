using HR_System.BLL.DTOs.AttendanceDTOs;
using HR_System.BLL.DTOs.CheckInDTOs;
using HR_System.BLL.DTOs.CheckOutDTOs;

namespace HR_System.BLL.Services.IAttendanceServices
{
    public interface IAttendanceService
    {
        Task<IEnumerable<AttendanceReadDto>> GetAllAsync();
        Task<AttendanceReadDto?> GetByIdAsync(int id);
        Task<int> AddAsync(AttendanceWriteDto dto);
        Task<bool> UpdateAsync(int id, AttendanceUpdateDto dto);
        Task<bool> DeleteAsync(int id);
        Task<CheckInDto> MakeCheckIn(CheckInDto checkin);
        Task<CheckOutDto> MakeCheckOut(CheckOutDto chechout);
    }
}
