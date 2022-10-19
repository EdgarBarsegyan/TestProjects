using Microsoft.AspNetCore.Mvc;
using TestCrudService.Api.Common.Interfaces;
using TestCrudService.Api.Dal.Entity;

namespace TestCrudService.Api.Controllers;

[ApiController]
[Route("[controller]")]
public class WeatherForecastController : ControllerBase
{
    private static readonly string[] Summaries = new[]
    {
        "Freezing", "Bracing", "Chilly", "Cool", "Mild", "Warm", "Balmy", "Hot", "Sweltering", "Scorching"
    };

    private readonly ITestRepository _testRepository;

    private readonly ILogger<WeatherForecastController> _logger;

    public WeatherForecastController(ILogger<WeatherForecastController> logger, ITestRepository testRepository)
    {
        _logger = logger;
        _testRepository = testRepository;
    }

    [HttpGet(Name = "GetWeatherForecast")]
    public IEnumerable<WeatherForecast> Get()
    {
        return Enumerable.Range(1, 5).Select(index => new WeatherForecast
            {
                Date = DateTime.Now.AddDays(index),
                TemperatureC = Random.Shared.Next(-20, 55),
                Summary = Summaries[Random.Shared.Next(Summaries.Length)]
            })
            .ToArray();
    }

    [HttpGet("SetUser")]
    public async Task GetUser()
    {
        List<DocUser> list = new List<DocUser>(100000);
        for (int i = 0; i < 100000; i++)
        {
            list.Add(new DocUser
            {
                Id = 0,
                Name = "Test",
                Age = 1
            }); 
        }

        await _testRepository.SaveListObj(list);
    } 
    
    [HttpGet("GetUser")]
    public async Task<IEnumerable<DocUser>> GetUsers()
    {
        return await _testRepository.GetUserList();
    } 
}