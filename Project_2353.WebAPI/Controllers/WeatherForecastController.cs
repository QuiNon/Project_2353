using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Project_2353.Business.Structure.Abstract;
using Project_2353.DTO.EntityDTOS;
using Project_2353.Entity.Entities;

namespace Project_2353.WebAPI.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class WeatherForecastController : ControllerBase
    {
        private static readonly string[] Summaries = new[]
        {
            "Freezing", "Bracing", "Chilly", "Cool", "Mild", "Warm", "Balmy", "Hot", "Sweltering", "Scorching"
        };

        private readonly ILogger<WeatherForecastController> _logger;
        private readonly IBusinessService business;

        public WeatherForecastController(ILogger<WeatherForecastController> logger, IBusinessService business)
        {
            _logger = logger;
            this.business = business;
        }

        [HttpGet]
        public IEnumerable<WeatherForecast> Get()
        {
            var rng = new Random();
            var result=business.User.RegisterUser(new UserDTO(new UserEntity()
            {
                Email = "asdsa@asdasd.com",
                Firstname = "aa bb",
                LastName = "asltname",
                UserName = "useerr"
            }));
            return Enumerable.Range(1, 5).Select(index => new WeatherForecast
                {
                    Date = DateTime.Now.AddDays(index),
                    TemperatureC = rng.Next(-20, 55),
                    Summary = Summaries[rng.Next(Summaries.Length)]
                })
                .ToArray();
        }
    }
}