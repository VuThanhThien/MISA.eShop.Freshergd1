using MISA.eSHOP.Common.Model;
using MISA.eSHOP.DataLayer.Interface;

namespace MISA.eSHOP.DataLayer.EntityDL
{
    public class RestaurantDL: BaseDLProc<Restaurant>, IRestaurantDL
    {
        private readonly IDbContext<Restaurant> _dbContext;

        public RestaurantDL(IDbContext<Restaurant> dbContext) : base(dbContext)
        {
            _dbContext = dbContext;
        }
    }
}
