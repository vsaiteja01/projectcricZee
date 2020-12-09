using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

#nullable disable

namespace cricZee
{
    public partial class quizzContext : DbContext
    {
        public quizzContext()
        {
        }

        public quizzContext(DbContextOptions<quizzContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Quizz> Quizzs { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
                optionsBuilder.UseSqlServer("Server=tcp:vsaitejaserver.database.windows.net,1433;Initial Catalog=quizz;Persist Security Info=False;User ID=vsaiteja;Password=Teja@199189;MultipleActiveResultSets=False;Encrypt=True;TrustServerCertificate=False;Connection Timeout=30;");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasAnnotation("Relational:Collation", "SQL_Latin1_General_CP1_CI_AS");

            modelBuilder.Entity<Quizz>(entity =>
            {
                entity.ToTable("quizz");

                entity.Property(e => e.QuizzId).ValueGeneratedNever();

                entity.Property(e => e.Correct)
                    .IsRequired()
                    .HasMaxLength(50)
                    .HasColumnName("correct");

                entity.Property(e => e.Option1)
                    .IsRequired()
                    .HasMaxLength(50)
                    .HasColumnName("option1");

                entity.Property(e => e.Option2)
                    .IsRequired()
                    .HasMaxLength(50)
                    .HasColumnName("option2");

                entity.Property(e => e.Option3)
                    .IsRequired()
                    .HasMaxLength(50)
                    .HasColumnName("option3");

                entity.Property(e => e.Option4)
                    .IsRequired()
                    .HasMaxLength(50)
                    .HasColumnName("option4");

                entity.Property(e => e.Ques)
                    .IsRequired()
                    .HasMaxLength(50);
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
