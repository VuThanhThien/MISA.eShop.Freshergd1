using MISA.eSHOP.Common.Model;
using MISA.eSHOP.DataLayer.Interface;
using MISA.eSHOP.Service.Interface;

namespace MISA.eSHOP.Service.Entity
{
    public class CommuneService : BaseService<Commune>, ICommuneService
    {
        public CommuneService(IBaseDL<Commune> baseDL) : base(baseDL)
        {

        }

    }
}
