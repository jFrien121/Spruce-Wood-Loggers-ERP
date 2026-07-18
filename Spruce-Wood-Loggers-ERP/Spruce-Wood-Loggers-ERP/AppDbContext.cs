using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

/**
 * AppDbContext
 * Create a database context for the application
 * using Entity Framework Core.
 * 
 */

namespace Spruce_Wood_Loggers_ERP
{
    class AppDbContext : DbContext
    {
        public DbSet<Batch> Batches { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder options)
        {
            options.UseSqlite("Data Source=Spruce_Wood_Loggers_Cut_Database.db");
        }
    }
}
