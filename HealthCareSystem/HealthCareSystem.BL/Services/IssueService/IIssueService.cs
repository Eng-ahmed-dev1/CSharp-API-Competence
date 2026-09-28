using HealthCareSystem.BL.DTOs;

namespace HealthCareSystem.BL
{
    public interface IIssueService
    {
        IEnumerable<IssueReadDTO> GetIssues();
        IssueReadDTO GetById(int id);
        int Add(IssueWriteDTO issue);
        bool Update(IssueUpdateDTO issue);
        bool Delete(int id);
    }
}