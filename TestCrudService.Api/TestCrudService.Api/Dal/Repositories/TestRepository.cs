using Microsoft.EntityFrameworkCore;
using TestCrudService.Api.Common.Interfaces;
using TestCrudService.Api.Dal.Entity;
using TestCrudService.Api.Dal.EntityMap;
using TestCrudService.Api.Dal.Repositories.Base;

namespace TestCrudService.Api.Dal.Repositories;

internal sealed class TestRepository : BaseRepository<TestDbContext>, ITestRepository
{
    public TestRepository(TestDbContext context) : base(context)
    {
    }

    public async Task<List<DocUser>> GetUserList()
    {
        return await DoQueryAsync(async (ctx, token) => await ctx.UserSet.ToListAsync(cancellationToken: token));
    }

    public async Task SaveListObj(List<DocUser> users)
    {
        await DoSaveAsync((ctx, token) => ctx.AddRange(users));
    }
}