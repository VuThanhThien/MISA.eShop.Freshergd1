using MISA.eSHOP.Common.Model;
using MISA.eSHOP.DataLayer.Interface;
using MISA.eSHOP.Service.Interface;

namespace MISA.eSHOP.Service.Entity
{
    public class CityService : BaseService<City>, ICityService
    {
        public CityService(IBaseDL<City> baseDL) : base(baseDL)
        {

        }

    }
}
