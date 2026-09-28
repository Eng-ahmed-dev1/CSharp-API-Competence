using HealthCareSystem.DAL.Models;

namespace HealthCareSystem.DAL.Repos.IssueRepo
{
    public interface IIssueRepo
    {
        IEnumerable<Issue> GetIssues();
        Issue GetById(int id);
        void Add(Issue Issue);
        void Update(Issue Issue);
        void Delete(Issue Issue);
        int SaveChanges();
    }
}