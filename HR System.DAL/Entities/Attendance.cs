using System.ComponentModel.DataAnnotations.Schema;

namespace HR_System.DAL.Entities
{
    public class Attendance
    {
        public int Id { get; set; }

        // Relation 
        [ForeignKey(nameof(EmployeeId))]
        public int EmployeeId { get; set; }
        public Employee Employee { get; set; }
        public DateTimeOffset CheckIn { get; set; }
        public DateTimeOffset ?CheckOut { get; set; }
        public DateTime Date { get; set; }

    }
}
