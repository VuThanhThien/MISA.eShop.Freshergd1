using System;
using System.Collections.Generic;
using System.Text;

namespace MISA.eSHOP.Common.Model
{
    public class Nation
    {
        /// <summary>
        /// id quốc gia
        /// </summary>
        /// createdby vtthien 21/02/21
        public Guid NationID { get; set; }

        /// <summary>
        /// mã quốc gia
        /// </summary>
        public string NationCode { get; set; }

        /// <summary>
        /// tên quốc gia
        /// </summary>
        public string NationName { get; set; }
    }
}
