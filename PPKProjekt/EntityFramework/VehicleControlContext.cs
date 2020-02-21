using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace PPKProjekt.EntityFramework
{
    public partial class VehicleControlContext : DbContext
    {
        public VehicleControlContext()
        {
        }

        public VehicleControlContext(DbContextOptions<VehicleControlContext> options)
            : base(options)
        {
        }

        public virtual DbSet<TblKupnjaGoriva> TblKupnjaGoriva { get; set; }
        public virtual DbSet<TblPutniNalog> TblPutniNalog { get; set; }
        public virtual DbSet<TblRuta> TblRuta { get; set; }
        public virtual DbSet<TblServis> TblServis { get; set; }
        public virtual DbSet<TblServisStavka> TblServisStavka { get; set; }
        public virtual DbSet<TblVozac> TblVozac { get; set; }
        public virtual DbSet<TblVozilo> TblVozilo { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer("Server=.\\SQLEXPRESS;Database=VehicleControl;Trusted_Connection=True;");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<TblKupnjaGoriva>(entity =>
            {
                entity.HasKey(e => e.IdkupnjaGoriva);

                entity.ToTable("tblKupnjaGoriva");

                entity.Property(e => e.IdkupnjaGoriva).HasColumnName("IDKupnjaGoriva");

                entity.Property(e => e.Lokacija).HasMaxLength(100);

                entity.Property(e => e.PutniNalogId).HasColumnName("PutniNalogID");

                entity.HasOne(d => d.PutniNalog)
                    .WithMany(p => p.TblKupnjaGoriva)
                    .HasForeignKey(d => d.PutniNalogId)
                    .OnDelete(DeleteBehavior.Cascade)
                    .HasConstraintName("FK__tblKupnja__Putni");
            });

            modelBuilder.Entity<TblPutniNalog>(entity =>
            {
                entity.HasKey(e => e.IdputniNalog);

                entity.ToTable("tblPutniNalog");

                entity.Property(e => e.IdputniNalog).HasColumnName("IDPutniNalog");

                entity.Property(e => e.StartDate).HasColumnType("date");

                entity.Property(e => e.StartGrad).HasMaxLength(50);

                entity.Property(e => e.StopDate).HasColumnType("date");

                entity.Property(e => e.StopGrad).HasMaxLength(50);

                entity.Property(e => e.VozacId).HasColumnName("VozacID");

                entity.Property(e => e.VoziloId).HasColumnName("VoziloID");

                entity.HasOne(d => d.Vozac)
                    .WithMany(p => p.TblPutniNalog)
                    .HasForeignKey(d => d.VozacId)
                    .HasConstraintName("FK__tblPutniN__Vozac__49C3F6B7");

                entity.HasOne(d => d.Vozilo)
                    .WithMany(p => p.TblPutniNalog)
                    .HasForeignKey(d => d.VoziloId)
                    .HasConstraintName("FK__tblPutniN__Vozil__4AB81AF0");
            });

            modelBuilder.Entity<TblRuta>(entity =>
            {
                entity.HasKey(e => e.Idruta);

                entity.ToTable("tblRuta");

                entity.Property(e => e.Idruta).HasColumnName("IDRuta");

                entity.Property(e => e.AcoordX).HasColumnName("ACoordX");

                entity.Property(e => e.AcoordY).HasColumnName("ACoordY");

                entity.Property(e => e.BcoordX).HasColumnName("BCoordX");

                entity.Property(e => e.BcoordY).HasColumnName("BCoordY");

                entity.Property(e => e.PrijedeniKm).HasColumnName("PrijedeniKM");

                entity.Property(e => e.ProsjecniKmh).HasColumnName("ProsjecniKMH");

                entity.Property(e => e.PutniNalogId).HasColumnName("PutniNalogID");

                entity.Property(e => e.Vrijeme).HasColumnType("datetime");

                entity.HasOne(d => d.PutniNalog)
                    .WithMany(p => p.TblRuta)
                    .HasForeignKey(d => d.PutniNalogId)
                    .OnDelete(DeleteBehavior.Cascade)
                    .HasConstraintName("FK_tblRUTA_TblPUTNINALOG");
            });

            modelBuilder.Entity<TblServis>(entity =>
            {
                entity.HasKey(e => e.Idservis);

                entity.ToTable("tblServis");

                entity.Property(e => e.Idservis).HasColumnName("IDServis");

                entity.Property(e => e.Datum).HasColumnType("date");

                entity.Property(e => e.Naziv).HasMaxLength(50);

                entity.Property(e => e.Opis).HasMaxLength(250);

                entity.Property(e => e.ServisStavkaId).HasColumnName("ServisStavkaID");

                entity.Property(e => e.VoziloId).HasColumnName("VoziloID");

                entity.HasOne(d => d.ServisStavka)
                    .WithMany(p => p.TblServis)
                    .HasForeignKey(d => d.ServisStavkaId)
                    .HasConstraintName("FK__tblServis__Servi__208CD6FA");

                entity.HasOne(d => d.Vozilo)
                    .WithMany(p => p.TblServis)
                    .HasForeignKey(d => d.VoziloId)
                    .HasConstraintName("FK__tblServis__Vozil__1F98B2C1");
            });

            modelBuilder.Entity<TblServisStavka>(entity =>
            {
                entity.HasKey(e => e.IdservisStavka);

                entity.ToTable("tblServisStavka");

                entity.Property(e => e.IdservisStavka).HasColumnName("IDServisStavka");

                entity.Property(e => e.Naziv).HasMaxLength(50);
            });

            modelBuilder.Entity<TblVozac>(entity =>
            {
                entity.HasKey(e => e.Idvozac);

                entity.ToTable("tblVozac");

                entity.Property(e => e.Idvozac).HasColumnName("IDVozac");

                entity.Property(e => e.BrojMobitela).HasMaxLength(50);

                entity.Property(e => e.Ime).HasMaxLength(50);

                entity.Property(e => e.Prezime).HasMaxLength(50);

                entity.Property(e => e.SerijskiBrojVozacke).HasMaxLength(8);
            });

            modelBuilder.Entity<TblVozilo>(entity =>
            {
                entity.HasKey(e => e.Idvozilo);

                entity.ToTable("tblVozilo");

                entity.Property(e => e.Idvozilo).HasColumnName("IDVozilo");

                entity.Property(e => e.GodinaProizvodnje).HasColumnType("datetime");

                entity.Property(e => e.InicijalniKm).HasColumnName("InicijalniKM");

                entity.Property(e => e.Marka).HasMaxLength(50);

                entity.Property(e => e.Tip).HasMaxLength(50);
            });
        }
    }
}
