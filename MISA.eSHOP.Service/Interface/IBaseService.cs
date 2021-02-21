using MISA.eSHOP.Common.Model;
using System;
using System.Collections.Generic;
using System.Text;

namespace MISA.eSHOP.Service.Interface
{
    public interface IBaseService<T>
    {
        /// <summary>
        /// Lấy tất cả danh sách
        /// </summary>
        /// <returns>danh sách</returns>
        /// createdby vtthien 21/02/21
        ServiceResult GetAll();

        /// <summary>
        /// Lấy đối tượng theo id
        /// </summary>
        /// <param name="id"></param>
        /// <returns>đối tượng cần lấy</returns>
        ServiceResult GetById(Guid id);

        /// <summary>
        /// Lấy danh sách đối tượng theo id của đối tượng cha
        /// </summary>
        /// <param name="id">id của đối tượng cha</param>
        /// <param name="parentField">tên trường cha</param>
        /// <returns></returns>
        ServiceResult GetByIDParent(Guid id, string parentField);

        /// <summary>
        /// Xóa theo Id
        /// </summary>
        /// <param name="id">ID của thực thể cần xóa</param>
        /// <returns></returns>
        ServiceResult Delete(Guid id);
    }
}
