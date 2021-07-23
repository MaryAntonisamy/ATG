using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

#nullable disable

namespace ATG.Data.Models
{
    public partial class FailoverContext : DbContext
    {
        private readonly string _connectionString;
        public FailoverContext()
        {
        }

        protected FailoverContext(string connectionString)
        {
            _connectionString = connectionString;
        }

            public FailoverContext(DbContextOptions<FailoverContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Lot> Lot { get; set; }
        public virtual DbSet<FailoverLot> FailoverLots { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer(_connectionString);
                //#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
                //                optionsBuilder.UseSqlServer();
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasAnnotation("Relational:Collation", "SQL_Latin1_General_CP1_CI_AS");

            modelBuilder.Entity<FailoverLot>(entity =>
            {
                entity.HasKey(e => e.FailoverId);

                entity.Property(e => e.DateTime).HasColumnType("datetime");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
