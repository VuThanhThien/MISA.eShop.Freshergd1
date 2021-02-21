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
    public class StreetsController : ControllerBase
    {

        private readonly IStreetService _streetService;

        public StreetsController(IStreetService streetService)
        {
            _streetService = streetService;
        }
        // GET: api/<StreetsController>
        /// <summary>
        /// lấy tất cả đường phố
        /// </summary>
        /// <returns>danh sahcs đường phố</returns>
        [HttpGet]
        public IActionResult Get()
        {
            var streets = _streetService.GetAll();
            return Ok(streets);
        }

        // GET api/<StreetsController>/5
        /// <summary>
        /// Lấy theo ID
        /// </summary>
        /// <param name="id">id</param>
        /// <returns>đường phố</returns>
        [HttpGet("{id}")]
        public IActionResult Get(Guid id)
        {
            var street = _streetService.GetById(id);
            return Ok(street);
        }

        /// <summary>
        /// Get theo bố mẹ
        /// </summary>
        /// <param name="id">id của ã phường</param>
        /// <returns>danh sách đường phố của xã phường ấy</returns>
        /// createdby vtthien 21/02/21
        [HttpGet("ByParent/{id}")]
        public IActionResult GetByIDParent(Guid id)
        {
            var streets = _streetService.GetByIDParent(id, "CommuneID");
            return Ok(streets);
        }
    }
}
