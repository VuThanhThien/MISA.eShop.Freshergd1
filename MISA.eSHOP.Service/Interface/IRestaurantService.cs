using MISA.eSHOP.Common.Model;
using System;
using System.Collections.Generic;
using System.Text;

namespace MISA.eSHOP.Service.Interface
{
    public interface IRestaurantService: IBaseService<Restaurant>
    {
        /// <summary>
        /// thêm mới cửa hàng
        /// </summary>
        /// <param name="restaurant">cửa hàng cần thêm</param>
        /// <returns></returns>
        /// createdby vtthien 21/02/21
        ServiceResult InsertRestaurant(Restaurant restaurant);

        /// <summary>
        /// Sửa cửa hàng
        /// </summary>
        /// <param name="id">id cửa hàng</param>
        /// <param name="restaurant">đối tượng cửa hàng</param>
        /// <returns></returns>
        ServiceResult UpdateRestaurant(Guid id, Restaurant restaurant);

        /// <summary>
        /// Tìm kiếm
        /// </summary>
        /// <param name="fieldName"></param>
        /// <param name="value"></param>
        /// <returns></returns>
        ServiceResult Search(string fieldName, string value);

        //TODO đang làm pagin
        int totalRestaurant();

        int numberPage(int totalPage, int limit);

        ServiceResult paginRestaurant(int start, int limit);
    }
}
