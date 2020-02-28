using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace CPS.Models
{
    public partial class CPSContext : DbContext
    {
        public CPSContext()
        {
        }

        public CPSContext(DbContextOptions<CPSContext> options)
            : base(options)
        {
        }

        public virtual DbSet<ExposedPipe> ExposedPipe { get; set; }
        public virtual DbSet<ExposedPipeImage> ExposedPipeImage { get; set; }
        public virtual DbSet<Route> Route { get; set; }
        public virtual DbSet<TestPoint> TestPoint { get; set; }
        public virtual DbSet<Tpimage> Tpimage { get; set; }
        public virtual DbSet<User> User { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. See http://go.microsoft.com/fwlink/?LinkId=723263 for guidance on storing connection strings.
                optionsBuilder.UseMySQL("server=167.71.201.121;database=CPS;user=user;password=Adeveloper13*;");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasAnnotation("ProductVersion", "2.2.6-servicing-10079");

            modelBuilder.Entity<ExposedPipe>(entity =>
            {
                entity.ToTable("ExposedPipe", "CPS");

                entity.HasIndex(e => e.RouteId)
                    .HasName("RouteId");

                entity.HasIndex(e => e.UserId)
                    .HasName("UserId");

                entity.Property(e => e.Id)
                    .HasColumnName("id")
                    .HasColumnType("int(11) unsigned");

                entity.Property(e => e.Notes)
                    .IsRequired()
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.RouteId).HasColumnType("int(10) unsigned");

                entity.Property(e => e.UserId).HasColumnType("int(10) unsigned");

                entity.HasOne(d => d.Route)
                    .WithMany(p => p.ExposedPipe)
                    .HasForeignKey(d => d.RouteId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("ExposedPipe_ibfk_1");

                entity.HasOne(d => d.User)
                    .WithMany(p => p.ExposedPipe)
                    .HasForeignKey(d => d.UserId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("ExposedPipe_ibfk_2");
            });

            modelBuilder.Entity<ExposedPipeImage>(entity =>
            {
                entity.ToTable("ExposedPipeImage", "CPS");

                entity.HasIndex(e => e.ExposedPipeId)
                    .HasName("ExposedPipeId");

                entity.Property(e => e.Id)
                    .HasColumnName("id")
                    .HasColumnType("int(11) unsigned");

                entity.Property(e => e.ExposedPipeId).HasColumnType("int(10) unsigned");

                entity.Property(e => e.Link)
                    .IsRequired()
                    .HasMaxLength(9999)
                    .IsUnicode(false);

                entity.Property(e => e.Notes)
                    .IsRequired()
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.HasOne(d => d.ExposedPipe)
                    .WithMany(p => p.ExposedPipeImage)
                    .HasForeignKey(d => d.ExposedPipeId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("ExposedPipeImage_ibfk_1");
            });

            modelBuilder.Entity<Route>(entity =>
            {
                entity.ToTable("Route", "CPS");

                entity.HasIndex(e => e.UserId)
                    .HasName("RouteCreator");

                entity.Property(e => e.Id)
                    .HasColumnName("id")
                    .HasColumnType("int(11) unsigned");

                entity.Property(e => e.AnodeMaterial)
                    .IsRequired()
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.AnodeMaterialTools)
                    .IsRequired()
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.AnodeMaterialToolsBrand)
                    .IsRequired()
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.CatodicProtectionTools)
                    .IsRequired()
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.CatodicProtectionToolsBrand)
                    .IsRequired()
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.Diameter).HasColumnType("double unsigned");

                entity.Property(e => e.DiameterTools)
                    .IsRequired()
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.DiameterToolsBrand)
                    .IsRequired()
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.Field)
                    .IsRequired()
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.FieldTools)
                    .IsRequired()
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.FieldToolsBrand)
                    .IsRequired()
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.FromRegion)
                    .IsRequired()
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.PipeLengthTools)
                    .IsRequired()
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.PipeLengthToolsBrand)
                    .IsRequired()
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.ProtectionCatodicType)
                    .IsRequired()
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.ToRegion)
                    .IsRequired()
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.UserId).HasColumnType("int(11) unsigned");

                entity.HasOne(d => d.User)
                    .WithMany(p => p.Route)
                    .HasForeignKey(d => d.UserId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("Route_ibfk_1");
            });

            modelBuilder.Entity<TestPoint>(entity =>
            {
                entity.ToTable("TestPoint", "CPS");

                entity.HasIndex(e => e.RouteId)
                    .HasName("RouteId");

                entity.HasIndex(e => e.UserId)
                    .HasName("UserId");

                entity.Property(e => e.Id)
                    .HasColumnName("id")
                    .HasColumnType("int(11) unsigned");

                entity.Property(e => e.LandCorrosivity)
                    .IsRequired()
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.Notes)
                    .IsRequired()
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.RouteId).HasColumnType("int(11) unsigned");

                entity.Property(e => e.UserId).HasColumnType("int(11) unsigned");

                entity.HasOne(d => d.Route)
                    .WithMany(p => p.TestPoint)
                    .HasForeignKey(d => d.RouteId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("TestPoint_ibfk_1");

                entity.HasOne(d => d.User)
                    .WithMany(p => p.TestPoint)
                    .HasForeignKey(d => d.UserId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("TestPoint_ibfk_2");
            });

            modelBuilder.Entity<Tpimage>(entity =>
            {
                entity.ToTable("TPImage", "CPS");

                entity.HasIndex(e => e.TestPointId)
                    .HasName("TestPointId");

                entity.Property(e => e.Id)
                    .HasColumnName("id")
                    .HasColumnType("int(11) unsigned");

                entity.Property(e => e.Link)
                    .IsRequired()
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.Notes)
                    .IsRequired()
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.TestPointId).HasColumnType("int(11) unsigned");

                entity.HasOne(d => d.TestPoint)
                    .WithMany(p => p.Tpimage)
                    .HasForeignKey(d => d.TestPointId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("TPImage_ibfk_1");
            });

            modelBuilder.Entity<User>(entity =>
            {
                entity.ToTable("User", "CPS");

                entity.Property(e => e.Id)
                    .HasColumnName("id")
                    .HasColumnType("int(11) unsigned");

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.Password)
                    .IsRequired()
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.Phone)
                    .IsRequired()
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.Property(e => e.Token)
                    .IsRequired()
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.Username)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false);
            });
        }
    }
}
