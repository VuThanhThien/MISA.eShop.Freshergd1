using MISA.eSHOP.Common.Enum;
using MISA.eSHOP.Common.Model;
using MISA.eSHOP.DataLayer.Interface;
using MISA.eSHOP.Service.Interface;
using System;

namespace MISA.eSHOP.Service.Entity
{
    public class RestaurantService: BaseService<Restaurant>, IRestaurantService
    {
        private readonly IRestaurantDL _restaurantDL;

        public RestaurantService(IBaseDL<Restaurant> baseDL, IRestaurantDL restaurantDL) : base(baseDL)
        {
            _restaurantDL = restaurantDL;
        }

        public ServiceResult InsertRestaurant(Restaurant restaurant)
        {
            var serviceResult = new ServiceResult();
            var errorMsg = new Error();
            // validate bắt buộc nhập
            //validate bắt buộc nhập mã cửa hàng
            if (restaurant.RestaurantCode == null || restaurant.RestaurantCode == string.Empty)
            {
                //TODO viết lại mấy dòng thông báo thiếu mã cửa hàng
                errorMsg.DevMsg = DevMsgEnum.DefaultDevMsg;
                errorMsg.UserMsg = UserMsgEnum.DefaultUserMsg;
                serviceResult.Success = false;
                serviceResult.Data = errorMsg;
                return serviceResult;
            }

            //validate bắt buộc nhập tên cửa hàng
            if (restaurant.RestaurantName == null || restaurant.RestaurantName == string.Empty)
            {
                //TODO viết lại mấy dòng thông báo thiếu mã cửa hàng
                errorMsg.DevMsg = DevMsgEnum.DefaultDevMsg;
                errorMsg.UserMsg = UserMsgEnum.DefaultUserMsg;
                serviceResult.Success = false;
                serviceResult.Data = errorMsg;
                return serviceResult;
            }

            //validate bắt buộc nhập địa chỉ
            if (restaurant.Address == null || restaurant.Address == string.Empty)
            {
                //TODO viết lại mấy dòng thông báo thiếu mã cửa hàng
                errorMsg.DevMsg = DevMsgEnum.DefaultDevMsg;
                errorMsg.UserMsg = UserMsgEnum.DefaultUserMsg;
                serviceResult.Success = false;
                serviceResult.Data = errorMsg;
                return serviceResult;
            }

            //kiểm tra cửa hnagf này có bị trùng không
            serviceResult = CheckDuplicatedRestaurant(restaurant);

            //nếu trùng trả về lỗi
            if (!serviceResult.Success)
            {
                return serviceResult;
            }

            //nếu không trùng thì insert
            var res = _restaurantDL.Insert(restaurant);

            //insert thành công
            if (res > 0)
            {
                serviceResult.Success = true;
                serviceResult.Data = res;
                return serviceResult;
            }
            else
            {
                // insert thất bại
                serviceResult.Success = true;
                errorMsg.DevMsg = DevMsgEnum.DefaultDevMsg;
                errorMsg.UserMsg = UserMsgEnum.DefaultUserMsg;
                serviceResult.Data = errorMsg;
                return serviceResult;
            }
            throw new NotImplementedException();
        }

        public ServiceResult UpdateRestaurant(Guid id, Restaurant restaurant)
        {
            throw new NotImplementedException();
        }

        private ServiceResult CheckDuplicatedRestaurant(Restaurant restaurant, string id = "")
        {
            var serviceResult = new ServiceResult();
            var errorMsg = new Error();

            //validate trùng mã cửa hàng
            var isExisted = _restaurantDL.GetEntityByCode(restaurant.RestaurantCode);
            if (!string.IsNullOrEmpty(id))
            {
                if (id != isExisted.RestaurantID.ToString())
                {
                    errorMsg.DevMsg = DevMsgEnum.DefaultDevMsg;
                    errorMsg.UserMsg = UserMsgEnum.DefaultUserMsg;
                    serviceResult.Success = false;
                    serviceResult.Data = errorMsg;
                    return serviceResult;
                }
            }
            else
            {
                if (isExisted != null)
                {
                    errorMsg.DevMsg = DevMsgEnum.DefaultDevMsg;
                    errorMsg.UserMsg = UserMsgEnum.DefaultUserMsg;
                    serviceResult.Success = false;
                    serviceResult.Data = errorMsg;
                    return serviceResult;
                }
            }
            return serviceResult;
        }
    }
}
