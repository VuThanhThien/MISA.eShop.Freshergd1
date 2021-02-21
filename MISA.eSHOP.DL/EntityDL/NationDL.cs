using MISA.eSHOP.Common.Model;
using MISA.eSHOP.DataLayer.Interface;
using System;
using System.Collections.Generic;
using System.Text;

namespace MISA.eSHOP.DataLayer.EntityDL
{
    public class NationDL: BaseDLProc<Nation>, INationDL
    {

        public NationDL(IDbContext<Nation> dbContext): base(dbContext)
        {

        }
    }
}
