using System;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity;
using System.Linq;

namespace SmartTimetable.Models.DataBaseModels
{
    public partial class SmartTimetableDBContext : DbContext
    {
        public SmartTimetableDBContext()
            : base("name=Server")
        {
        }

        public virtual DbSet<course> course { get; set; }
        public virtual DbSet<dates> dates { get; set; }
        public virtual DbSet<day> day { get; set; }
        public virtual DbSet<group> group { get; set; }
        public virtual DbSet<subject> subject { get; set; }
        public virtual DbSet<teacher> teacher { get; set; }
        public virtual DbSet<times> times { get; set; }
        public virtual DbSet<timetable> timetable { get; set; }
        public virtual DbSet<users> users { get; set; }
        public virtual DbSet<week> week { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<course>()
                .HasMany(e => e.timetable)
                .WithRequired(e => e.course1)
                .HasForeignKey(e => e.Course)
                .WillCascadeOnDelete(true);

            modelBuilder.Entity<dates>()
                .Property(e => e.date)
                .IsUnicode(false);

            modelBuilder.Entity<dates>()
                .HasMany(e => e.timetable)
                .WithRequired(e => e.dates)
                .HasForeignKey(e => e.Date)
                .WillCascadeOnDelete(true);

            modelBuilder.Entity<day>()
                .Property(e => e.name)
                .IsUnicode(false);

            modelBuilder.Entity<day>()
                .HasMany(e => e.timetable)
                .WithRequired(e => e.day1)
                .HasForeignKey(e => e.Day)
                .WillCascadeOnDelete(true);

            modelBuilder.Entity<group>()
                .Property(e => e.name)
                .IsUnicode(false);

            modelBuilder.Entity<group>()
                .HasMany(e => e.timetable)
                .WithRequired(e => e.group1)
                .HasForeignKey(e => e.Group)
                .WillCascadeOnDelete(true);

            modelBuilder.Entity<subject>()
                .Property(e => e.name)
                .IsUnicode(false);

            modelBuilder.Entity<subject>()
                .HasMany(e => e.timetable)
                .WithRequired(e => e.subject1)
                .HasForeignKey(e => e.Subject)
                .WillCascadeOnDelete(true);

            modelBuilder.Entity<teacher>()
                .Property(e => e.name)
                .IsUnicode(false);

            modelBuilder.Entity<teacher>()
                .Property(e => e.mail)
                .IsUnicode(false);

            modelBuilder.Entity<teacher>()
                .HasMany(e => e.timetable)
                .WithRequired(e => e.teacher1)
                .HasForeignKey(e => e.Teacher)
                .WillCascadeOnDelete(true);

            modelBuilder.Entity<times>()
                .Property(e => e.timeFrom)
                .IsUnicode(false);

            modelBuilder.Entity<times>()
                .Property(e => e.timeTo)
                .IsUnicode(false);

            modelBuilder.Entity<times>()
                .HasMany(e => e.timetable)
                .WithRequired(e => e.times)
                .HasForeignKey(e => e.Time)
                .WillCascadeOnDelete(true);

            modelBuilder.Entity<users>()
                .Property(e => e.login)
                .IsUnicode(false);

            modelBuilder.Entity<users>()
                .Property(e => e.password)
                .IsUnicode(false);

            modelBuilder.Entity<users>()
                .Property(e => e.name)
                .IsUnicode(false);

            modelBuilder.Entity<week>()
                .Property(e => e.dateFrom)
                .IsUnicode(false);

            modelBuilder.Entity<week>()
                .Property(e => e.dateTo)
                .IsUnicode(false);

            modelBuilder.Entity<week>()
                .HasMany(e => e.timetable)
                .WithRequired(e => e.week1)
                .HasForeignKey(e => e.Week)
                .WillCascadeOnDelete(true);
        }
    }
}
