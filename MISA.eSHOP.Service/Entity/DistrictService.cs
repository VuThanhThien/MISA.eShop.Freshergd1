using MISA.eSHOP.Common.Model;
using MISA.eSHOP.DataLayer.Interface;
using MISA.eSHOP.Service.Interface;

namespace MISA.eSHOP.Service.Entity
{
    public class DistrictService : BaseService<District>, IDistrictService
    {
        public DistrictService(IBaseDL<District> baseDL) : base(baseDL)
        {

        }

    }
}
