using System.ComponentModel.DataAnnotations;
using TestCrudService.Common.DTO;
using TestCrudService.DAL.Entity;

namespace TestCrudService.DAL.Repositories;

internal class DocMapper
{
    private readonly DtoChecker _dtoChecker;
    private readonly RefMapper _refMapper;

    public DocMapper()
    {
        _dtoChecker = new DtoChecker();
        _refMapper = new RefMapper();
    }

    internal DocPersonDto MapEntityToDto(DocPerson entity)
    {
        var dto = new DocPersonDto()
        {
            Id = entity.Id,
            FirstName = entity.FirstName,
            LastName = entity.LastName,
            Age = entity.Age,
        };
        if (entity.DocEducationLine is not null)
        {
            dto.EducationLines = MapEntityToDtoList(entity.DocEducationLine);
        }

        return dto;
    }
    
    internal List<DocPersonDto> MapEntityToDtoList(List<DocPerson> entityList)
    {
        var list = new List<DocPersonDto>();
        foreach (var i in entityList)
        {
            list.Add(MapEntityToDto(i));
        }

        return list;
    }
    
    internal DocPerson MapDtoToEntity(DocPersonDto dto)
    {
        if(!_dtoChecker.CheckDto(dto))
            throw new ValidationException(nameof(dto));
        var entity = new DocPerson
        {
            Id = dto.Id,
            FirstName = dto.FirstName,
            LastName = dto.LastName,
            Age = dto.Age,
        };

        if (dto.EducationLines.Count > 0)
        {
            entity.DocEducationLine = MapDtoToEntityList((List<DocEducationLineDto>)dto.EducationLines);
        }

        return entity;
    }
    
    internal List<DocPerson> MapDtoToEntityList(List<DocPersonDto> dtoList)
    {
        if (!_dtoChecker.CheckDtoList(dtoList))
            throw new ValidationException(nameof(dtoList));
        var list = new List<DocPerson>();
        foreach (var i in dtoList)
        {
            list.Add(MapDtoToEntity(i));
        }

        return list;
    }


    internal DocEducationLineDto MapEntityToDto(DocEducationLine entity)
    {
        var dto = new DocEducationLineDto
        {
            Id = entity.Id,
            PersonId = entity.PersonId,
            EducationId = entity.EducationId,
        };
        if (entity.Education is not null)
        {
            dto.Education = _refMapper.MapEntityToDto(entity.Education);
        }

        return dto;
    }

    internal List<DocEducationLineDto> MapEntityToDtoList(List<DocEducationLine> entityList)
    {
        var list = new List<DocEducationLineDto>();
        foreach (var i in entityList)
        {
            list.Add(MapEntityToDto(i));
        }

        return list;
    }
    
    internal DocEducationLine MapDtoToEntity(DocEducationLineDto dto)
    {
        if (!_dtoChecker.CheckDto(dto))
            throw new ValidationException(nameof(dto));
        var entity = new DocEducationLine
        {
            Id = dto.Id,
            PersonId = dto.PersonId,
            EducationId = dto.EducationId,
        };
        return entity;
    }

    internal List<DocEducationLine> MapDtoToEntityList(List<DocEducationLineDto> dtoList)
    {
        if (!_dtoChecker.CheckDtoList(dtoList))
            throw new ValidationException();
        var list = new List<DocEducationLine>();
        foreach (var i in dtoList)
        {
            list.Add(MapDtoToEntity(i));
        }

        return list;
    }
}