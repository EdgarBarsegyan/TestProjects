using System.ComponentModel.DataAnnotations;

namespace TestCrudService.Common.DTO;

public class RefEducationDto
{
    public int Id { get; set; }
    
    [Required]
    public string Name { get; set; }
}