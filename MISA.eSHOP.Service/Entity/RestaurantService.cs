using MISA.eSHOP.Common.Enum;
using MISA.eSHOP.Common.Model;
using MISA.eSHOP.DataLayer.Interface;
using MISA.eSHOP.Service.Interface;
using System;

namespace MISA.eSHOP.Service.Entity
{
    public class RestaurantService : BaseService<Restaurant>, IRestaurantService
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
                errorMsg.DevMsg = DevMsgEnum.RestaurantCodeRequired;
                errorMsg.UserMsg = UserMsgEnum.RestaurantCodeRequired;
                serviceResult.Success = false;
                serviceResult.Data = errorMsg;
                return serviceResult;
            }

            //validate bắt buộc nhập tên cửa hàng
            if (restaurant.RestaurantName == null || restaurant.RestaurantName == string.Empty)
            {
                errorMsg.DevMsg = DevMsgEnum.RestaurantNameRequired;
                errorMsg.UserMsg = UserMsgEnum.RestaurantNameRequired;
                serviceResult.Success = false;
                serviceResult.Data = errorMsg;
                return serviceResult;
            }

            //validate bắt buộc nhập địa chỉ
            if (restaurant.Address == null || restaurant.Address == string.Empty)
            {
                errorMsg.DevMsg = DevMsgEnum.RestaurantAddressRequired;
                errorMsg.UserMsg = UserMsgEnum.RestaurantAddressRequired;
                serviceResult.Success = false;
                serviceResult.Data = errorMsg;
                return serviceResult;
            }

            //tu sinh guid id
            restaurant.RestaurantID = Guid.NewGuid();

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
                errorMsg.DevMsg = DevMsgEnum.ValidateFail;
                errorMsg.UserMsg = UserMsgEnum.ValidateFail;
                serviceResult.Data = errorMsg;
                return serviceResult;
            }
            throw new NotImplementedException();
        }

        /// <summary>
        /// update cwar hang
        /// </summary>
        /// <param name="id"></param>
        /// <param name="restaurant"></param>
        /// <returns></returns>
        public ServiceResult UpdateRestaurant(Guid id, Restaurant restaurant)
        {
            var serviceResult = new ServiceResult();
            var errorMsg = new Error();
            if (id != restaurant.RestaurantID)
            {
                return null;
            }

            // lay theo id
            var restaurantUpdate = _restaurantDL.GetById(id);

            if (restaurantUpdate != null)
            {
                // trước khi cập nhật, kiểm tra dữ liệu sau khi sửa có bị trùng lặp với người dùng khác hay không
                //kiểm tra xem khách hàng này có các trường bị trùng lặp không
                serviceResult = CheckDuplicatedRestaurant(restaurant, id.ToString());

                // nếu bị trùng lặp, trả về luôn lỗi
                if (!serviceResult.Success)
                {
                    //TODO: Tạo enum mã lỗi trùng mã cửa hàng
                    serviceResult.MISACode = "1001";
                    return serviceResult;
                }

                // không bị trùng lặp mới cho phép cập nhật
                var result = _restaurantDL.Update(restaurant);

                if (result > 0)
                {
                    serviceResult.Success = true;
                    serviceResult.Data = result;
                    return serviceResult;
                }
                else
                {
                    serviceResult.Success = false;
                    errorMsg.UserMsg = UserMsgEnum.DefaultUserMsg;
                    errorMsg.DevMsg = DevMsgEnum.CannotFound;
                    serviceResult.Data = errorMsg;
                    return serviceResult;
                }
            }
            else
            {
                serviceResult.Success = true;
                errorMsg.DevMsg = DevMsgEnum.DefaultDevMsg;
                errorMsg.UserMsg = UserMsgEnum.DefaultUserMsg;
                serviceResult.Data = errorMsg;
                return serviceResult;
            }
            throw new NotImplementedException();
        }

        /// <summary>
        /// Kiểm tra trùng mã cửa hàng
        /// </summary>
        /// <param name="restaurant">Thông tin cửa hàng</param>
        /// <param name="id">Id cửa hàng đang sửa (mặc định là rỗng - ở case thêm mới)</param>
        /// <returns></returns>
        /// TODO: khai báo các tham số trả về cho Client
        private ServiceResult CheckDuplicatedRestaurant(Restaurant restaurant, string id = "")
        {
            var serviceResult = new ServiceResult();
            var errorMsg = new Error();

            //validate trùng mã cửa hàng
            var isExisted = _restaurantDL.GetEntityByCode(restaurant.RestaurantCode);
            
            // khi truyền id vào => case check trùng mã khi sửa thông tin
            if (!string.IsNullOrEmpty(id))
            {
                // nếu Id truyền vào (id cửa hàng đang sửa) != ID lấy được trong db => tức là đang sửa thành mã cửa hàng của cửa hàng khác
                if (isExisted != null && id != isExisted.RestaurantID.ToString())
                {
                    errorMsg.DevMsg = $"Mã cửa hàng {restaurant.RestaurantCode} đã được sử dụng cho cửa hàng {isExisted.RestaurantName}";
                    errorMsg.UserMsg = UserMsgEnum.DefaultUserMsg;
                    serviceResult.Success = false;
                    serviceResult.Data = errorMsg;
                    return serviceResult;
                }
            }
            else
            {
                // ngược lại, khi không truyền mã ID cửa hàng lên => case check trùng khi thêm mới
                // khi tìm thấy bản ghi theo mã cửa hàng thì trả về lỗi
                if (isExisted != null)
                {
                    errorMsg.DevMsg = $"Mã cửa hàng {restaurant.RestaurantCode} đã được sử dụng cho cửa hàng {isExisted.RestaurantName}";
                    errorMsg.UserMsg = UserMsgEnum.DupplicatedRestaurant;
                    serviceResult.Success = false;
                    serviceResult.Data = errorMsg;
                    return serviceResult;
                }
            }
            return serviceResult;
        }
    }
}
