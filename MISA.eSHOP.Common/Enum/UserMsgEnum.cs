using System;
using System.Collections.Generic;
using System.Text;

namespace MISA.eSHOP.Common.Enum
{
    public class UserMsgEnum
    {
        public static string DefaultUserMsg = "Có lỗi xảy ra vui lòng liên hệ MISA";
        public static string RestaurantCodeRequired = MISA.eSHOP.Common.Properties.Resources.RestaurantCodeRequired;
        public static string RestaurantNameRequired = MISA.eSHOP.Common.Properties.Resources.RestaurantNameRequired;
        public static string RestaurantAddressRequired = MISA.eSHOP.Common.Properties.Resources.RestaurantAddressRequired;
        public static string ValidateFail = MISA.eSHOP.Common.Properties.Resources.ValidateFail;
        public static string DupplicatedRestaurant = MISA.eSHOP.Common.Properties.Resources.DupplicatedRestaurant;
    }
}
