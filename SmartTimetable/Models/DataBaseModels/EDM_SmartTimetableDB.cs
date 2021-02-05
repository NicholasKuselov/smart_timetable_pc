using System;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity;
using System.Linq;

namespace SmartTimetable
{
    public partial class EDM_SmartTimetableDB : DbContext
    {
        public EDM_SmartTimetableDB()
            : base("name=EDM_SmartTimetableDB")
        {
            
        }

        public virtual DbSet<course> course { get; set; }
        public virtual DbSet<day> day { get; set; }
        public virtual DbSet<group> group { get; set; }
        public virtual DbSet<subject> subject { get; set; }
        public virtual DbSet<teacher> teacher { get; set; }
        public virtual DbSet<timetable> timetable { get; set; }
        public virtual DbSet<users> users { get; set; }
        public virtual DbSet<week> week { get; set; }
 
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<course>()
                .HasMany(e => e.timetable)
                .WithRequired(e => e.course1)
                .HasForeignKey(e => e.Course)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<day>()
                .Property(e => e.name)
                .IsUnicode(false);

            modelBuilder.Entity<day>()
                .HasMany(e => e.timetable)
                .WithRequired(e => e.day1)
                .HasForeignKey(e => e.Day)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<group>()
                .Property(e => e.name)
                .IsUnicode(false);

            modelBuilder.Entity<group>()
                .HasMany(e => e.timetable)
                .WithRequired(e => e.group1)
                .HasForeignKey(e => e.Group)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<subject>()
                .Property(e => e.name)
                .IsUnicode(false);

            modelBuilder.Entity<subject>()
                .HasMany(e => e.timetable)
                .WithRequired(e => e.subject1)
                .HasForeignKey(e => e.Subject)
                .WillCascadeOnDelete(false);

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
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<timetable>()
                .Property(e => e.Date)
                .IsUnicode(false);

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
                .WillCascadeOnDelete(false);
        }
    }
}
