using Microsoft.AspNetCore.Mvc;
using MISA.eSHOP.Common.Model;
using MISA.eSHOP.Service.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace MISA.eSHOP.API.Controllers
{
    [Route("api/v1/restaurants")]
    [ApiController]
    public class RestaurantsController : ControllerBase
    {
        private readonly IRestaurantService _restaurantService;

        public RestaurantsController(IRestaurantService restaurantService)
        {
            _restaurantService = restaurantService;
        }

        /// <summary>
        /// Lấy tất cả cửa hàng
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public ServiceResult GetAllRestaurant()
        {
            var serviceResult = _restaurantService.GetAll();
            return serviceResult;
        }

        /// <summary>
        /// Lấy cửa hàng theo Id
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpGet("{id}")]
        public ServiceResult GetById([FromRoute] Guid id)
        {
            var serviceResult = _restaurantService.GetById(id);
            return serviceResult;
        }

        /// <summary>
        /// Thêm mới cửa hàng
        /// </summary>
        /// <param name="restaurant"></param>
        /// <returns></returns>
        [HttpPost]
        public IActionResult PostCustomer([FromBody] Restaurant restaurant)
        {
            var res = _restaurantService.InsertRestaurant(restaurant);
            if (res.Success == false)
            {
                return StatusCode(400, res.Data);
            }
            else if (res.Success == true && (int)res.Data > 0)
            {
                return StatusCode(201, res.Data);
            }
            else
            {
                return StatusCode(200, res.Data);
            }
        }

        // PUT api/<RestaurantsController>/5
        /// <summary>
        /// Sửa cửa hàng
        /// </summary>
        /// <param name="id"></param>
        /// <param name="value"></param>
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/<RestaurantsController>/5
        /// <summary>
        /// Xóa cửa hàng
        /// </summary>
        /// <param name="id"></param>
        [HttpDelete("{id}")]
        public IActionResult Delete([FromRoute] Guid id)
        {

            var res = _restaurantService.Delete(id);

            if (res.Success == false)
            {
                return StatusCode(400, res.Data);
            }
            else
            {
                return StatusCode(200, res.Data);
            }
        }
    }
}
