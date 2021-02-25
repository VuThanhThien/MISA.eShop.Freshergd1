using MISA.eSHOP.Common.Model;
using MISA.eSHOP.DataLayer.Interface;
using System.Collections.Generic;

namespace MISA.eSHOP.DataLayer.EntityDL
{
    public class RestaurantDL : BaseDLProc<Restaurant>, IRestaurantDL
    {
        private readonly IDbContext<Restaurant> _dbContext;

        public RestaurantDL(IDbContext<Restaurant> dbContext) : base(dbContext)
        {
            _dbContext = dbContext;
        }

        public IEnumerable<Restaurant> Search(string fieldName, string value)
        {
            var sqlString = $"SELECT * FROM Restaurant WHERE {fieldName} LIKE '%{value}%' ";
            var restaurants = _dbContext.Query(sqlString);

            return restaurants;
        }
    }
}
