using MISA.eSHOP.Common.Model;
using MISA.eSHOP.DataLayer.Interface;
using MISA.eSHOP.Service.Interface;

namespace MISA.eSHOP.Service.Entity
{
    public class NationService : BaseService<Nation>, INationService
    {
        public NationService(IBaseDL<Nation> baseDL) : base(baseDL)
        {

        }

    }
}
