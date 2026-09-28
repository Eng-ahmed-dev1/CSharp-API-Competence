using System.ComponentModel.DataAnnotations;

namespace HealthCareSystem.DAL.Models
{
    public class Issue
    {
        [Key]
        public int Id { get; set; }
        public string Name { get; set; }
        public ICollection<Patient> Patients { get; set; } = new HashSet<Patient>();
    }
}
