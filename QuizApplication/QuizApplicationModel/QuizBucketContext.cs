using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

#nullable disable

namespace QuizApplicationModel
{
    public partial class QuizBucketContext : DbContext
    {
        public QuizBucketContext()
        {
        }

        public QuizBucketContext(DbContextOptions<QuizBucketContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Question> Questions { get; set; }
        public virtual DbSet<Quiz> Quizzes { get; set; }
        public virtual DbSet<Student> Students { get; set; }
        public virtual DbSet<StudentAnswer> StudentAnswers { get; set; }
        public virtual DbSet<StudentQuiz> StudentQuizzes { get; set; }
        public virtual DbSet<StudentTeacher> StudentTeachers { get; set; }
        public virtual DbSet<Teacher> Teachers { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
                optionsBuilder.UseSqlServer("Data Source=(localdb)\\MSSQLLocalDB;Initial Catalog=QuizBucket;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Question>(entity =>
            {
                entity.Property(e => e.Question1)
                    .HasMaxLength(150)
                    .IsUnicode(false)
                    .HasColumnName("Question");

                entity.HasOne(d => d.Quiz)
                    .WithMany(p => p.Questions)
                    .HasForeignKey(d => d.QuizId)
                    .HasConstraintName("FK__Questions__QuizI__2D27B809");

                entity.HasOne(d => d.Teacher)
                    .WithMany(p => p.Questions)
                    .HasForeignKey(d => d.TeacherId)
                    .HasConstraintName("FK__Questions__Teach__2E1BDC42");
            });

            modelBuilder.Entity<Quiz>(entity =>
            {
                entity.ToTable("Quiz");

                entity.Property(e => e.QuizName)
                    .HasMaxLength(25)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<Student>(entity =>
            {
                entity.Property(e => e.StudentEmail)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.StudentName)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.StudentPassword)
                    .HasMaxLength(16)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<StudentAnswer>(entity =>
            {
                entity.HasKey(e => new { e.StudentId, e.QuestionId });

                entity.Property(e => e.Answer)
                    .HasMaxLength(200)
                    .IsUnicode(false);

                entity.HasOne(d => d.Question)
                    .WithMany(p => p.StudentAnswerQuestions)
                    .HasForeignKey(d => d.QuestionId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__StudentAn__Quest__35BCFE0A");

                entity.HasOne(d => d.Student)
                    .WithMany(p => p.StudentAnswerStudents)
                    .HasForeignKey(d => d.StudentId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__StudentAn__Stude__34C8D9D1");
            });

            modelBuilder.Entity<StudentQuiz>(entity =>
            {
                entity.HasKey(e => new { e.StudentId, e.QuizId });

                entity.ToTable("StudentQuiz");

                entity.HasOne(d => d.Quiz)
                    .WithMany(p => p.StudentQuizQuizzes)
                    .HasForeignKey(d => d.QuizId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__StudentQu__QuizI__31EC6D26");

                entity.HasOne(d => d.Student)
                    .WithMany(p => p.StudentQuizStudents)
                    .HasForeignKey(d => d.StudentId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__StudentQu__Stude__30F848ED");
            });

            modelBuilder.Entity<StudentTeacher>(entity =>
            {
                entity.HasKey(e => new { e.StudentId, e.TeacherId });

                entity.ToTable("StudentTeacher");

                entity.HasOne(d => d.Student)
                    .WithMany(p => p.StudentTeachers)
                    .HasForeignKey(d => d.StudentId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__StudentTe__Stude__276EDEB3");

                entity.HasOne(d => d.Teacher)
                    .WithMany(p => p.StudentTeachers)
                    .HasForeignKey(d => d.TeacherId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__StudentTe__Teach__286302EC");
            });

            modelBuilder.Entity<Teacher>(entity =>
            {
                entity.Property(e => e.TeacherEmail)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.TeacherName)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.TeacherPassword)
                    .HasMaxLength(16)
                    .IsUnicode(false);
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
