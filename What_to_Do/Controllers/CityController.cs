using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using What_to_Do.DataBaseContext;
using What_to_Do.Models;
using What_to_Do.Models.DTOs;
using What_to_Do.Services.Interfaces;

namespace What_to_Do.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class CityController : ControllerBase
    {
        private readonly ICityService _service;

        public CityController(ICityService service)
        {
            _service = service;
        }

        // GET: api/City
        [HttpGet]
        public async Task<ActionResult> GetCities()
        {
           var cities =  await _service.GetAllAsync();
            return Ok(cities);
        }

        // GET: api/City/5
        [HttpGet("{id}")]
        public async Task<ActionResult<City>> GetCity(int id)
        {
            var city = await _service.GetByIdAsync(id);
            return Ok(city);
        }

        // PUT: api/City/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutCity(int id, UpdateCityDTO city)
        {
            await _service.UpdateAsync(id, city);
            return Ok("Updated City Successfully");
        }

        // POST: api/City
       
        [HttpPost]
        public async Task<ActionResult> PostCity(CreateCityDTO city)
        {
            await _service.CreateAsync(city);
            return Ok("City Created Successfully");
        }

        // DELETE: api/City/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteCity(int id)
        {
           await _service.DeleteAsync(id);
            return Ok("Deleted City Successfully");
        }


    }
}
