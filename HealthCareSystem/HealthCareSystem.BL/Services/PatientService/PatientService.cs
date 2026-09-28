using HealthCareSystem.BL.DTOs;
using HealthCareSystem.DAL;
using HealthCareSystem.DAL.Models;

namespace HealthCareSystem.BL;

public class PatientService : IPatientService
{
    public readonly IPatientRepo _Repo;
    public PatientService(IPatientRepo repo)
    {
        _Repo = repo;
    }

    public int Add(PatientWriteDTO patientDto)
    {
        Patient patientToAdd = new Patient()
        {
            Name = patientDto.Name,
            DoctorId = patientDto.DoctorId
        };
        _Repo.Add(patientToAdd);
        _Repo.SaveChanges();
        return patientToAdd.Id;
    }

    public bool Delete(int id)
    {
        var patientToDelete = _Repo.GetById(id);
        if (patientToDelete == null)
        {
            return false;
        }
        _Repo.Delete(patientToDelete);
        _Repo.SaveChanges();
        return true;
    }

    public PatientReadDTO GetById(int id)
    {
        var patient = _Repo.GetById(id);
        if (patient == null)
        {
            return null;
        }
        var patientDTO = new PatientReadDTO()
        {
            Id = patient.Id,
            Name = patient.Name,
            DoctorId = patient.DoctorId
        };
        return patientDTO;
    }

    public IEnumerable<PatientReadDTO> GetPatients()
    {
        var patients = _Repo.GetPatients();
        var patientsDTO = patients.Select(p => new PatientReadDTO()
        {
            Id = p.Id,
            Name = p.Name,
            DoctorId = p.DoctorId
        }).ToList();
        return patientsDTO;
    }

    public bool Update(PatientUpdateDTO patient)
    {
        var patientToUpdate = _Repo.GetById(patient.Id);
        if (patientToUpdate == null)
        {
            return false;
        }
        patientToUpdate.Name = patient.Name;
        patientToUpdate.DoctorId = patient.DoctorId;
        _Repo.Update(patientToUpdate);
        _Repo.SaveChanges();
        return true;
    }
}