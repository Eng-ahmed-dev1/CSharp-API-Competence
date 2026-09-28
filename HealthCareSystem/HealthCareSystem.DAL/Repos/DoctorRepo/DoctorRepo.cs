using HealthCareSystem.DAL.Data;
using HealthCareSystem.DAL.Models;

namespace HealthCareSystem.DAL
{
    public class DoctorRepo : IDoctorRepo
    {
        private readonly ApplicationContext _context;
        public DoctorRepo(ApplicationContext context)
        {
            _context = context;
        }
        public void Add(Doctor doctor)
        {
            _context.Doctors.Add(doctor);
        }

        public void Delete(Doctor doctor)
        {
            _context.Doctors.Remove(doctor);
        }

        public Doctor GetById(int id)
        {
            Doctor doctor = _context.Doctors.Find(id);
            //_context.Doctors.FirstOrDefault(d=>d.Id == id);
            //_context.Doctors.Where(d => d.Id == id).FirstOrDefault();
            return doctor;
        }

        public IEnumerable<Doctor> GetDoctors()
        {
            List<Doctor> doctors = _context.Doctors.ToList();
            return doctors;
        }

        public int SaveChanges()
        {
            return _context.SaveChanges();
        }

        public void Update(Doctor doctor)
        {
            _context.Doctors.Update(doctor);
        }
    }
}
