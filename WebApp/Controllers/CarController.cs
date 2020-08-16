using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace WebApp.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CarController : ControllerBase
    {
        // GET: api/<CarController>
        [HttpGet]
        public IEnumerable<Car> Get()
        {
            return _cars;
        }

        // GET api/<CarController>/5
        [HttpGet("{id}")]
        public async Task<Car> GetAsync(int id)
        {
            return await Task.FromResult<Car>((_cars.Count > id) ? _cars[id] : null);
        }

        // PUT api/<CarController>/5
        [HttpPut("{id}")]
        public IActionResult Update(int id, [FromBody] string newColor)
        {
            if (_cars.Count > id)
            {
                _cars[id].Color = newColor;

                return Ok(_cars[id]);
            }
            // else...
            return NotFound(id);
        }

        // DELETE api/<CarController>/5
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            if (_cars.Count > id)
            {
                _cars.Remove(_cars[id]);
                return NoContent(); // 204
            }
            else
            {
                return NotFound(); // 404
            }
        }

        // POST api/<CarController>
        [HttpPost()]
        public object CreateCar([FromBody] Car car)
        {
            _cars.Add(car);
            return "OK";
        }

        private static readonly List<Car>_cars = new List<Car>();
    }

    public class Car
    {
        public int Wheels { get; set; }
        public string Color { get; set; }
    }
}