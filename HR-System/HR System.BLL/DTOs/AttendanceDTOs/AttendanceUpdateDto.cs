using HR_System.DAL.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HR_System.BLL.DTOs.AttendanceDTOs
{
    public class AttendanceUpdateDto
    {

        public int Id { get; set; }
        public DateTimeOffset CheckIn { get; set; }
        public DateTimeOffset CheckOut { get; set; } = DateTimeOffset.Now;
    }
}
