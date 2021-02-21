using Microsoft.AspNetCore.Mvc;
using MISA.eSHOP.Service.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace MISA.eSHOP.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CitiesController : ControllerBase
    {
        private readonly ICityService _cityService;

        public CitiesController(ICityService cityService)
        {
            _cityService = cityService;
        }

        // GET: api/<CitysController>
        /// <summary>
        /// Lấy danh sách thành phố
        /// </summary>
        /// <returns>danh sách thành phố</returns>
        [HttpGet]
        public IActionResult Get()
        {
            var cities = _cityService.GetAll();
            return Ok(cities);
        }

        // GET api/<CitysController>/5
        /// <summary>
        /// lấy thành phố theo id
        /// </summary>
        /// <param name="id">id thành phố</param>
        /// <returns>thành phố tương ứng</returns>
        [HttpGet("{id}")]
        public IActionResult Get(Guid id)
        {
            var city = _cityService.GetById(id);
            return Ok(city);
        }

        /// <summary>
        /// lấy danh sách thành phố theo quốc gia
        /// </summary>
        /// <param name="id">id quốc gia</param>
        /// <returns>danh sách thành phố của quốc gia </returns>
        [HttpGet("ByParent/{id}")]
        public IActionResult GetByIDParent(Guid id)
        {
            var cities = _cityService.GetByIDParent(id, "NationID");
            return Ok(cities);
        }

    }
}
