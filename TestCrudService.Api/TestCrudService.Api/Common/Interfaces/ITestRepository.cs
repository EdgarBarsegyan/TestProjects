using TestCrudService.Api.Dal.Entity;

namespace TestCrudService.Api.Common.Interfaces;

public interface ITestRepository
{
    Task<List<DocUser>> GetUserList();
    Task SaveListObj(List<DocUser> users);
}