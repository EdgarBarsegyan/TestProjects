using System.Reflection.Metadata.Ecma335;
using TestCrudService.Common.DTO;
using TestCrudService.Common.Interfaces;

namespace TestCrudService.Services;

public class CrudService : ICrudService
{
    private readonly ICrudRepository _crudRepository;

    public CrudService(ICrudRepository crudRepository)
    {
        _crudRepository = crudRepository;
    }

    public Task SaveDocPersonDto(DocPersonDto dto)
    {
        throw new NotImplementedException();
    }

    public async Task SaveDocPersonDtoList(List<DocPersonDto> dtoList)
    {
        await _crudRepository.SaveDocPersonDtoList(dtoList);
    }

    public Task SaveRefEducationDto(RefEducationDto dto)
    {
        throw new NotImplementedException();
    }

    public async Task SaveRefEducationDtoList(List<RefEducationDto> dtoList)
    {
        await _crudRepository.SaveRefEducationDtoList(dtoList);
    }

    public async Task<List<DocPersonDto>> GetPersonList(int[] educationArray)
    {
        return await _crudRepository.GetDocPersonDtoList(educationArray);
        // return await _crudRepository.GetDocPersonDtoWithoutEducation();
    }

    public async Task<List<RefEducationDto>> GetEducationList()
    {
        return await _crudRepository.GetRefEducationList();
    }
}