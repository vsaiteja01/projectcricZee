using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

#nullable disable

namespace cricZee.Models
{
    public partial class projectContext : DbContext
    {
        public projectContext()
        {
        }

        public projectContext(DbContextOptions<projectContext> options)
            : base(options)
        {
        }

        public virtual DbSet<ChennaiSuperKing> ChennaiSuperKings { get; set; }
        public virtual DbSet<DelhiCapital> DelhiCapitals { get; set; }
        public virtual DbSet<KingsXipunjab> KingsXipunjabs { get; set; }
        public virtual DbSet<KolkataKnightRider> KolkataKnightRiders { get; set; }
        public virtual DbSet<Match> Matches { get; set; }
        public virtual DbSet<MumbaiIndian> MumbaiIndians { get; set; }
        public virtual DbSet<PointsTable> PointsTables { get; set; }
        public virtual DbSet<RajasthanRoyal> RajasthanRoyals { get; set; }
        public virtual DbSet<RoyalChallengersBanglore> RoyalChallengersBanglores { get; set; }
        public virtual DbSet<SunRisesHyderabad> SunRisesHyderabads { get; set; }
        public virtual DbSet<TopBatsmen> TopBatsmens { get; set; }
        public virtual DbSet<TopBowler> TopBowlers { get; set; }
        public virtual DbSet<TopFielder> TopFielders { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
                optionsBuilder.UseSqlServer("Server=tcp:vsaitejaserver.database.windows.net,1433;Initial Catalog=project;Persist Security Info=False;User ID=vsaiteja;Password=Teja@199189;MultipleActiveResultSets=False;Encrypt=True;TrustServerCertificate=False;Connection Timeout=30;");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasAnnotation("Relational:Collation", "SQL_Latin1_General_CP1_CI_AS");

            modelBuilder.Entity<ChennaiSuperKing>(entity =>
            {
                entity.HasKey(e => e.Player)
                    .HasName("PK__ChennaiS__7CA37A1F6C8B76E2");

                entity.Property(e => e.Player).HasMaxLength(50);

                entity.Property(e => e.PlayerId).ValueGeneratedOnAdd();

                entity.Property(e => e.PlayerRole).HasMaxLength(50);

                entity.Property(e => e.Price).HasMaxLength(50);
            });

            modelBuilder.Entity<DelhiCapital>(entity =>
            {
                entity.HasKey(e => e.Player)
                    .HasName("PK__DelhiCap__7CA37A1F2C1CCA8A");

                entity.Property(e => e.Player).HasMaxLength(50);

                entity.Property(e => e.PlayerId).ValueGeneratedOnAdd();

                entity.Property(e => e.PlayerRole).HasMaxLength(50);

                entity.Property(e => e.Price).HasMaxLength(50);
            });

            modelBuilder.Entity<KingsXipunjab>(entity =>
            {
                entity.HasKey(e => e.Player)
                    .HasName("PK__KingsXIP__7CA37A1FD2BD9F5A");

                entity.ToTable("KingsXIPunjab");

                entity.Property(e => e.Player).HasMaxLength(50);

                entity.Property(e => e.PlayerId).ValueGeneratedOnAdd();

                entity.Property(e => e.PlayerRole).HasMaxLength(50);

                entity.Property(e => e.Price).HasMaxLength(50);
            });

            modelBuilder.Entity<KolkataKnightRider>(entity =>
            {
                entity.HasKey(e => e.Player)
                    .HasName("PK__KolkataK__7CA37A1FAB3F9D28");

                entity.Property(e => e.Player).HasMaxLength(50);

                entity.Property(e => e.PlayerId).ValueGeneratedOnAdd();

                entity.Property(e => e.PlayerRole).HasMaxLength(50);

                entity.Property(e => e.Price).HasMaxLength(50);
            });

            modelBuilder.Entity<Match>(entity =>
            {
                entity.Property(e => e.MatchId).ValueGeneratedNever();

                entity.Property(e => e.Result)
                    .HasMaxLength(50)
                    .HasColumnName("result");

                entity.Property(e => e.Team1).HasMaxLength(50);

                entity.Property(e => e.Team2).HasMaxLength(50);
            });

            modelBuilder.Entity<MumbaiIndian>(entity =>
            {
                entity.HasKey(e => e.Player)
                    .HasName("PK__MumbaiIn__7CA37A1F934FDE87");

                entity.Property(e => e.Player).HasMaxLength(50);

                entity.Property(e => e.PlayerId).ValueGeneratedOnAdd();

                entity.Property(e => e.PlayerRole).HasMaxLength(50);

                entity.Property(e => e.Price).HasMaxLength(50);
            });

            modelBuilder.Entity<PointsTable>(entity =>
            {
                entity.HasKey(e => e.Teams)
                    .HasName("PK__PointsTa__5709C6D589843B6C");

                entity.ToTable("PointsTable");

                entity.Property(e => e.Teams).HasMaxLength(50);

                entity.Property(e => e.Nrr)
                    .HasMaxLength(50)
                    .HasColumnName("NRR");

                entity.Property(e => e.Nrrposition).HasColumnName("NRRPosition");

                entity.Property(e => e.TeamId).ValueGeneratedOnAdd();
            });

            modelBuilder.Entity<RajasthanRoyal>(entity =>
            {
                entity.HasKey(e => e.Player)
                    .HasName("PK__Rajastha__7CA37A1F86B9278C");

                entity.Property(e => e.Player).HasMaxLength(50);

                entity.Property(e => e.PlayerId).ValueGeneratedOnAdd();

                entity.Property(e => e.PlayerRole).HasMaxLength(50);

                entity.Property(e => e.Price).HasMaxLength(50);
            });

            modelBuilder.Entity<RoyalChallengersBanglore>(entity =>
            {
                entity.HasKey(e => e.Player)
                    .HasName("PK__RoyalCha__7CA37A1F30AD4EC9");

                entity.ToTable("RoyalChallengersBanglore");

                entity.Property(e => e.Player).HasMaxLength(50);

                entity.Property(e => e.PlayerId).ValueGeneratedOnAdd();

                entity.Property(e => e.PlayerRole).HasMaxLength(50);

                entity.Property(e => e.Price).HasMaxLength(50);
            });

            modelBuilder.Entity<SunRisesHyderabad>(entity =>
            {
                entity.HasKey(e => e.Player)
                    .HasName("PK__SunRises__7CA37A1F0A540A47");

                entity.ToTable("SunRisesHyderabad");

                entity.Property(e => e.Player).HasMaxLength(50);

                entity.Property(e => e.PlayerId).ValueGeneratedOnAdd();

                entity.Property(e => e.PlayerRole).HasMaxLength(50);

                entity.Property(e => e.Price).HasMaxLength(50);
            });

            modelBuilder.Entity<TopBatsmen>(entity =>
            {
                entity.HasKey(e => e.Player)
                    .HasName("PK__TopBatsm__7CA37A1F67C76ECC");

                entity.Property(e => e.Player).HasMaxLength(50);

                entity.Property(e => e.PlayerId).ValueGeneratedOnAdd();
            });

            modelBuilder.Entity<TopBowler>(entity =>
            {
                entity.HasKey(e => e.Player)
                    .HasName("PK__TopBowle__7CA37A1F9380AEFD");

                entity.Property(e => e.Player).HasMaxLength(50);

                entity.Property(e => e.PlayerId).ValueGeneratedOnAdd();
            });

            modelBuilder.Entity<TopFielder>(entity =>
            {
                entity.HasKey(e => e.Player)
                    .HasName("PK__TopField__7CA37A1F1825CC1C");

                entity.Property(e => e.Player).HasMaxLength(50);

                entity.Property(e => e.PlayerId).ValueGeneratedOnAdd();
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
