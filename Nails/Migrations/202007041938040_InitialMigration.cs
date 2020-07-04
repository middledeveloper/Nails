namespace Nails.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InitialMigration : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Certificates",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Scan = c.String(),
                        Created = c.DateTime(nullable: false),
                        Updated = c.DateTime(nullable: false),
                        Authority_Id = c.Int(),
                        Master_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.CertificationAhorities", t => t.Authority_Id)
                .ForeignKey("dbo.Users", t => t.Master_Id)
                .Index(t => t.Authority_Id)
                .Index(t => t.Master_Id);
            
            CreateTable(
                "dbo.CertificationAhorities",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Title = c.String(),
                        Url = c.String(),
                        Created = c.DateTime(nullable: false),
                        Updated = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Users",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        FirstName = c.String(),
                        LastName = c.String(),
                        Photo = c.String(),
                        Created = c.DateTime(nullable: false),
                        Updated = c.DateTime(nullable: false),
                        ExperienceYears = c.Int(),
                        Discriminator = c.String(nullable: false, maxLength: 128),
                        City_Id = c.Int(),
                        Region_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Cities", t => t.City_Id)
                .ForeignKey("dbo.Regions", t => t.Region_Id)
                .Index(t => t.City_Id)
                .Index(t => t.Region_Id);
            
            CreateTable(
                "dbo.Cities",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Title = c.String(),
                        Created = c.DateTime(nullable: false),
                        Updated = c.DateTime(nullable: false),
                        Region_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Regions", t => t.Region_Id)
                .Index(t => t.Region_Id);
            
            CreateTable(
                "dbo.Regions",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Title = c.String(),
                        Created = c.DateTime(nullable: false),
                        Updated = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Contacts",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Address = c.String(),
                        Created = c.DateTime(nullable: false),
                        Updated = c.DateTime(nullable: false),
                        ContactType_Id = c.Int(),
                        User_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.ContactTypes", t => t.ContactType_Id)
                .ForeignKey("dbo.Users", t => t.User_Id)
                .Index(t => t.ContactType_Id)
                .Index(t => t.User_Id);
            
            CreateTable(
                "dbo.ContactTypes",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Title = c.String(),
                        Logo = c.String(),
                        Created = c.DateTime(nullable: false),
                        Updated = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Reservations",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        ReceptionTime = c.DateTime(nullable: false),
                        Completed = c.Boolean(nullable: false),
                        Created = c.DateTime(nullable: false),
                        Updated = c.DateTime(nullable: false),
                        City_Id = c.Int(),
                        Client_Id = c.Int(),
                        Feedback_Id = c.Int(),
                        Master_Id = c.Int(),
                        RejectionReason_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Cities", t => t.City_Id)
                .ForeignKey("dbo.Users", t => t.Client_Id)
                .ForeignKey("dbo.Testimonials", t => t.Feedback_Id)
                .ForeignKey("dbo.Users", t => t.Master_Id)
                .ForeignKey("dbo.RejectionReasons", t => t.RejectionReason_Id)
                .Index(t => t.City_Id)
                .Index(t => t.Client_Id)
                .Index(t => t.Feedback_Id)
                .Index(t => t.Master_Id)
                .Index(t => t.RejectionReason_Id);
            
            CreateTable(
                "dbo.Testimonials",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Content = c.String(),
                        Created = c.DateTime(nullable: false),
                        Updated = c.DateTime(nullable: false),
                        Client_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Users", t => t.Client_Id)
                .Index(t => t.Client_Id);
            
            CreateTable(
                "dbo.RejectionReasons",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Title = c.String(),
                        Created = c.DateTime(nullable: false),
                        Updated = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Services",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Title = c.String(),
                        Category = c.String(),
                        Price = c.Decimal(nullable: false, precision: 18, scale: 2),
                        Created = c.DateTime(nullable: false),
                        Updated = c.DateTime(nullable: false),
                        Reservation_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Reservations", t => t.Reservation_Id)
                .Index(t => t.Reservation_Id);
            
            CreateTable(
                "dbo.ContentBlocks",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Title = c.String(),
                        HtmlId = c.String(),
                        Content = c.String(),
                        Created = c.DateTime(nullable: false),
                        Updated = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Photos",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Path = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Services", "Reservation_Id", "dbo.Reservations");
            DropForeignKey("dbo.Reservations", "RejectionReason_Id", "dbo.RejectionReasons");
            DropForeignKey("dbo.Reservations", "Master_Id", "dbo.Users");
            DropForeignKey("dbo.Reservations", "Feedback_Id", "dbo.Testimonials");
            DropForeignKey("dbo.Testimonials", "Client_Id", "dbo.Users");
            DropForeignKey("dbo.Reservations", "Client_Id", "dbo.Users");
            DropForeignKey("dbo.Reservations", "City_Id", "dbo.Cities");
            DropForeignKey("dbo.Users", "Region_Id", "dbo.Regions");
            DropForeignKey("dbo.Contacts", "User_Id", "dbo.Users");
            DropForeignKey("dbo.Users", "City_Id", "dbo.Cities");
            DropForeignKey("dbo.Contacts", "ContactType_Id", "dbo.ContactTypes");
            DropForeignKey("dbo.Cities", "Region_Id", "dbo.Regions");
            DropForeignKey("dbo.Certificates", "Master_Id", "dbo.Users");
            DropForeignKey("dbo.Certificates", "Authority_Id", "dbo.CertificationAhorities");
            DropIndex("dbo.Services", new[] { "Reservation_Id" });
            DropIndex("dbo.Testimonials", new[] { "Client_Id" });
            DropIndex("dbo.Reservations", new[] { "RejectionReason_Id" });
            DropIndex("dbo.Reservations", new[] { "Master_Id" });
            DropIndex("dbo.Reservations", new[] { "Feedback_Id" });
            DropIndex("dbo.Reservations", new[] { "Client_Id" });
            DropIndex("dbo.Reservations", new[] { "City_Id" });
            DropIndex("dbo.Contacts", new[] { "User_Id" });
            DropIndex("dbo.Contacts", new[] { "ContactType_Id" });
            DropIndex("dbo.Cities", new[] { "Region_Id" });
            DropIndex("dbo.Users", new[] { "Region_Id" });
            DropIndex("dbo.Users", new[] { "City_Id" });
            DropIndex("dbo.Certificates", new[] { "Master_Id" });
            DropIndex("dbo.Certificates", new[] { "Authority_Id" });
            DropTable("dbo.Photos");
            DropTable("dbo.ContentBlocks");
            DropTable("dbo.Services");
            DropTable("dbo.RejectionReasons");
            DropTable("dbo.Testimonials");
            DropTable("dbo.Reservations");
            DropTable("dbo.ContactTypes");
            DropTable("dbo.Contacts");
            DropTable("dbo.Regions");
            DropTable("dbo.Cities");
            DropTable("dbo.Users");
            DropTable("dbo.CertificationAhorities");
            DropTable("dbo.Certificates");
        }
    }
}
