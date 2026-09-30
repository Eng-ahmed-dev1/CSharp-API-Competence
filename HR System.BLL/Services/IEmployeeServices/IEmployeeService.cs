using HR_System.BLL.DTOs.EmployeeDTOs;
using Microsoft.EntityFrameworkCore.SqlServer.Query.Internal;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HR_System.BLL
{
    public interface IEmployeeService
    {
        Task<IEnumerable<EmployeeReadDto>> GetAllAsync();
        Task<EmployeeReadDto?> GetByIdAsync(int id);
        Task<int> AddAsync(EmployeeWriteDto dto);
        Task<bool> UpdateAsync(int id,EmployeeUpdateDto dto);
        Task<bool> DeleteAsync(int id);
    }
}
