using System;
using System.Collections.Generic;
using System.Text;

namespace MISA.eSHOP.Common.Model
{
    public class City
    {
        /// <summary>
        /// id thành phố
        /// </summary>
        public Guid CityID { get; set; }

        /// <summary>
        /// mã thành phố
        /// </summary>
        public string CityCode { get; set; }

        /// <summary>
        /// tên thành phố
        /// </summary>
        public string CityName { get; set; }

        /// <summary>
        /// id quốc gia chứa thành phố
        /// </summary>
        public Guid NationID { get; set; }
    }
}
