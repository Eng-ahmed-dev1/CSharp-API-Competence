using System.ComponentModel.DataAnnotations;

namespace HR_System.DAL.Entities
{
    public class Employee
    {
        public int Id { get; set; }
        public string Name { get; set; } = string.Empty;
        [EmailAddress]
        public string Email { get; set; } = string.Empty;
        public string Department { get; set; } = string.Empty;
        public DateTime HireDate { get; set; }

        public ICollection<Attendance> Attendances { get; set; } 
            = new HashSet<Attendance>();
    }
}
