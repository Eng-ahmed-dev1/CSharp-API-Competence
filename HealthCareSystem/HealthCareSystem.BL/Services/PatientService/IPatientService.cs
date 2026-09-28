using HealthCareSystem.BL.DTOs;

namespace HealthCareSystem.BL
{
    public interface IPatientService
    {
        IEnumerable<PatientReadDTO> GetPatients();
        PatientReadDTO GetById(int id);
        int Add(PatientWriteDTO patient);
        bool Update(PatientUpdateDTO patient);
        bool Delete(int id);
    }
}