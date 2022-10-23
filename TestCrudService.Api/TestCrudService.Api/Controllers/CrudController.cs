using Microsoft.AspNetCore.Mvc;
using TestCrudService.Common.DTO;
using TestCrudService.Common.Interfaces;

namespace TestCrudService.Api.Controllers;

[ApiController]
[Route("[controller]")]
public class CrudController : ControllerBase
{
    private readonly ICrudService _crudService;

    public CrudController(ICrudService crudService)
    {
        _crudService = crudService;
    }

    [HttpGet("GetDocPersonDto")]
    public async Task<List<DocPersonDto>> GetDocPersonDto([FromQuery] int[] educationId)
    {
        var e = await _crudService.GetPersonList(educationId);
        return e;
    }

    [HttpGet("GetEducations")]
    public async Task<List<RefEducationDto>> GetEducations()
    {
        return await _crudService.GetEducationList();
    }
    
    [HttpGet("save")]
    public async Task Save()
    {
        var list = new List<DocPersonDto>(100000);
        var random = new Random();

        for (int i = 0; i < list.Capacity; i++)
        {
            list.Add(new DocPersonDto
            {
                Id = 0,
                FirstName = "Boo",
                LastName = "Booooo",
                Age = 33,
                EducationLines = new List<DocEducationLineDto>()
                {
                    new DocEducationLineDto
                    {
                        Id = 0,
                        PersonId = 0,
                        EducationId = random.Next(3,17),
                    },
                    new DocEducationLineDto
                    {
                        Id = 0,
                        PersonId = 0,
                        EducationId = random.Next(3,17),
                    },
                    new DocEducationLineDto
                    {
                        Id = 0,
                        PersonId = 0,
                        EducationId = random.Next(3,17),
                    },
                }
            });
        }

        await _crudService.SaveDocPersonDtoList(list);
    }
}