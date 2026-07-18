using System;
using System.Collections.Generic;
using System.Text;

namespace Spruce_Wood_Loggers_ERP
{
    class BatchPersistence
    {

        public static void SaveBatch(Batch batch)
        {
            using (var db = new AppDbContext())
            {
                db.Batches.Add(batch);
                db.SaveChanges();
            }
        }
    }
}
