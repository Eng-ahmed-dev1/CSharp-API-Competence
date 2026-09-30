using System.ComponentModel.DataAnnotations;

namespace HR_System.BLL.DTOs.CheckOutDTOs
{
    public class CheckOutDto
    {
        public int Id { get; set; }
        [Required] public int EmployeeId { get; set; }
        public DateTimeOffset? CheckOut { get; set; }
    }
}
