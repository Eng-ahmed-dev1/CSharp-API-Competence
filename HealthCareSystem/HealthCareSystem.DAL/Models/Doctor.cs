using System.ComponentModel.DataAnnotations;

namespace HealthCareSystem.DAL.Models
{
    public class Doctor
    {
        [Key]
        public int Id { get; set; }
        public string Name { get; set; } 
        public int Salary { get; set; }
        public string Specialization { get; set; }
        public int PerformanceRate { get; set; }    
        public ICollection<Patient> Patients { get; set; }=new HashSet<Patient>();


    }
}
