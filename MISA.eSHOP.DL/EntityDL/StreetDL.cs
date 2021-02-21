using MISA.eSHOP.Common.Model;
using MISA.eSHOP.DataLayer.Interface;

namespace MISA.eSHOP.DataLayer.EntityDL
{
    public class StreetDL : BaseDLProc<Street>, IStreetDL
    {

        public StreetDL(IDbContext<Street> dbContext) : base(dbContext)
        {

        }
    }
}
