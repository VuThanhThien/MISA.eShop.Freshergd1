using MISA.eSHOP.Common.Model;
using MISA.eSHOP.DataLayer.Interface;

namespace MISA.eSHOP.DataLayer.EntityDL
{
    public class DistrictDL : BaseDLProc<District>, IDistrictDL
    {

        public DistrictDL(IDbContext<District> dbContext) : base(dbContext)
        {

        }
    }
}
