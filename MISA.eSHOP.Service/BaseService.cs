using MISA.eSHOP.Common.Enum;
using MISA.eSHOP.Common.Model;
using MISA.eSHOP.DataLayer.Interface;
using MISA.eSHOP.Service.Interface;
using System;
using System.Collections.Generic;
using System.Text;

namespace MISA.eSHOP.Service
{
    public class BaseService<T> : IBaseService<T> where T : class
    {
        private readonly IBaseDL<T> _baseDL;

        public BaseService(IBaseDL<T> baseDL)
        {
            this._baseDL = baseDL;
        }


        public ServiceResult GetAll()
        {
            var result = new ServiceResult();
            var listEntity = _baseDL.GetAll();

            if (listEntity != null)
            {
                result.Data = listEntity;
                result.MISACode = "200";
                result.Success = true;
            }
            else
            {
                result.Data = new Error()
                {
                    //todo thêm các enum khác nữa...
                    DevMsg = DevMsgEnum.DefaultDevMsg,
                    MoreInfo = MoreInfoEnum.DefaultMoreInfo,
                    UserMsg = UserMsgEnum.DefaultUserMsg
                };
                result.Success = false;
                result.MISACode = "400";
            }

            return result;
        }

        public ServiceResult GetById(Guid id)
        {
            var result = new ServiceResult();
            var listEntity = _baseDL.GetById(id);

            if (listEntity != null)
            {
                result.Data = listEntity;
                result.MISACode = "200";
                result.Success = true;
            }
            else
            {
                result.Data = new Error()
                {
                    DevMsg = DevMsgEnum.CannotFound,
                    MoreInfo = MoreInfoEnum.DefaultMoreInfo,
                    UserMsg = UserMsgEnum.DefaultUserMsg
                };
                result.Success = false;
                result.MISACode = "400";
            }

            return result;
        }

        public ServiceResult GetByIDParent(Guid id, string parentField)
        {
            var result = new ServiceResult();
            var listEntity = _baseDL.GetByIDParent(id, parentField);

            if (listEntity != null)
            {
                result.Data = listEntity;
                result.MISACode = "200";
                result.Success = true;
            }
            else
            {
                result.Data = new Error()
                {
                    DevMsg = DevMsgEnum.CannotFound,
                    MoreInfo = MoreInfoEnum.DefaultMoreInfo,
                    UserMsg = UserMsgEnum.DefaultUserMsg
                };
                result.Success = false;
                result.MISACode = "400";
            }

            return result;
        }


        public ServiceResult Delete(Guid id)
        {
            var result = new ServiceResult();
            int deleteResult = _baseDL.Delete(id);

            if (deleteResult > 0)
            {
                result.Data = deleteResult;
                result.MISACode = "200";
                result.Success = true;
            }
            else
            {
                result.Data = new Error()
                {
                    DevMsg = DevMsgEnum.CannotFound,
                    MoreInfo = MoreInfoEnum.DefaultMoreInfo,
                    UserMsg = UserMsgEnum.DefaultUserMsg
                };
                result.Success = false;
                result.MISACode = "400";
            }

            return result;

        }
    }
}
