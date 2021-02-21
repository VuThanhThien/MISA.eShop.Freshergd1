using System;
using System.Collections.Generic;
using System.Text;

namespace MISA.eSHOP.Common.Model
{
    /// <summary>
    /// Model lỗi trả về
    /// </summary>
    public class Error
    {
        /// <summary>
        /// Câu thông báo cho DEV
        /// </summary>
        public string DevMsg { get; set; }

        /// <summary>
        /// Câu thông báo cho người dùng
        /// </summary>
        public string UserMsg { get; set; }

        /// <summary>
        /// Mã lỗi
        /// </summary>
        public string ErrorCode { get; set; }

        /// <summary>
        /// Thông tin liên hệ
        /// </summary>
        public string MoreInfo { get; set; }

        /// <summary>
        /// ID tra cứu lỗi
        /// </summary>
        public string TraceId { get; set; }
    }
}
