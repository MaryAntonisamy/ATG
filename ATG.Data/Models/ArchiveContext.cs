using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

#nullable disable

namespace ATG.Data.Models
{
    public partial class ArchiveContext : DbContext
    {
        private string _connectionString;

        public virtual DbSet<Lot> Lot { get; set; }
        public ArchiveContext()
        {
        }
        protected ArchiveContext(string connectionString)
        {
            _connectionString = connectionString;
        }


        public ArchiveContext(DbContextOptions<ArchiveContext> options)
            : base(options)
        {
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer(_connectionString);
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasAnnotation("Relational:Collation", "SQL_Latin1_General_CP1_CI_AS");

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
