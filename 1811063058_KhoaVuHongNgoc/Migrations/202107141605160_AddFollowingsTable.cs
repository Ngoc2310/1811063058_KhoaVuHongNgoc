namespace _1811063058_KhoaVuHongNgoc.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddFollowingsTable : DbMigration
    {
        public override void Up()
        {
            RenameColumn(table: "dbo.Attendances", name: "Course_Id", newName: "CourseId");
            RenameIndex(table: "dbo.Attendances", name: "IX_Course_Id", newName: "IX_CourseId");
            DropPrimaryKey("dbo.Attendances");
            CreateTable(
                "dbo.Followings",
                c => new
                    {
                        FollowerId = c.String(nullable: false, maxLength: 128),
                        FolloweeId = c.String(nullable: false, maxLength: 128),
                    })
                .PrimaryKey(t => new { t.FollowerId, t.FolloweeId })
                .ForeignKey("dbo.AspNetUsers", t => t.FollowerId)
                .ForeignKey("dbo.AspNetUsers", t => t.FolloweeId)
                .Index(t => t.FollowerId)
                .Index(t => t.FolloweeId);
            
            AddPrimaryKey("dbo.Attendances", new[] { "CourseId", "AttendeeId" });
            DropColumn("dbo.Attendances", "CourseI");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Attendances", "CourseI", c => c.Int(nullable: false));
            DropForeignKey("dbo.Followings", "FolloweeId", "dbo.AspNetUsers");
            DropForeignKey("dbo.Followings", "FollowerId", "dbo.AspNetUsers");
            DropIndex("dbo.Followings", new[] { "FolloweeId" });
            DropIndex("dbo.Followings", new[] { "FollowerId" });
            DropPrimaryKey("dbo.Attendances");
            DropTable("dbo.Followings");
            AddPrimaryKey("dbo.Attendances", new[] { "CourseI", "AttendeeId" });
            RenameIndex(table: "dbo.Attendances", name: "IX_CourseId", newName: "IX_Course_Id");
            RenameColumn(table: "dbo.Attendances", name: "CourseId", newName: "Course_Id");
        }
    }
}
