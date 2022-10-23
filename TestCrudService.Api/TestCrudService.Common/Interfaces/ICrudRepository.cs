using TestCrudService.Common.DTO;

namespace TestCrudService.Common.Interfaces;

public interface ICrudRepository
{
    Task SaveDocPersonDto(DocPersonDto dto);
    Task SaveDocPersonDtoList(List<DocPersonDto> listDto);
    Task SaveRefEducationDto(RefEducationDto dto);
    Task SaveRefEducationDtoList(List<RefEducationDto> listDto);
    Task<RefEducationDto> GetRefEducation(int educationId);
    Task<List<RefEducationDto>> GetRefEducationList();
    Task<DocPersonDto> GetDocPersonDto(int personId);
    Task<List<DocPersonDto>> GetDocPersonDtoList(int[] educationArray);
    Task<List<DocPersonDto>> GetDocPersonDtoWithoutEducation();
}