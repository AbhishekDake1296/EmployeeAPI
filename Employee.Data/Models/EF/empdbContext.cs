using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Protocols;

namespace Employee.Data.Models.EF
{
    public partial class empdbContext : DbContext
    {
        public IConfiguration Configuration { get; set; }
        public empdbContext(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public empdbContext(DbContextOptions<empdbContext> options)
            : base(options)
        {
        }

        public virtual DbSet<TblEmpInfo> TblEmpInfos { get; set; } = null!;

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer(Configuration.GetConnectionString("DefaultConnection"));
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<TblEmpInfo>(entity =>
            {
                entity.HasKey(e => e.EmpId);

                entity.ToTable("tblEmpInfo");

                entity.Property(e => e.EmpId).HasColumnName("empId");

                entity.Property(e => e.Address)
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.Dept)
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.Property(e => e.EmailId)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Mobile)
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.Property(e => e.Name)
                    .HasMaxLength(20)
                    .IsUnicode(false);
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
