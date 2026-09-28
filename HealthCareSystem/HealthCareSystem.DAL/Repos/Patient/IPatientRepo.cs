using HealthCareSystem.DAL.Models;

namespace HealthCareSystem.DAL
{
    public interface IPatientRepo
    {
        IEnumerable<Patient> GetPatients();
        Patient GetById(int id);
        void Add(Patient Patient);
        void Update(Patient Patient);
        void Delete(Patient Patient);
        int SaveChanges();
    }
}