namespace HR_System.BLL.DTOs.AttendanceDTOs
{
    public class AttendanceReadDto
    {
        public int Id { get; set; }
        public int EmployeeId { get; set; }
        public DateTimeOffset CheckIn { get; set; }
        public DateTimeOffset? CheckOut { get; set; }
        public DateTime Date { get; set; }

    }
}
