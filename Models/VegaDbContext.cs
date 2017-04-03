using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace vega.Models
{
    public class VegaDbContext : DbContext
    {
 
        public virtual DbSet<MFeature> MFeature { get; set; }
        public virtual DbSet<MMake> MMake { get; set; }
        public virtual DbSet<MModel> MModel { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            #warning To protect potentially sensitive information in your connection string, you should move it out of source code. See http://go.microsoft.com/fwlink/?LinkId=723263 for guidance on storing connection strings.
            optionsBuilder.UseSqlServer(@"Server=wheee\sqlexpress;Database=vega; user id=sa; password=12345;");
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<MFeature>(entity =>
            {
                entity.ToTable("M_feature");

                entity.Property(e => e.Id)
                    .HasColumnName("id")
                    .ValueGeneratedNever();

                entity.Property(e => e.Feature)
                    .IsRequired()
                    .HasColumnName("feature")
                    .HasColumnType("varchar(50)");
            });

            modelBuilder.Entity<MMake>(entity =>
            {
                entity.ToTable("M_make");

                entity.Property(e => e.Id)
                    .HasColumnName("id")
                    .ValueGeneratedNever();

                entity.Property(e => e.Make)
                    .IsRequired()
                    .HasColumnName("make")
                    .HasColumnType("varchar(50)");
            });

            modelBuilder.Entity<MModel>(entity =>
            {
                entity.ToTable("M_model");

                entity.Property(e => e.Id)
                    .HasColumnName("id")
                    .ValueGeneratedNever();

                entity.Property(e => e.MakeId).HasColumnName("make_id");

                entity.Property(e => e.Model)
                    .HasColumnName("model")
                    .HasColumnType("varchar(50)");

                entity.HasOne(d => d.Make)
                    .WithMany(p => p.MModel)
                    .HasForeignKey(d => d.MakeId)
                    .HasConstraintName("FK_model_make");
            });
        }
    }
}




    