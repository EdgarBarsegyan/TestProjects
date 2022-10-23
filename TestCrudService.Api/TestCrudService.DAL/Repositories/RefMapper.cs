using System.Collections;
using System.ComponentModel.DataAnnotations;
using TestCrudService.Common.DTO;
using TestCrudService.DAL.Entity;

namespace TestCrudService.DAL.Repositories;

internal class RefMapper
{
    private readonly DtoChecker _dtoChecker;

    public RefMapper()
    {
        _dtoChecker = new DtoChecker();
    }

    internal RefEducationDto MapEntityToDto(RefEducation entity)
    {
        var dto = new RefEducationDto
        {
            Id = entity.Id,
            Name = entity.Name,
        };
        return dto;
    }

    internal List<RefEducationDto> MapEntityToDtoList(List<RefEducation> entityList)
    {
        var list = new List<RefEducationDto>();
        foreach (var i in entityList)
        {
            list.Add(MapEntityToDto(i));
        }

        return list;
    }

    internal RefEducation MapDtoToEntity(RefEducationDto dto)
    {
        if (!_dtoChecker.CheckDto(dto))
            throw new ValidationException(nameof(dto));
        var entity = new RefEducation
        {
            Id = dto.Id,
            Name = dto.Name,
        };

        return entity;
    }

    internal List<RefEducation> MapDtoToEntityList(List<RefEducationDto> dtoList)
    {
        var list = new List<RefEducation>();
        foreach (var i in dtoList)
        {
            list.Add(MapDtoToEntity(i));
        }

        return list;
    }
}