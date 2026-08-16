using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace Spruce_Wood_Loggers_ERP.Persistence
{
    class PersistenceSetUp
    {

        public static void ConnectToDatabase()
        {
            using (var db = new AppDbContext())
            {
                db.Database.Migrate();
            }
        }
    }
}
