using HealthCareSystem.BL.DTOs;
using HealthCareSystem.DAL.Models;
using HealthCareSystem.DAL.Repos.IssueRepo;

namespace HealthCareSystem.BL;

public class IssueService : IIssueService
{
    public readonly IIssueRepo _Repo;
    public IssueService(IIssueRepo repo)
    {
        _Repo = repo;
    }

    public int Add(IssueWriteDTO issueDto)
    {
        Issue issueToAdd = new Issue()
        {
            Name = issueDto.Name
        };
        _Repo.Add(issueToAdd);
        _Repo.SaveChanges();
        return issueToAdd.Id;
    }

    public bool Delete(int id)
    {
        var issueToDelete = _Repo.GetById(id);
        if (issueToDelete == null)
        {
            return false;
        }
        _Repo.Delete(issueToDelete);
        _Repo.SaveChanges();
        return true;
    }

    public IssueReadDTO GetById(int id)
    {
        var issue = _Repo.GetById(id);
        if (issue == null)
        {
            return null;
        }
        var issueDTO = new IssueReadDTO()
        {
            Id = issue.Id,
            Name = issue.Name
        };
        return issueDTO;
    }

    public IEnumerable<IssueReadDTO> GetIssues()
    {
        var issues = _Repo.GetIssues();
        var issuesDTO = issues.Select(i => new IssueReadDTO()
        {
            Id = i.Id,
            Name = i.Name
        }).ToList();
        return issuesDTO;
    }

    public bool Update(IssueUpdateDTO issue)
    {
        var issueToUpdate = _Repo.GetById(issue.Id);
        if (issueToUpdate == null)
        {
            return false;
        }
        issueToUpdate.Name = issue.Name;
        _Repo.Update(issueToUpdate);
        _Repo.SaveChanges();
        return true;
    }
}