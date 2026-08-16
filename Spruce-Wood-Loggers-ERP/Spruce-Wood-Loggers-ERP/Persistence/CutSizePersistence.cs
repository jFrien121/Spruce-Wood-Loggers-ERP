using Microsoft.EntityFrameworkCore;
using PdfSharp.Pdf.Annotations;
using Spruce_Wood_Loggers_ERP.Database_Objects;
using System;
using System.Collections.Generic;
using System.Text;

namespace Spruce_Wood_Loggers_ERP.Persistence
{
    class CutSizePersistence
    {

        public static async Task<List<CutSize>> LoadCutSizes()
        {
            List<CutSize> cutSizes = new List<CutSize>();
            using (var db = new AppDbContext())
            {
                cutSizes = await db.CutSizes.ToListAsync();
            }
            return cutSizes;
        }
    }
}
