using HR_System.DAL.Data;
using HR_System.DAL.Entities;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;

namespace HR_System.DAL
{
    public class EmployeeRepository : IEmployeeRepository
    {
        private readonly DB _context;
        public EmployeeRepository(DB context)
        => _context = context;
        public async Task<IEnumerable<Employee>> GetAllAsync()
        => await _context.Employees.AsNoTracking().ToListAsync();
        public async Task<Employee?> GetByIdAsync(int Id)
        => await _context.Employees.FindAsync(Id);
        public void Add(Employee Employee)
        => _context.Employees.Add(Employee);
        public void Update(Employee Employee)
        => _context.Employees.Update(Employee);
        public void Delete(Employee Employee)
        => _context.Employees.Remove(Employee);
        public async Task<int> SaveChangesAsync()
        => await _context.SaveChangesAsync();
    }
}
