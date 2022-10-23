using TestCrudService.Common.DTO;

namespace TestCrudService.Common.Interfaces;

public interface ICrudService
{
    Task SaveDocPersonDto(DocPersonDto dto);
    Task SaveDocPersonDtoList(List<DocPersonDto> dtoList);
    Task SaveRefEducationDto(RefEducationDto dto);
    Task SaveRefEducationDtoList(List<RefEducationDto> dtoList);
    Task<List<DocPersonDto>> GetPersonList(int[] educationArray);
    Task<List<RefEducationDto>> GetEducationList();
}