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
    public class NationsController : ControllerBase
    {
        private readonly INationService _nationService;

        public NationsController(INationService nationService)
        {
            _nationService = nationService;
        }


        // GET: api/<NationsController>
        /// <summary>
        /// Lấy danh sách quốc gia
        /// </summary>
        /// <returns>danh sách quốc gia</returns>
        /// createdby vtthien 21/02/21
        [HttpGet]
        public IActionResult Get()
        {
            var nations = _nationService.GetAll();
            return Ok(nations);
        }

        // GET api/<NationsController>/5
        /// <summary>
        /// Lấy quốc gia theo id
        /// </summary>
        /// <param name="id">id quốc gia</param>
        /// <returns>quốc gia </returns>
        [HttpGet("{id}")]
        public IActionResult Get(Guid id)
        {
            var nation = _nationService.GetById(id);
            return Ok(nation);
        }

    }
}
