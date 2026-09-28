using HealthCareSystem.BL.DTOs;

namespace HealthCareSystem.BL
{
    public interface IDoctorService
    {
        IEnumerable<DoctorReadDTO> GetDoctors();
        DoctorReadDTO GetById(int id);
        int Add(DoctorWriteDTO doctor);
        bool Update(DoctorUpdateDTO doctor);
        bool Delete(int id);

    }
}
