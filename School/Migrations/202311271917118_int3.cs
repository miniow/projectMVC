namespace School.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class int3 : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Classes",
                c => new
                    {
                        ClassID = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        TeacherID = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.ClassID)
                .ForeignKey("dbo.Teachers", t => t.TeacherID, cascadeDelete: true)
                .Index(t => t.TeacherID);
            
            CreateTable(
                "dbo.Students",
                c => new
                    {
                        StudentID = c.Int(nullable: false, identity: true),
                        ClassID = c.Int(),
                        Name = c.String(),
                        Surname = c.String(),
                    })
                .PrimaryKey(t => t.StudentID)
                .ForeignKey("dbo.Classes", t => t.ClassID)
                .Index(t => t.ClassID);
            
            CreateTable(
                "dbo.Grades",
                c => new
                    {
                        GradeID = c.Int(nullable: false, identity: true),
                        Value = c.Single(nullable: false),
                        Wieght = c.Single(nullable: false),
                        Comment = c.String(),
                        Date = c.DateTime(nullable: false),
                        TeacherID = c.Int(nullable: false),
                        StudentID = c.Int(nullable: false),
                        SubjectID = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.GradeID)
                .ForeignKey("dbo.Students", t => t.StudentID, cascadeDelete: true)
                .ForeignKey("dbo.Subjects", t => t.SubjectID, cascadeDelete: true)
                .ForeignKey("dbo.Teachers", t => t.TeacherID, cascadeDelete: true)
                .Index(t => t.TeacherID)
                .Index(t => t.StudentID)
                .Index(t => t.SubjectID);
            
            CreateTable(
                "dbo.Subjects",
                c => new
                    {
                        SubjectID = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        Description = c.String(),
                        TeacherID = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.SubjectID)
                .ForeignKey("dbo.Teachers", t => t.TeacherID)
                .Index(t => t.TeacherID);
            
            CreateTable(
                "dbo.Teachers",
                c => new
                    {
                        TeacherID = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        Surname = c.String(),
                    })
                .PrimaryKey(t => t.TeacherID);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Grades", "TeacherID", "dbo.Teachers");
            DropForeignKey("dbo.Subjects", "TeacherID", "dbo.Teachers");
            DropForeignKey("dbo.Classes", "TeacherID", "dbo.Teachers");
            DropForeignKey("dbo.Grades", "SubjectID", "dbo.Subjects");
            DropForeignKey("dbo.Grades", "StudentID", "dbo.Students");
            DropForeignKey("dbo.Students", "ClassID", "dbo.Classes");
            DropIndex("dbo.Subjects", new[] { "TeacherID" });
            DropIndex("dbo.Grades", new[] { "SubjectID" });
            DropIndex("dbo.Grades", new[] { "StudentID" });
            DropIndex("dbo.Grades", new[] { "TeacherID" });
            DropIndex("dbo.Students", new[] { "ClassID" });
            DropIndex("dbo.Classes", new[] { "TeacherID" });
            DropTable("dbo.Teachers");
            DropTable("dbo.Subjects");
            DropTable("dbo.Grades");
            DropTable("dbo.Students");
            DropTable("dbo.Classes");
        }
    }
}
