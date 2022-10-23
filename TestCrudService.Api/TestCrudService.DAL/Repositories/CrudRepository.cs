using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Internal;
using TestCrudService.Common.DTO;
using TestCrudService.Common.Interfaces;
using TestCrudService.DAL.Entity;
using TestCrudService.DAL.Repositories.Base;
using Z.EntityFramework.Plus;

namespace TestCrudService.DAL.Repositories;

public class CrudRepository : BaseRepository<TestDbContext>, ICrudRepository
{
    private readonly DocMapper _docMapper;
    private readonly RefMapper _refMapper;
    
    public CrudRepository(TestDbContext context) : base(context)
    {
        _refMapper = new RefMapper();
        _docMapper = new DocMapper();
    }

    public Task SaveDocPersonDto(DocPersonDto dto)
    {
        throw new NotImplementedException();
    }

    public async Task SaveDocPersonDtoList(List<DocPersonDto> listDto)
    {
        var entityList = _docMapper.MapDtoToEntityList(listDto);
        await DoSaveAsync((ctx, token) =>
        {
            ctx.AddRange(entityList);
        });
        
    }

    public Task SaveRefEducationDto(RefEducationDto dto)
    {
        throw new NotImplementedException();
    }

    public async Task SaveRefEducationDtoList(List<RefEducationDto> listDto)
    {
        var entityList = _refMapper.MapDtoToEntityList(listDto);
        await DoSaveAsync((ctx, token) =>
        {
            ctx.AddRange(entityList);
        });
    }

    public Task<RefEducationDto> GetRefEducation(int educationId)
    {
        throw new NotImplementedException();
    }

    public async Task<List<RefEducationDto>> GetRefEducationList()
    {
        var list = await DoQueryAsync(async (ctx, token) => await ctx.Educations.ToListAsync(token));
        return _refMapper.MapEntityToDtoList(list);
    }

    public Task<DocPersonDto> GetDocPersonDto(int personId)
    {
        throw new NotImplementedException();
    }

    public async Task<List<DocPersonDto>> GetDocPersonDtoList(int[] educationArray)
    {
        var list = await DoQueryAsync(async (ctx, token) =>
        {
            var query2 = ctx.PersonSet
                .Include(i => i.DocEducationLine)!
                .ThenInclude(e => e.Education)
                .Where(s => s.DocEducationLine.Any(x => 
                    x.EducationId == educationArray[0] &&
                    x.EducationId == educationArray[1]
                    ));
            var query3 = ctx.PersonSet
                    .Where(x => x.DocEducationLine.Any(i => 
                        i.EducationId == educationArray[0] ||
                        i.EducationId == educationArray[1]))
                .Include(i => i.DocEducationLine)!
                .ThenInclude(e => e.Education)
                ;


            return await query3.ToListAsync(token);
        });
        return _docMapper.MapEntityToDtoList(list);
    }

    public async Task<List<DocPersonDto>> GetDocPersonDtoWithoutEducation()
    {
        //Этот запрос совершенно не нравиться, нужно будет подумать как сделать нормально (на sql ничего сложного)
        var list = await DoQueryAsync(async (ctx, token) =>
        {
            var query = ctx.PersonSet
                .Include(i => i.DocEducationLine)
                .Where(x => !x.DocEducationLine!.Any());
            return await query.ToListAsync(token);
        });
        return _docMapper.MapEntityToDtoList(list);
    }
}