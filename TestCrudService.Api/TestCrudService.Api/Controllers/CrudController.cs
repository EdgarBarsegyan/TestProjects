using Microsoft.AspNetCore.Mvc;
using TestCrudService.Common.DTO;
using TestCrudService.Common.Interfaces;
using TestCrudService.DAL.Entity;

namespace TestCrudService.Api.Controllers;

[ApiController]
[Route("api/[controller]")]
public class CrudController : ControllerBase
{
    private readonly ICrudService _crudService;

    public CrudController(ICrudService crudService)
    {
        _crudService = crudService;
    }

    /// <summary>
    /// Получение людей с обазованием или без
    /// </summary>
    /// <param name="educationId">0 - выдаст без обарзования,
    /// > 0 выдасть по группу людей по образованию</param>
    /// <returns></returns>
    [HttpGet("GetDocPersonDto")]
    public async Task<List<DocPersonDto>> GetDocPersonDto(int educationId)
    {
        return await _crudService.GetPersonList(educationId);
    }

    /// <summary>
    /// Получить справочник по образованиям
    /// </summary>
    /// <returns></returns>
    [HttpGet("GetEducations")]
    public async Task<List<RefEducationDto>> GetEducations()
    {
        return await _crudService.GetEducationList();
    }
    
    /// <summary>
    /// Добавляет людей со случайным образованием
    /// </summary>
    /// <param name="countPerson">количество людей</param>
    /// <param name="countEducations">количество образований</param>
    [HttpGet("SaveRandomPersonsWith2Educations")]
    public async Task SaveRandomPersonsWithEducations(int countPerson, int countEducations)
    {
        var educations = await _crudService.GetEducationList();
        var list = new List<DocPersonDto>(countPerson);
        var listEducations = new List<DocEducationLineDto>(countEducations);
        var random = new Random();

        for (int i = 0; i < countEducations; i++)
        {
            listEducations.Add(new DocEducationLineDto
            {
                Id = 0,
                PersonId = 0,
                EducationId = educations[random.Next(0, educations.Count)].Id,
            });
        }
        

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
                        EducationId = educations[random.Next(0, educations.Count)].Id,
                    },
                    new DocEducationLineDto
                    {
                        Id = 0,
                        PersonId = 0,
                        EducationId = educations[random.Next(0, educations.Count)].Id,
                    },
                }
            });
        }

        await _crudService.SaveDocPersonDtoList(list);
    }
    
    /// <summary>
    /// добавление образоавний
    /// </summary>
    /// <param name="dto"></param>
    [HttpPost("SaveEducation")]
    public async Task SaveEducation([FromBody] RefEducationDto dto)
    {
        await _crudService.SaveRefEducationDto(dto);
    }
}