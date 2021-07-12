namespace _1811063058_KhoaVuHongNgoc.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class fixDataBase : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Courses", "Lecture_Id", "dbo.AspNetUsers");
            DropIndex("dbo.Courses", new[] { "Lecture_Id" });
            RenameColumn(table: "dbo.Courses", name: "Lecture_Id", newName: "LecturerId");
            AlterColumn("dbo.Categories", "Name", c => c.String(nullable: false, maxLength: 255));
            AlterColumn("dbo.Courses", "LecturerId", c => c.String(nullable: false, maxLength: 128));
            CreateIndex("dbo.Courses", "LecturerId");
            AddForeignKey("dbo.Courses", "LecturerId", "dbo.AspNetUsers", "Id", cascadeDelete: true);
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Courses", "LecturerId", "dbo.AspNetUsers");
            DropIndex("dbo.Courses", new[] { "LecturerId" });
            AlterColumn("dbo.Courses", "LecturerId", c => c.String(maxLength: 128));
            AlterColumn("dbo.Categories", "Name", c => c.String());
            RenameColumn(table: "dbo.Courses", name: "LecturerId", newName: "Lecture_Id");
            CreateIndex("dbo.Courses", "Lecture_Id");
            AddForeignKey("dbo.Courses", "Lecture_Id", "dbo.AspNetUsers", "Id");
        }
    }
}
