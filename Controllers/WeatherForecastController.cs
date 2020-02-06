using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using CrudUser.Models;
using Microsoft.EntityFrameworkCore;

namespace CrudUser.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class WeatherForecastController : ControllerBase
    {
        private readonly ConnDB _context;
        public WeatherForecastController(ConnDB context) =>  _context=context;
                   

        
        [HttpGet("all")]
        //weatherforecasr/all
        public ActionResult<IEnumerable<User>> GetUsers()
        {
            return _context.UserItem;

        }
        [HttpGet("{id}")]
        public ActionResult<User> GetUserById(int id)
        {
            var userItem=_context.UserItem.Find(id);
            if (userItem==null)
            {
               return NotFound(); 
            }
            return userItem;

        }
        [HttpPost("create")]
        public ActionResult<User> CreateUser(User user)
        {
            _context.UserItem.Add(user);
            _context.SaveChanges();
            return CreatedAtAction("GetUserById", new User{Id=user.Id},user );
        }

        [HttpPut("{id}")]
        public ActionResult PutUser(int id, User user)
        {
            _context.Entry(user).State=EntityState.Modified;
            _context.SaveChanges();
            
            return NoContent();
        }
        [HttpDelete("{id}")]
        public ActionResult<User> DeteleteUser(int id)
        {
            var userItem=_context.UserItem.Find(id);
             if (userItem==null)
            {
               return NotFound(); 
            }
            _context.UserItem.Remove(userItem);
            _context.SaveChanges();
            return userItem;



        }


        // private static readonly string[] Summaries = new[]
        // {
        //     "Freezing", "Bracing", "Chilly", "Cool", "Mild", "Warm", "Balmy", "Hot", "Sweltering", "Scorching"
        // };

        // private readonly ILogger<WeatherForecastController> _logger;

        // public WeatherForecastController(ILogger<WeatherForecastController> logger)
        // {
        //     _logger = logger;
        // }

        // [HttpGet]
        // public IEnumerable<WeatherForecast> Get()
        // {
        //     var rng = new Random();
        //     return Enumerable.Range(1, 5).Select(index => new WeatherForecast
        //     {
        //         Date = DateTime.Now.AddDays(index),
        //         TemperatureC = rng.Next(-20, 55),
        //         Summary = Summaries[rng.Next(Summaries.Length)]
        //     })
        //     .ToArray();
        // }

    

    }
}
