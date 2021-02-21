using MISA.eSHOP.Common.Model;
using MISA.eSHOP.DataLayer.Interface;
using MISA.eSHOP.Service.Interface;

namespace MISA.eSHOP.Service.Entity
{
    public class StreetService: BaseService<Street>, IStreetService
    {
        public StreetService(IBaseDL<Street> baseDL): base(baseDL)
        {

        }

    }
}
