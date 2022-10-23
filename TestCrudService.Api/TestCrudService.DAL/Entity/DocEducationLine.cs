namespace TestCrudService.DAL.Entity;

public class DocEducationLine
{
    public long Id { get; set; }
    public long PersonId { get; set; }
    public int EducationId { get; set; }
    
    public DocPerson? Person { get; set; }
    public RefEducation? Education { get; set; }
}