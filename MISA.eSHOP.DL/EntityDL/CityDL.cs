using MISA.eSHOP.Common.Model;
using MISA.eSHOP.DataLayer.Interface;

namespace MISA.eSHOP.DataLayer.EntityDL
{
    public class CityDL : BaseDLProc<City>, ICityDL
    {

        public CityDL(IDbContext<City> dbContext) : base(dbContext)
        {

        }
    }
}
