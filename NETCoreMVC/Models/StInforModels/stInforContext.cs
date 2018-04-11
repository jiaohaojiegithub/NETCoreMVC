using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace NETCoreMVC.Models.StInforModels
{
    public partial class stInforContext : DbContext
    {
        public virtual DbSet<Course> Course { get; set; }
        public virtual DbSet<Score> Score { get; set; }
        public virtual DbSet<Student> Student { get; set; }

        //        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        //        {
        //            if (!optionsBuilder.IsConfigured)
        //            {
        //#warning To protect potentially sensitive information in your connection string, you should move it out of source code. See http://go.microsoft.com/fwlink/?LinkId=723263 for guidance on storing connection strings.
        //                optionsBuilder.UseSqlServer(@"Data Source=.;Initial Catalog=stInfor;Integrated Security=True;");
        //            }
        //        }//不安全的连接方式
        public stInforContext(DbContextOptions<stInforContext> options) : base(options)
        {
        }//添加以下构造函数，这将允许通过依赖关系注入将配置传递到上下文中
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Course>(entity =>
            {
                entity.Property(e => e.Id)
                    .HasColumnName("id")
                    .HasColumnType("char(10)")
                    .ValueGeneratedNever();

                entity.Property(e => e.Credit).HasColumnName("credit");

                entity.Property(e => e.Name)
                    .HasColumnName("name")
                    .HasColumnType("nchar(50)");
            });

            modelBuilder.Entity<Score>(entity =>
            {
                entity.HasKey(e => new { e.CourseId, e.StudentId });

                entity.ToTable("score");

                entity.Property(e => e.CourseId).HasColumnType("nchar(10)");

                entity.Property(e => e.StudentId).HasColumnType("nchar(10)");

                entity.Property(e => e.Score1).HasColumnName("score");
            });

            modelBuilder.Entity<Student>(entity =>
            {
                entity.ToTable("student");

                entity.Property(e => e.Id)
                    .HasColumnName("id")
                    .HasColumnType("nchar(10)")
                    .ValueGeneratedNever();

                entity.Property(e => e.Age).HasColumnName("age");

                entity.Property(e => e.Dept)
                    .HasColumnName("dept")
                    .HasColumnType("nchar(30)");

                entity.Property(e => e.Name)
                    .HasColumnName("name")
                    .HasColumnType("nchar(20)");

                entity.Property(e => e.Sex)
                    .HasColumnName("sex")
                    .HasColumnType("nchar(10)");
            });
        }
    }
}
