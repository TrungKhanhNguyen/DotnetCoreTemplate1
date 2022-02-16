using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace DotnetCoreTemplate.Models
{
    public partial class MapOfflineContext : DbContext
    {
        public MapOfflineContext()
        {
        }

        public MapOfflineContext(DbContextOptions<MapOfflineContext> options)
            : base(options)
        {
        }

        public virtual DbSet<LogEvent> LogEvents { get; set; } = null!;
        public virtual DbSet<Member> Members { get; set; } = null!;
        public virtual DbSet<Position> Positions { get; set; } = null!;
        public virtual DbSet<Target> Targets { get; set; } = null!;

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
//#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.

                //optionsBuilder.UseSqlServer("Server=DESKTOP-AEH3E3H; Database=MapOffline; User Id=enofibom; Password=Password1!;");

                //    IConfigurationRoot configuration = new ConfigurationBuilder()
                //.SetBasePath(AppDomain.CurrentDomain.BaseDirectory)
                //.AddJsonFile("appsettings.json")
                //.Build();
                //    optionsBuilder.UseSqlServer(configuration.GetConnectionString("DefaultConnection"));
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<LogEvent>(entity =>
            {
                entity.ToTable("LogEvent");

                entity.Property(e => e.EventDate).HasColumnType("datetime");

                entity.Property(e => e.User).HasMaxLength(50);
            });

            modelBuilder.Entity<Member>(entity =>
            {
                entity.ToTable("Member");

                entity.Property(e => e.Password).HasMaxLength(200);

                entity.Property(e => e.Username).HasMaxLength(50);
            });

            modelBuilder.Entity<Position>(entity =>
            {
                entity.ToTable("Position");

                entity.Property(e => e.AngleEnd).HasMaxLength(50);

                entity.Property(e => e.AngleStart).HasMaxLength(50);

                entity.Property(e => e.Cgi)
                    .HasMaxLength(50)
                    .HasColumnName("CGI");

                entity.Property(e => e.Imei)
                    .HasMaxLength(50)
                    .HasColumnName("IMEI");

                entity.Property(e => e.Imsi)
                    .HasMaxLength(50)
                    .HasColumnName("IMSI");

                entity.Property(e => e.Kind).HasMaxLength(50);

                entity.Property(e => e.Lat).HasMaxLength(50);

                entity.Property(e => e.Lon).HasMaxLength(50);

                entity.Property(e => e.Msisdn)
                    .HasMaxLength(50)
                    .HasColumnName("MSISDN");

                entity.Property(e => e.PlanName).HasMaxLength(50);

                entity.Property(e => e.Radius).HasMaxLength(50);

                entity.Property(e => e.RequestTime).HasColumnType("datetime");
            });

            modelBuilder.Entity<Target>(entity =>
            {
                entity.ToTable("Target");

                entity.Property(e => e.Imei)
                    .HasMaxLength(50)
                    .HasColumnName("IMEI");

                entity.Property(e => e.Imsi)
                    .HasMaxLength(50)
                    .HasColumnName("IMSI");

                entity.Property(e => e.Msisdn)
                    .HasMaxLength(50)
                    .HasColumnName("MSISDN");

                entity.Property(e => e.TargetName).HasMaxLength(100);
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
