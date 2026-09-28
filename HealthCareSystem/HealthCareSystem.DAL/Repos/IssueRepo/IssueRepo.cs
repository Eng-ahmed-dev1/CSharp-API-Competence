using HealthCareSystem.DAL.Data;
using HealthCareSystem.DAL.Models;
using HealthCareSystem.DAL.Repos.IssueRepo;

namespace HealthCareSystem.DAL
{
    public class IssueRepo : IIssueRepo
    {
        private readonly ApplicationContext _context;
        public IssueRepo(ApplicationContext context)
        {
            _context = context;
        }
        public void Add(Issue Issue)
        {
            _context.Issues.Add(Issue);
        }

        public void Delete(Issue Issue)
        {
            _context.Issues.Remove(Issue);
        }

        public Issue GetById(int id)
        {
            Issue Issue = _context.Issues.Find(id);
            return Issue;
        }

        public IEnumerable<Issue> GetIssues()
        {
            List<Issue> Issues = _context.Issues.ToList();
            return Issues;
        }

        public int SaveChanges()
        {
            return _context.SaveChanges();
        }

        public void Update(Issue Issue)
        {
            _context.Issues.Update(Issue);
        }
    }
}