namespace TestCrudService.DAL.Entity;

public class RefEducation
{
    public int Id { get; set; }
    public string Name { get; set; }
    public DocEducationLine? EducationLine { get; set; }
}