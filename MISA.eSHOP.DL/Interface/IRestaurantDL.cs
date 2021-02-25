using MISA.eSHOP.Common.Model;
using System.Collections;
using System.Collections.Generic;

namespace MISA.eSHOP.DataLayer.Interface
{
    public interface IRestaurantDL : IBaseDL<Restaurant>
    {
        /// <summary>
        /// Tìm kiếm
        /// </summary>
        /// <param name="fieldName">Tên trường cần tìm</param>
        /// <param name="value">Giá trị</param>
        /// <returns></returns>
        public IEnumerable<Restaurant> Search(string fieldName, string value);
    }
}
