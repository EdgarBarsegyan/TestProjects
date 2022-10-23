namespace TestCrudService.Common.DTO;

public class DocEducationLineDto
{
    public long Id { get; set; }
    public long PersonId { get; set; }
    public int EducationId { get; set; }
    
    public DocPersonDto? Person { get; set; }
    public RefEducationDto? Education { get; set; }
}