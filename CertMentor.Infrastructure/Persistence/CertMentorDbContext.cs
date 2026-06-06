using System.Text.Json;
using CertMentor.Domain.Entities.Catalog;
using CertMentor.Domain.Entities.Exam;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;

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

            var stringListComparer = new ValueComparer<List<string>>(
                (c1, c2) => c1!.SequenceEqual(c2!),
                c => c.Aggregate(0, (a, v) => HashCode.Combine(a, v.GetHashCode())),
                c => c.ToList());

            modelBuilder.Entity<Certification>(c =>
            {
                c.ToTable("Certifications");
                c.Property(c => c.Code).HasColumnType("nvarchar(200)");
                c.Property(c => c.Name).HasColumnType("nvarchar(300)");
                c.Property(c => c.ExamDurationInMinutes).HasColumnType("tinyint");
                c.Property(c => c.IsActive).HasDefaultValue(true);
            });
            modelBuilder.Entity<SkillArea>(sa =>
            {
                sa.ToTable("SkillAreas");
                sa.Property(sa => sa.Name).HasColumnType("nvarchar(300)");
                sa.Property(sa => sa.IsActive).HasDefaultValue(true);
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
                eq.HasOne(e => e.Topic)
                  .WithMany()
                  .HasForeignKey(e => e.TopicId)
                  .OnDelete(DeleteBehavior.NoAction);
                eq.Property<List<string>>("_answers")
                    .HasColumnName("Answers")
                    .HasConversion(
                        v => JsonSerializer.Serialize(v, (JsonSerializerOptions)null!),
                        v => JsonSerializer.Deserialize<List<string>>(v, (JsonSerializerOptions)null!) ?? new List<string>())
                    .HasColumnType("nvarchar(max)")
                    .Metadata.SetValueComparer(stringListComparer);
                eq.Property<List<string>>("_correctAnswers")
                    .HasColumnName("CorrectAnswers")
                    .HasConversion(
                        v => JsonSerializer.Serialize(v, (JsonSerializerOptions)null!),
                        v => JsonSerializer.Deserialize<List<string>>(v, (JsonSerializerOptions)null!) ?? new List<string>())
                    .HasColumnType("nvarchar(max)")
                    .Metadata.SetValueComparer(stringListComparer);
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
                    .HasColumnType("nvarchar(max)")
                    .Metadata.SetValueComparer(stringListComparer);
            });
            modelBuilder.Entity<PerformanceRecord>(pr =>
            {
                pr.ToTable("PerformanceRecords");
            });
            modelBuilder.Entity<SkillAreaScore>(sas =>
            {
                sas.ToTable("SkillAreaScores");
                sas.HasOne(s => s.SkillArea)
                   .WithMany()
                   .HasForeignKey(s => s.SkillAreaId)
                   .OnDelete(DeleteBehavior.NoAction);
            });
            modelBuilder.Entity<StudyPlan>(sp =>
            {
                sp.ToTable("StudyPlans");
                sp.HasOne(sp => sp.Certification)
                  .WithMany()
                  .HasForeignKey(sp => sp.CertificationId)
                  .OnDelete(DeleteBehavior.NoAction);
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
