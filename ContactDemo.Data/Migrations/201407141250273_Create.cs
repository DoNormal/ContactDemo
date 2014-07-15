namespace ContactDemo.Data.Migrations
{
    using System.Data.Entity.Migrations;

    public partial class Create : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Contact",
                c => new
                {
                    Id = c.Int(nullable: false, identity: true),
                    Name = c.String(nullable: false),
                    EmailAddress = c.String(nullable: false, maxLength: 150),
                    WhenCreated = c.DateTimeOffset(nullable: false, precision: 7),
                })
                .PrimaryKey(t => t.Id);

            CreateIndex("dbo.Contact", "EmailAddress", unique: true);
        }

        public override void Down()
        {
            DropIndex("dbo.Contact", "Email");
            DropTable("dbo.Contact");
        }
    }
}