using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

#nullable disable

namespace TamaguchiClasses.Models
{
    public partial class TryTamaContext : DbContext
    {
        public TryTamaContext()
        {
        }

        public TryTamaContext(DbContextOptions<TryTamaContext> options)
            : base(options)
        {
        }

        public virtual DbSet<ActionInfo> ActionInfos { get; set; }
        public virtual DbSet<ActionsHistory> ActionsHistories { get; set; }
        public virtual DbSet<LifeSpan> LifeSpans { get; set; }
        public virtual DbSet<LifeStatus> LifeStatuses { get; set; }
        public virtual DbSet<Pet> Pets { get; set; }
        public virtual DbSet<Player> Players { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
//#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
                optionsBuilder.UseSqlServer("Server = localhost\\SQLEXPRESS; Database=TryTama; Trusted_Connection=true");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<ActionsHistory>(entity =>
            {
                entity.HasKey(e => e.ActionHistoryId)
                    .HasName("PK__ActionsH__F37F5B38410C2A6C");

                entity.HasOne(d => d.Action)
                    .WithMany(p => p.ActionsHistories)
                    .HasForeignKey(d => d.ActionId)
                    .HasConstraintName("FK_ActionsHistory_ActionInfo");

                entity.HasOne(d => d.LifeSpan)
                    .WithMany(p => p.ActionsHistories)
                    .HasForeignKey(d => d.LifeSpanId)
                    .HasConstraintName("FK_ActionsHistory_lifeSpan");

                entity.HasOne(d => d.Pet)
                    .WithMany(p => p.ActionsHistories)
                    .HasForeignKey(d => d.PetId)
                    .HasConstraintName("FK_ActionsHistory_PET");
            });

            modelBuilder.Entity<Pet>(entity =>
            {
                entity.HasOne(d => d.Lifespan)
                    .WithMany(p => p.Pets)
                    .HasForeignKey(d => d.Lifespanid)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_PET_lifeSpan");

                entity.HasOne(d => d.Lifestatus)
                    .WithMany(p => p.Pets)
                    .HasForeignKey(d => d.Lifestatusid)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_PET_LifeStatus");

                entity.HasOne(d => d.Owner)
                    .WithMany(p => p.Pets)
                    .HasForeignKey(d => d.Ownerid)
                    .HasConstraintName("FK_PET_Player");
            });

            modelBuilder.Entity<Player>(entity =>
            {
                entity.HasOne(d => d.Activepet)
                    .WithMany(p => p.Players)
                    .HasForeignKey(d => d.Activepetid)
                    .HasConstraintName("FK_Player_PET1");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
