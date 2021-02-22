using System;
using System.Collections.Generic;
using System.Text;

namespace MISA.eSHOP.Common.Model
{
    /// <summary>
    /// Model restaurant - Nhà hàng
    /// </summary>
    /// Created By VTThien (21/02/21)
    public class Restaurant
    {
        #region properties
        /// <summary>
        /// ID Cửa hàng
        /// </summary>
        public Guid RestaurantID { get; set; }

        /// <summary>
        /// Mã cửa hàng
        /// </summary>
        public string RestaurantCode { get; set; }

        /// <summary>
        /// Mã khách hàng
        /// </summary>
        public string RestaurantName { get; set; }

        /// <summary>
        /// Địa chỉ 
        /// </summary>
        public string Address { get; set; }

        /// <summary>
        /// Số điện thoại
        /// </summary>
        public string PhoneNumber { get; set; }

        /// <summary>
        /// Mã số thuế
        /// </summary>
        public string TaxCode { get; set; }

        /// <summary>
        /// ID quốc gia
        /// </summary>
        public Guid? NationID { get; set; }

        /// <summary>
        /// ID Thành phố/ tỉnh
        /// </summary>
        public Guid? CityID { get; set; }

        /// <summary>
        /// ID quận/ huyện
        /// </summary>
        public Guid? DistrictID { get; set; }

        /// <summary>
        /// ID Xã/ phường
        /// </summary>
        public Guid? CommuneID { get; set; }

        /// <summary>
        /// ID đường phố
        /// </summary>
        public Guid? StreetID { get; set; }

        ///// <summary>
        ///// Tạo bởi
        ///// </summary>
        //public string CreatedBy { get; set; }



        #endregion


        ///// <summary>
        ///// Ngày tạo
        ///// </summary>
        //public DateTime? CreatedDate { get; set; }


        ///// <summary>
        ///// Ngày sửa
        ///// </summary>
        //public DateTime? ModifiedDate { get; set; }

        ///// <summary>
        ///// Người sửa
        ///// </summary>
        //public string ModifiedBy { get; set; }
    }
}
