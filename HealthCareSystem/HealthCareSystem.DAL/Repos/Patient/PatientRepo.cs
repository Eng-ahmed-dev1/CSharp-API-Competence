using HealthCareSystem.DAL.Data;
using HealthCareSystem.DAL.Models;

namespace HealthCareSystem.DAL
{
    public class PatientRepo : IPatientRepo
    {
        private readonly ApplicationContext _context;
        public PatientRepo(ApplicationContext context)
        {
            _context = context;
        }
        public void Add(Patient Patient)
        {
            _context.Patients.Add(Patient);
        }

        public void Delete(Patient Patient)
        {
            _context.Patients.Remove(Patient);
        }

        public Patient GetById(int id)
        {
            Patient Patient = _context.Patients.Find(id);
            return Patient;
        }

        public IEnumerable<Patient> GetPatients()
        {
            List<Patient> Patients = _context.Patients.ToList();
            return Patients;
        }

        public int SaveChanges()
        {
            return _context.SaveChanges();
        }

        public void Update(Patient Patient)
        {
            _context.Patients.Update(Patient);
        }
    }
}