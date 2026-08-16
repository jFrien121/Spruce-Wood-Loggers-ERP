using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace Spruce_Wood_Loggers_ERP.Persistence
{
    class CutLengthPersistence
    {

        public static async Task<List<double>> LoadCutLengths()
        {
            List<double> cutLengths = new List<double>();

            using (var db = new AppDbContext())
            {
                cutLengths = await db.CutLengths.Select(l => l.length).ToListAsync();
            }

            return cutLengths;
        }
    }
}
