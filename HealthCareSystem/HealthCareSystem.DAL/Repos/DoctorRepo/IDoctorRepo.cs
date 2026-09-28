using HealthCareSystem.DAL.Models;

namespace HealthCareSystem.DAL
{
    public interface IDoctorRepo
    {
        IEnumerable<Doctor> GetDoctors();
        Doctor GetById(int id);
        void Add(Doctor doctor);
        void Update(Doctor doctor);
        void Delete(Doctor doctor);
        int SaveChanges();
    }
}
