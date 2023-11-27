using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;
namespace School.Models
{
    public class SchoolContext :DbContext
    {
        public SchoolContext() : base("MyCS") { }
        public DbSet<Account> Accounts {  get; set; }
        public DbSet<Student> Students { get; set; }
        public DbSet<Teacher> Teachers { get; set; }
        public DbSet<Class> Classes { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);


            //modelBuilder.Entity<Student>()
            //  .HasOne(s => s.Class)
            //  .WithMany(c => c.Students)
            //  .HasForeignKey(s => s.ClassID);


            modelBuilder.Entity<Subject>()
                .HasRequired(s=>s.Teacher)
                .WithMany(t=> (ICollection<Subject>)t.Grades)
                .HasForeignKey(s=>s.TeacherID)
                .WillCascadeOnDelete(false);


            

        }

        public System.Data.Entity.DbSet<School.Models.Grade> Grades { get; set; }

        public System.Data.Entity.DbSet<School.Models.Subject> Subjects { get; set; }
    }
}