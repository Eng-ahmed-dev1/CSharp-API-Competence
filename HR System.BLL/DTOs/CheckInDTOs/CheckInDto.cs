using System.ComponentModel.DataAnnotations;

namespace HR_System.BLL.DTOs.CheckInDTOs
{
    public class CheckInDto
    {
        public int Id { get; set; }
        [Required] public int EmployeeId { get; set; }
        public DateTimeOffset? CheckIn { get; set; }
    }
}
