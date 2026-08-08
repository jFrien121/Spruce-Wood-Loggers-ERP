using Microsoft.EntityFrameworkCore;
using Spruce_Wood_Loggers_ERP.Database_Objects;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Text.Json;

/**
 * AppDbContext
 * Create a database context for the application
 * using Entity Framework Core.
 */

namespace Spruce_Wood_Loggers_ERP
{
    class AppDbContext : DbContext
    {
        public DbSet<Batch> Batches { get; set; }
        public DbSet<CutLength> CutLengths { get; set; }
        public DbSet<CutSize> CutSizes { get; set; }
        public DbSet<StandardNumPieces> StandardNumPieces { get; set; }
        public DbSet<StandardSizeRelationship> StandardSizeRelationships { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder options)
        {
            string json = File.ReadAllText(DatabaseConfig.getConfigPath());

            DatabaseConfig dbConfig = JsonSerializer.Deserialize<DatabaseConfig>(json)!;
            options.UseNpgsql($"Host={dbConfig.ipAddress};Port={dbConfig.port};Database=Cut_Tracker_Database;" +
                $"Username={dbConfig.username};Password={dbConfig.password}");
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Batch>()
                .Property(x => x.timeProcessed)
                .HasColumnType("timestamp without time zone");
        }
    }
}
