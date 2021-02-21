using System;
using System.Collections.Generic;
using System.Text;

namespace MISA.eSHOP.Common.Model
{
    public class Street
    {
        /// <summary>
        /// id của đường phố
        /// </summary>
        /// createdby vtthien 21/02/21
        public Guid StreetID { get; set; }

        /// <summary>
        /// mã đường phố
        /// </summary>
        public string StreetCode { get; set; }

        /// <summary>
        /// tên đường phố
        /// </summary>
        public string StreetName { get; set; }

        /// <summary>
        /// id xã phường chứa đường phố
        /// </summary>
        public Guid CommuneID { get; set; }
    }
}
