using System.Diagnostics.CodeAnalysis;

namespace TestCrudService.Common.DTO;

public class DocPersonDto
{
    public long Id { get; set; }
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public byte Age { get; set; }
    public ICollection<DocEducationLineDto> EducationLines { get; set; } = new List<DocEducationLineDto>();
}