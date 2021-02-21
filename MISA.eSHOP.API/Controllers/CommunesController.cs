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
    public class CommunesController : ControllerBase
    {
        private readonly ICommuneService _communeService;

        public CommunesController(ICommuneService communeService)
        {
            _communeService = communeService;
        }

        // GET: api/<CommunesController>
        /// <summary>
        /// Danh sách tất cả xã phường
        /// </summary>
        /// <returns>danh sách xã phường</returns>
        [HttpGet]
        public IActionResult Get()
        {
            var communes = _communeService.GetAll();
            return Ok(communes);
        }

        // GET api/<CommunesController>/5
        /// <summary>
        /// Lấy xã phường theo id
        /// </summary>
        /// <param name="id">id</param>
        /// <returns>xã phường</returns>
        [HttpGet("{id}")]
        public IActionResult Get(Guid id)
        {
            var commune = _communeService.GetById(id);
            return Ok(commune);
        }

        /// <summary>
        /// Get theo bố mẹ
        /// </summary>
        /// <param name="id">id của Quận huyện</param>
        /// <returns>danh sách xã phường</returns>
        [HttpGet("ByParent/{id}")]
        public IActionResult GetByIDParent(Guid id)
        {
            var communes = _communeService.GetByIDParent(id, "DistrictID");
            return Ok(communes);
        }

    }
}
