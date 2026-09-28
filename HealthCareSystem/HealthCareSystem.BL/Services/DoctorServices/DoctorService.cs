using HealthCareSystem.BL.DTOs;
using HealthCareSystem.DAL;
using HealthCareSystem.DAL.Models;

namespace HealthCareSystem.BL;
public class DoctorService : IDoctorService
{
    public readonly IDoctorRepo _Repo;
    public DoctorService(IDoctorRepo repo)
    {
       _Repo = repo; 
    }
    public int Add(DoctorWriteDTO doctorDto)
    {
        Doctor doctorToAdd = new Doctor() 
        {
            Name = doctorDto.Name,
            Specialization = doctorDto.Specialization,
            Salary = doctorDto.Salary,
        };
        _Repo.Add(doctorToAdd);
        int IdbeforeSave = doctorToAdd.Id;
        _Repo.SaveChanges();
        return doctorToAdd.Id;
    }

    public bool Delete(int id)
    {
        var doctorToDelete=_Repo.GetById(id);
        if(doctorToDelete == null)
        {
            return false;
        }
        _Repo.Delete(doctorToDelete);
        _Repo.SaveChanges();
        return true;
    }

    public DoctorReadDTO GetById(int id)
    {
        var doctor = _Repo.GetById(id);
        if(doctor == null)
        {
            return null;
        }
        var doctorDTO= new DoctorReadDTO()
        {
            Id = doctor.Id,
            Name = doctor.Name,
            Specialization = doctor.Specialization,
            PerformanceRate = doctor.PerformanceRate,
        };
        return doctorDTO;
    }

    public IEnumerable<DoctorReadDTO> GetDoctors()
    {
       var doctors= _Repo.GetDoctors();
        var doctorsDTO = doctors.Select(d => new DoctorReadDTO()
        {
            Id = d.Id,
            Name = d.Name,
            Specialization = d.Specialization,
            PerformanceRate = d.PerformanceRate

        }).ToList();
        return doctorsDTO;
    }

    public bool Update(DoctorUpdateDTO doctor)
    {
        var doctorToUpdate = _Repo.GetById(doctor.Id);
        if (doctorToUpdate == null)
        {
            return false;
        }
        doctorToUpdate.Name = doctor.Name;
        doctorToUpdate.Salary = doctor.Salary;
        doctorToUpdate.Specialization = doctor.Specialization;  
        _Repo.Update(doctorToUpdate);
        _Repo.SaveChanges();
        return true;
    }
}

