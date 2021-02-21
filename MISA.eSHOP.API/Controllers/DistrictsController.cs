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
    public class DistrictsController : ControllerBase
    {
        private readonly IDistrictService _districtService;

        public DistrictsController(IDistrictService districtService)
        {
            _districtService = districtService;
        }

        // GET: api/<DistrictsController>
        /// <summary>
        /// Lấy tất cả quận huyện
        /// </summary>
        /// <returns>danh sách quận huyện</returns>
        /// createdby vtthien 21/02/21
        [HttpGet]
        public IActionResult Get()
        {
            var districts = _districtService.GetAll();
            return Ok(districts);
        }

        // GET api/<DistrictsController>/5
        /// <summary>
        /// lấy quận huyện theo id
        /// </summary>
        /// <param name="id">id quận huyện</param>
        /// <returns>quận huyện</returns>
        [HttpGet("{id}")]
        public IActionResult Get(Guid id)
        {
            var district = _districtService.GetById(id);
            return Ok(district);
        }

        /// <summary>
        /// lấy quận huyện theo tỉnh thành phố
        /// </summary>
        /// <param name="id">id của tỉnh thành phố</param>
        /// <returns>danh sách quận huyện</returns>
        [HttpGet("ByParent/{id}")]
        public IActionResult GetByIDParent(Guid id)
        {
            var districts = _districtService.GetByIDParent(id, "CityID");
            return Ok(districts);
        }

    }
}
