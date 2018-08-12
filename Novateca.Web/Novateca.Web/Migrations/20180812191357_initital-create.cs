using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Novateca.Web.Migrations
{
    public partial class inititalcreate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Book",
                columns: table => new
                {
                    IdBook = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    TitleMain = table.Column<string>(maxLength: 20, nullable: false),
                    Subtitle = table.Column<string>(maxLength: 20, nullable: false),
                    AuthorMain = table.Column<string>(nullable: true),
                    Authors = table.Column<string>(nullable: true),
                    Edition = table.Column<string>(nullable: true),
                    Locate = table.Column<string>(nullable: true),
                    PublishingCompany = table.Column<string>(maxLength: 255, nullable: false),
                    Year = table.Column<int>(nullable: false),
                    TotalPages = table.Column<int>(nullable: false),
                    Subject = table.Column<string>(maxLength: 20, nullable: false),
                    URLImage = table.Column<string>(nullable: true),
                    URLEbook = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("IdBook", x => x.IdBook);
                });

            migrationBuilder.CreateTable(
                name: "User",
                columns: table => new
                {
                    UserID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Username = table.Column<string>(maxLength: 20, nullable: false),
                    Profile = table.Column<string>(nullable: true),
                    Firstname = table.Column<string>(maxLength: 20, nullable: false),
                    Lastname = table.Column<string>(maxLength: 20, nullable: false),
                    Email = table.Column<string>(nullable: true),
                    EmailConfirmed = table.Column<bool>(nullable: false),
                    Password = table.Column<string>(maxLength: 255, nullable: false),
                    ConfirmPassword = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("UserID", x => x.UserID);
                });

            migrationBuilder.CreateTable(
                name: "BookComment",
                columns: table => new
                {
                    BookCommentID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    UserID = table.Column<int>(nullable: false),
                    BookID = table.Column<int>(nullable: false),
                    Comment = table.Column<string>(maxLength: 100, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BookComment", x => x.BookCommentID);
                    table.ForeignKey(
                        name: "FK_BookComment_Book_BookID",
                        column: x => x.BookID,
                        principalTable: "Book",
                        principalColumn: "IdBook",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_BookComment_User_UserID",
                        column: x => x.UserID,
                        principalTable: "User",
                        principalColumn: "UserID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "BookLike",
                columns: table => new
                {
                    BookLikeID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    UserID = table.Column<int>(nullable: false),
                    BookID = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BookLike", x => x.BookLikeID);
                    table.ForeignKey(
                        name: "FK_BookLike_Book_BookID",
                        column: x => x.BookID,
                        principalTable: "Book",
                        principalColumn: "IdBook",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_BookLike_User_UserID",
                        column: x => x.UserID,
                        principalTable: "User",
                        principalColumn: "UserID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "FavoriteBooks",
                columns: table => new
                {
                    FavoriteBookID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    UserID = table.Column<int>(nullable: false),
                    BookID = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_FavoriteBooks", x => x.FavoriteBookID);
                    table.ForeignKey(
                        name: "FK_FavoriteBooks_Book_BookID",
                        column: x => x.BookID,
                        principalTable: "Book",
                        principalColumn: "IdBook",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_FavoriteBooks_User_UserID",
                        column: x => x.UserID,
                        principalTable: "User",
                        principalColumn: "UserID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_BookComment_BookID",
                table: "BookComment",
                column: "BookID");

            migrationBuilder.CreateIndex(
                name: "IX_BookComment_UserID",
                table: "BookComment",
                column: "UserID");

            migrationBuilder.CreateIndex(
                name: "IX_BookLike_BookID",
                table: "BookLike",
                column: "BookID");

            migrationBuilder.CreateIndex(
                name: "IX_BookLike_UserID",
                table: "BookLike",
                column: "UserID");

            migrationBuilder.CreateIndex(
                name: "IX_FavoriteBooks_BookID",
                table: "FavoriteBooks",
                column: "BookID");

            migrationBuilder.CreateIndex(
                name: "IX_FavoriteBooks_UserID",
                table: "FavoriteBooks",
                column: "UserID");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "BookComment");

            migrationBuilder.DropTable(
                name: "BookLike");

            migrationBuilder.DropTable(
                name: "FavoriteBooks");

            migrationBuilder.DropTable(
                name: "Book");

            migrationBuilder.DropTable(
                name: "User");
        }
    }
}
