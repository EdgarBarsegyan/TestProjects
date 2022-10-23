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

    public async Task SaveRefEducationDto(RefEducationDto dto)
    {
        await _crudRepository.SaveRefEducationDto(dto);
    }

    public async Task SaveRefEducationDtoList(List<RefEducationDto> dtoList)
    {
        await _crudRepository.SaveRefEducationDtoList(dtoList);
    }

    public async Task<List<DocPersonDto>> GetPersonList(int educationId)
    {
        return await _crudRepository.GetDocPersonDtoList(educationId);
    }

    public async Task<List<RefEducationDto>> GetEducationList()
    {
        return await _crudRepository.GetRefEducationList();
    }
}