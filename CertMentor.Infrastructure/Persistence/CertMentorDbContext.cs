using System.Text.Json;
using CertMentor.Domain.Entities.Catalog;
using CertMentor.Domain.Entities.Exam;
using Microsoft.EntityFrameworkCore;

namespace CertMentor.Infrastructure.Persistence
{
    public class CertMentorDbContext : DbContext
    {
        public DbSet<Certification> Certifications => Set<Certification>();
        public DbSet<SkillArea> SkillAreas => Set<SkillArea>();
        public DbSet<Topic> Topics => Set<Topic>();
        public DbSet<ExamSession> ExamSessions => Set<ExamSession>();
        public DbSet<ExamQuestion> ExamQuestions => Set<ExamQuestion>();
        public DbSet<UserAnswer> UserAnswers => Set<UserAnswer>();
        public DbSet<PerformanceRecord> PerformanceRecords => Set<PerformanceRecord>();
        public DbSet<SkillAreaScore> SkillAreaScores => Set<SkillAreaScore>();
        public DbSet<StudyPlan> StudyPlans => Set<StudyPlan>();
        public DbSet<StudyPlanItem> StudyPlanItems => Set<StudyPlanItem>();

        public CertMentorDbContext(DbContextOptions<CertMentorDbContext> options)
            : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<Certification>(c =>
            {
                c.ToTable("Certifications");
                c.Property(c => c.Code).HasColumnType("nvarchar(30)");
                c.Property(c => c.Name).HasColumnType("nvarchar(100)");
                c.Property(c => c.IsActive).HasDefaultValue(true);
            });
            modelBuilder.Entity<SkillArea>(sa =>
            {
                sa.ToTable("SkillAreas");
                sa.Property(sa => sa.Name).HasColumnType("nvarchar(100)");
            });
            modelBuilder.Entity<Topic>(t =>
            {
                t.ToTable("Topics");
                t.Property(t => t.Name).HasColumnType("nvarchar(100)");
                t.Property(t => t.Description).HasColumnType("nvarchar(200)");
            });
            modelBuilder.Entity<ExamSession>(es =>
            {
                es.ToTable("ExamSessions");
                es.Property(es => es.Status).HasConversion<string>().HasColumnType("nvarchar(20)");
            });
            modelBuilder.Entity<ExamQuestion>(eq =>
            {
                eq.ToTable("ExamQuestions");
                eq.Property(eq => eq.Type).HasConversion<string>().HasColumnType("nvarchar(20)");
                eq.Property(eq => eq.Question).HasColumnType("nvarchar(1000)");
                eq.Property<List<string>>("_answers")
                    .HasColumnName("Answers")
                    .HasConversion(
                        v => JsonSerializer.Serialize(v, (JsonSerializerOptions)null!),
                        v => JsonSerializer.Deserialize<List<string>>(v, (JsonSerializerOptions)null!) ?? new List<string>())
                    .HasColumnType("nvarchar(max)");
                eq.Property<List<string>>("_correctAnswers")
                    .HasColumnName("CorrectAnswers")
                    .HasConversion(
                        v => JsonSerializer.Serialize(v, (JsonSerializerOptions)null!),
                        v => JsonSerializer.Deserialize<List<string>>(v, (JsonSerializerOptions)null!) ?? new List<string>())
                    .HasColumnType("nvarchar(max)");
            });
            modelBuilder.Entity<UserAnswer>(ua =>
            {
                ua.ToTable("UserAnswers");
                ua.Property(ua => ua.IsCorrect).HasDefaultValue(false);
                ua.Property<List<string>>("_answers")
                    .HasColumnName("Answers")
                    .HasConversion(
                        v => JsonSerializer.Serialize(v, (JsonSerializerOptions)null!),
                        v => JsonSerializer.Deserialize<List<string>>(v, (JsonSerializerOptions)null!) ?? new List<string>())
                    .HasColumnType("nvarchar(max)");
            });
            modelBuilder.Entity<PerformanceRecord>(pr =>
            {
                pr.ToTable("PerformanceRecords");
            });
            modelBuilder.Entity<SkillAreaScore>(sas =>
            {
                sas.ToTable("SkillAreaScores");
            });
            modelBuilder.Entity<StudyPlan>(sp =>
            {
                sp.ToTable("StudyPlans");
            });
            modelBuilder.Entity<StudyPlanItem>(spi =>
            {
                spi.ToTable("StudyPlanItems");
                spi.Property(spi => spi.MicrosoftLearnUnit).HasColumnType("nvarchar(500)");
                spi.Property(spi => spi.IsCompleted).HasDefaultValue(false);
            });
        }
    }
}
