using System.Collections;
using TestCrudService.Common.DTO;
using TestCrudService.DAL.Entity;
using TestCrudService.DAL.Repositories.Base;

namespace TestCrudService.DAL.Repositories;

internal class DtoChecker : BaseChecker
{
    internal bool CheckDto(DocPersonDto dto)
    {
        CheckDtoNull(dto);
        CheckNull(dto.FirstName);
        CheckNull(dto.LastName);

        return true;
    }
    
    internal bool CheckDtoList(List<DocPersonDto> dtoList)
    {
        CheckDtoCollectionNullAndEmpty(dtoList);
        foreach (var i in dtoList)
        {
            if (!CheckDto(i)) return false;
        }

        return true;
    }
    
    internal bool CheckDto(RefEducationDto dto)
    {
        CheckDtoNull(dto);
        CheckNull(dto.Name);
        return true;
    }
    
    internal bool CheckDtoList(List<RefEducationDto> dtoList)
    {
        CheckDtoCollectionNullAndEmpty(dtoList);
        foreach (var i in dtoList)
        {
            if (!CheckDto(i)) return false;
        }

        return true;
    }
    
    internal bool CheckDto(DocEducationLineDto dto)
    {
        CheckDtoNull(dto);
        return true;
    }
    
    internal bool CheckDtoList(List<DocEducationLineDto> dtoList)
    {
        CheckDtoCollectionNullAndEmpty(dtoList);
        foreach (var i in dtoList)
        {
            if (!CheckDto(i)) return false;
        }

        return true;
    }
}