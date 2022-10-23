using System.Text.Json.Serialization;
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

    public async Task SaveRefEducationDto(RefEducationDto dto)
    {
        var entity = _refMapper.MapDtoToEntity(dto);
        var education = await DoQueryAsync(async (ctx, token) =>
        {
            return ctx.Educations.Local.Any(x => x.Name == entity.Name);
        });
        if (!education)
            await DoSaveAsync((ctx, token) =>
            {
                ctx.AddAsync(entity, token);
            });
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

    public async Task<List<DocPersonDto>> GetDocPersonDtoList(int educationId)
    {
        var list = await DoQueryAsync(async (ctx, token) =>
        {
            var query3 = ctx.PersonSet
                .Include(i => i.DocEducationLine)!
                .ThenInclude(e => e.Education)
                .AsQueryable();
            if (educationId != 0)
            {
                query3 = query3
                    .Where(x => x.DocEducationLine!.All(y => y.EducationId == educationId))
                    .Where(c => c.DocEducationLine.Count > 0);
            }
            else
            {
                query3 = query3.Where(x => !x.DocEducationLine!.Any());
            }


            return await query3.ToListAsync(token);
        });
        return _docMapper.MapEntityToDtoList(list);
    }
}