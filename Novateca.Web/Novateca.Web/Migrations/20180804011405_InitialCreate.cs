using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Novateca.Web.Migrations
{
    public partial class InitialCreate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Books",
                columns: table => new
                {
                    BookId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    TitleMain = table.Column<string>(nullable: true),
                    SubTitle = table.Column<string>(nullable: true),
                    AuthorMain = table.Column<string>(nullable: true),
                    Authors = table.Column<string>(nullable: true),
                    Edition = table.Column<string>(nullable: true),
                    Locate = table.Column<string>(nullable: true),
                    PublishingCompany = table.Column<string>(nullable: true),
                    Year = table.Column<int>(nullable: false),
                    TotalPages = table.Column<int>(nullable: false),
                    Subject = table.Column<string>(nullable: true),
                    URLImage = table.Column<string>(nullable: true),
                    URLEbook = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Books", x => x.BookId);
                });

            migrationBuilder.CreateTable(
                name: "Users",
                columns: table => new
                {
                    UserID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    FirstName = table.Column<string>(nullable: false),
                    LastName = table.Column<string>(nullable: false),
                    Email = table.Column<string>(nullable: false),
                    Username = table.Column<string>(nullable: false),
                    Password = table.Column<string>(nullable: false),
                    ConfirmPassword = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Users", x => x.UserID);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Books");

            migrationBuilder.DropTable(
                name: "Users");
        }
    }
}
