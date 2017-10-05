namespace GigHub.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class updateModels : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Followings", "Follower_Id", "dbo.AspNetUsers");
            DropForeignKey("dbo.Followings", "FolloweeId", "dbo.AspNetUsers");
            DropIndex("dbo.Followings", new[] { "FolloweeId" });
            DropIndex("dbo.Followings", new[] { "Follower_Id" });
            DropTable("dbo.Followings");
        }
        
        public override void Down()
        {
            CreateTable(
                "dbo.Followings",
                c => new
                    {
                        FollowerId = c.Int(nullable: false),
                        FolloweeId = c.String(nullable: false, maxLength: 128),
                        Follower_Id = c.String(nullable: false, maxLength: 128),
                    })
                .PrimaryKey(t => new { t.FollowerId, t.FolloweeId });
            
            CreateIndex("dbo.Followings", "Follower_Id");
            CreateIndex("dbo.Followings", "FolloweeId");
            AddForeignKey("dbo.Followings", "FolloweeId", "dbo.AspNetUsers", "Id");
            AddForeignKey("dbo.Followings", "Follower_Id", "dbo.AspNetUsers", "Id");
        }
    }
}
