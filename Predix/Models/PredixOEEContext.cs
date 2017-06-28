using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace Predix.Models
{
    public partial class PredixOEEContext : DbContext
    {
        public virtual DbSet<Equipement> Equipement { get; set; }
        public virtual DbSet<Ligneprod> Ligneprod { get; set; }
        public virtual DbSet<Oeedowntime> Oeedowntime { get; set; }
        public virtual DbSet<Pays> Pays { get; set; }
        public virtual DbSet<Raison> Raison { get; set; }
        public virtual DbSet<Typeequipement> Typeequipement { get; set; }
        public virtual DbSet<Typesite> Typesite { get; set; }
        public virtual DbSet<Ville> Ville { get; set; }

        public PredixOEEContext(DbContextOptions<PredixOEEContext> options)
            : base(options)
        { }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Equipement>(entity =>
            {
                entity.ToTable("EQUIPEMENT");

                entity.Property(e => e.EquipementId).HasColumnName("equipementID");

                entity.Property(e => e.Libelle)
                    .HasColumnName("libelle")
                    .HasColumnType("varchar(25)");

                entity.Property(e => e.TypeequipementId).HasColumnName("typeequipementID");

                entity.HasOne(d => d.Typeequipement)
                    .WithMany(p => p.Equipement)
                    .HasForeignKey(d => d.TypeequipementId)
                    .HasConstraintName("FK__EQUIPEMEN__typee__20C1E124");
            });

            modelBuilder.Entity<Ligneprod>(entity =>
            {
                entity.ToTable("LIGNEPROD");

                entity.Property(e => e.LigneprodId).HasColumnName("ligneprodID");

                entity.Property(e => e.Libelle)
                    .HasColumnName("libelle")
                    .HasColumnType("varchar(25)");

                entity.Property(e => e.TypesiteId).HasColumnName("typesiteID");

                entity.HasOne(d => d.Typesite)
                    .WithMany(p => p.Ligneprod)
                    .HasForeignKey(d => d.TypesiteId)
                    .HasConstraintName("FK__LIGNEPROD__types__182C9B23");
            });

            modelBuilder.Entity<Oeedowntime>(entity =>
            {
                entity.ToTable("OEEDOWNTIME");

                entity.Property(e => e.OeedowntimeId).HasColumnName("oeedowntimeID");

                entity.Property(e => e.Commentaire)
                    .HasColumnName("commentaire")
                    .HasColumnType("varchar(200)");

                entity.Property(e => e.DateDebut)
                    .HasColumnName("dateDebut")
                    .HasColumnType("datetime");

                entity.Property(e => e.DateFin)
                    .HasColumnName("dateFin")
                    .HasColumnType("datetime");

                entity.Property(e => e.Duree).HasColumnName("duree");

                entity.Property(e => e.EquipementId).HasColumnName("equipementID");

                entity.HasOne(d => d.Equipement)
                    .WithMany(p => p.Oeedowntime)
                    .HasForeignKey(d => d.EquipementId)
                    .HasConstraintName("FK__OEEDOWNTI__equip__239E4DCF");
            });

            modelBuilder.Entity<Pays>(entity =>
            {
                entity.ToTable("PAYS");

                entity.Property(e => e.PaysId).HasColumnName("paysID");

                entity.Property(e => e.Libelle)
                    .HasColumnName("libelle")
                    .HasColumnType("varchar(25)");
            });

            modelBuilder.Entity<Raison>(entity =>
            {
                entity.ToTable("RAISON");

                entity.Property(e => e.RaisonId).HasColumnName("raisonID");

                entity.Property(e => e.Description)
                    .HasColumnName("description")
                    .HasColumnType("varchar(25)");

                entity.Property(e => e.TypeequipementId).HasColumnName("typeequipementID");

                entity.HasOne(d => d.Typeequipement)
                    .WithMany(p => p.Raison)
                    .HasForeignKey(d => d.TypeequipementId)
                    .HasConstraintName("FK__RAISON__typeequi__1DE57479");
            });

            modelBuilder.Entity<Typeequipement>(entity =>
            {
                entity.ToTable("TYPEEQUIPEMENT");

                entity.Property(e => e.TypeequipementId).HasColumnName("typeequipementID");

                entity.Property(e => e.Libelle)
                    .HasColumnName("libelle")
                    .HasColumnType("varchar(25)");

                entity.Property(e => e.LigneprodId).HasColumnName("ligneprodID");

                entity.HasOne(d => d.Ligneprod)
                    .WithMany(p => p.Typeequipement)
                    .HasForeignKey(d => d.LigneprodId)
                    .HasConstraintName("FK__TYPEEQUIP__ligne__1B0907CE");
            });

            modelBuilder.Entity<Typesite>(entity =>
            {
                entity.ToTable("TYPESITE");

                entity.Property(e => e.TypesiteId).HasColumnName("typesiteID");

                entity.Property(e => e.Libelle)
                    .HasColumnName("libelle")
                    .HasColumnType("varchar(25)");

                entity.Property(e => e.VilleId).HasColumnName("villeID");

                entity.HasOne(d => d.Ville)
                    .WithMany(p => p.Typesite)
                    .HasForeignKey(d => d.VilleId)
                    .HasConstraintName("FK__TYPESITE__villeI__15502E78");
            });

            modelBuilder.Entity<Ville>(entity =>
            {
                entity.ToTable("VILLE");

                entity.Property(e => e.VilleId).HasColumnName("villeID");

                entity.Property(e => e.Libelle)
                    .HasColumnName("libelle")
                    .HasColumnType("varchar(25)");

                entity.Property(e => e.PaysId).HasColumnName("paysID");

                entity.HasOne(d => d.Pays)
                    .WithMany(p => p.Ville)
                    .HasForeignKey(d => d.PaysId)
                    .HasConstraintName("FK__VILLE__paysID__1273C1CD");
            });
        }
    }
}