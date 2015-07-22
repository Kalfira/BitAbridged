namespace BitAbridged.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Languageandsnippetsupport : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Languages",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(nullable: false),
                        Url = c.String(nullable: false),
                        Use = c.String(),
                        Imperative = c.Boolean(nullable: false),
                        ObjectOriented = c.Boolean(nullable: false),
                        Functional = c.Boolean(nullable: false),
                        Procedural = c.Boolean(nullable: false),
                        Generic = c.Boolean(nullable: false),
                        Reflective = c.Boolean(nullable: false),
                        EventDriven = c.Boolean(nullable: false),
                        Standardized = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Snippets",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        LanguageId = c.Int(nullable: false),
                        Name = c.String(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Languages", t => t.LanguageId, cascadeDelete: true)
                .Index(t => t.LanguageId);
            
            DropTable("dbo.Searchables");
        }
        
        public override void Down()
        {
            CreateTable(
                "dbo.Searchables",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        Description = c.String(),
                        Url = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            DropForeignKey("dbo.Snippets", "LanguageId", "dbo.Languages");
            DropIndex("dbo.Snippets", new[] { "LanguageId" });
            DropTable("dbo.Snippets");
            DropTable("dbo.Languages");
        }
    }
}
