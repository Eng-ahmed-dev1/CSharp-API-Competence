using HR_System.DAL.Entities;

namespace HR_System.DAL
{
    public interface IEmployeeRepository
    {
        Task<IEnumerable<Employee>> GetAllAsync();
        Task<Employee?> GetByIdAsync(int Id);
        void Add(Employee employee);
        void Update(Employee employee);
        void Delete(Employee employee);
        Task<int> SaveChangesAsync();
    }
}
