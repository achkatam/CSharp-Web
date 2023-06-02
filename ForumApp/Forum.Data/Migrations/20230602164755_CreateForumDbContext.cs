namespace Forum.Data.Migrations;

using System; 
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable
    
public partial class CreateForumDbContext : Migration
{
    protected override void Up(MigrationBuilder migrationBuilder)
    {
        migrationBuilder.CreateTable(
            name: "Posts",
            columns: table => new
            {
                Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                Title = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                Content = table.Column<string>(type: "nvarchar(1500)", maxLength: 1500, nullable: false)
            },
            constraints: table =>
            {
                table.PrimaryKey("PK_Posts", x => x.Id);
            });

        migrationBuilder.InsertData(
            table: "Posts",
            columns: new[] { "Id", "Content", "Title" },
            values: new object[] { new Guid("1eb65deb-ac99-4c2f-a15b-68f097d453c1"), "Second Post Content", "Second Post" });

        migrationBuilder.InsertData(
            table: "Posts",
            columns: new[] { "Id", "Content", "Title" },
            values: new object[] { new Guid("6b64aea3-2b1f-4265-8a94-029b9aeee3c6"), "First Post Content", "First Post" });

        migrationBuilder.InsertData(
            table: "Posts",
            columns: new[] { "Id", "Content", "Title" },
            values: new object[] { new Guid("cd4bdcc3-e982-48be-97f0-caea45d41905"), "Third Post Content", "Third Post" });
    }

    protected override void Down(MigrationBuilder migrationBuilder)
    {
        migrationBuilder.DropTable(
            name: "Posts");
    }
}