using Dapper;
using System;
using System.Collections.Generic;
using System.Data;
using System.Text;

namespace MISA.eSHOP.DataLayer.Interface
{

    /// <summary>
    /// Interface DbContext
    /// </summary>
    /// <typeparam name="T">Kiểu truyền vào</typeparam>
    /// CreatedBy VTThien 21/02/21
    public interface IDbContext<T> where T : class
    {
        /// <summary>
        /// Dùng cho các câu SelectAll
        /// </summary>
        /// <param name="sqlCommand">câu lệnh/ tên proc</param>
        /// <param name="parameters">tham số nếu có</param>
        /// <param name="commandType"></param>
        /// <returns>Danh sách đối tượng</returns>
        IEnumerable<T> Query(string sqlCommand, DynamicParameters parameters = null, CommandType commandType = CommandType.Text);

        /// <summary>
        /// Dùng cho SelectByID
        /// </summary>
        /// <param name="sqlCommand">câu lệnh/ tên proc</param>
        /// <param name="parameters">tham số nếu có</param>
        /// <param name="commandType"></param>
        /// <returns>Đối tượng</returns>
        T QueryFirst(string sqlCommand, DynamicParameters parameters = null, CommandType commandType = CommandType.Text);

        /// <summary>
        /// Dùng cho Insert, Update, Delete
        /// </summary>
        /// <param name="sqlCommand"></param>
        /// <param name="parameters"></param>
        /// <param name="commandType"></param>
        /// <returns>Số bản ghi được thay đổi</returns>
        int Excute(string sqlCommand, DynamicParameters parameters = null, CommandType commandType = CommandType.Text);
    }
}
