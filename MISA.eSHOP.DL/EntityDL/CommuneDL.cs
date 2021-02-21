using MISA.eSHOP.Common.Model;
using MISA.eSHOP.DataLayer.Interface;

namespace MISA.eSHOP.DataLayer.EntityDL
{
    public class CommuneDL : BaseDLProc<Commune>, ICommuneDL
    {

        public CommuneDL(IDbContext<Commune> dbContext) : base(dbContext)
        {

        }
    }
}
