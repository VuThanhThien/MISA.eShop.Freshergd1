using System;
using System.Collections.Generic;
using System.Text;

namespace MISA.eSHOP.Common.Model
{
    public class District
    {
        /// <summary>
        /// id quận huyện
        /// </summary>
        /// createdby vtthien 21/02/21
        public Guid DistrictID { get; set; }

        /// <summary>
        /// mã quận huyện
        /// </summary>
        public string DistrictCode { get; set; }

        /// <summary>
        /// tên quận huyện
        /// </summary>
        public string DistrictName { get; set; }

        /// <summary>
        /// id tỉnh / thành phố chứa quận huyện
        /// </summary>
        public Guid CityID { get; set; }
    }
}
