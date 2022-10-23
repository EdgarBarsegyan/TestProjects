namespace TestCrudService.DAL.Entity;

public class DocPerson
{
    public long Id { get; set; }
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public byte Age { get; set; }
    public List<DocEducationLine>? DocEducationLine { get; set; }
}