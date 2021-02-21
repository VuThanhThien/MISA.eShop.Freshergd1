using System;
using System.Collections.Generic;
using System.Text;

namespace MISA.eSHOP.Common.Model
{
    public class Commune
    {
        /// <summary>
        /// id xã phường
        /// </summary>
        /// createdby vtthien 21/02/21
        public Guid CommuneID { get; set; }

        /// <summary>
        /// mã xã phường
        /// </summary>
        public string CommuneCode { get; set; }

        /// <summary>
        /// tên xã phường
        /// </summary>
        public string CommuneName { get; set; }

        /// <summary>
        /// id quận huyện chứa xã phường
        /// </summary>
        public Guid DistrictID { get; set; }
    }
}
