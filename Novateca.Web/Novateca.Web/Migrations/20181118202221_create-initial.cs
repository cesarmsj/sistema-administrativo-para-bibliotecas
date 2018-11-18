using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Novateca.Web.Migrations
{
    public partial class createinitial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "AspNetRoles",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Name = table.Column<string>(maxLength: 256, nullable: true),
                    NormalizedName = table.Column<string>(maxLength: 256, nullable: true),
                    ConcurrencyStamp = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetRoles", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Book",
                columns: table => new
                {
                    BookID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    TitleMain = table.Column<string>(maxLength: 255, nullable: false),
                    Subtitle = table.Column<string>(maxLength: 255, nullable: true),
                    AuthorMain = table.Column<string>(nullable: false),
                    Authors = table.Column<string>(nullable: false),
                    Edition = table.Column<string>(maxLength: 20, nullable: false),
                    PlaceOfPublication = table.Column<string>(maxLength: 80, nullable: false),
                    PublishingCompany = table.Column<string>(maxLength: 255, nullable: false),
                    YearOfPublication = table.Column<int>(nullable: false),
                    TotalPages = table.Column<int>(nullable: false),
                    BookSubject = table.Column<string>(maxLength: 80, nullable: false),
                    Abstract = table.Column<string>(nullable: true),
                    ISBN = table.Column<string>(maxLength: 255, nullable: false),
                    URLImage = table.Column<string>(maxLength: 255, nullable: true),
                    AvatarImage = table.Column<byte[]>(nullable: true),
                    URLEbook = table.Column<string>(maxLength: 255, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("BookID", x => x.BookID);
                });

            migrationBuilder.CreateTable(
                name: "Multimedia",
                columns: table => new
                {
                    MultimediaID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    TitleMain = table.Column<string>(maxLength: 255, nullable: false),
                    DGM = table.Column<string>(maxLength: 100, nullable: false),
                    Subtitle = table.Column<string>(maxLength: 255, nullable: true),
                    Director = table.Column<string>(maxLength: 80, nullable: false),
                    PlaceOfPublication = table.Column<string>(maxLength: 80, nullable: false),
                    PublishingCompany = table.Column<string>(maxLength: 80, nullable: false),
                    YearOfPublication = table.Column<int>(nullable: false),
                    PhysicalDescription = table.Column<string>(maxLength: 80, nullable: false),
                    MultimediaSubject = table.Column<string>(maxLength: 80, nullable: false),
                    Abstract = table.Column<string>(nullable: true),
                    NoteOfParticipants = table.Column<string>(maxLength: 255, nullable: false),
                    TargetAudience = table.Column<string>(maxLength: 80, nullable: false),
                    Language = table.Column<string>(maxLength: 30, nullable: false),
                    URLImage = table.Column<string>(maxLength: 255, nullable: true),
                    AvatarImage = table.Column<byte[]>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("MuldimediaID", x => x.MultimediaID);
                });

            migrationBuilder.CreateTable(
                name: "Newspaper",
                columns: table => new
                {
                    NewspaperID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    TitleMain = table.Column<string>(maxLength: 255, nullable: false),
                    Subtitle = table.Column<string>(maxLength: 255, nullable: true),
                    Edition = table.Column<string>(maxLength: 20, nullable: false),
                    PlaceOfPublication = table.Column<string>(maxLength: 80, nullable: false),
                    PublishingCompany = table.Column<string>(maxLength: 255, nullable: false),
                    NewspaperSubject = table.Column<string>(maxLength: 20, nullable: false),
                    CurrentPeriodicity = table.Column<string>(maxLength: 30, nullable: false),
                    ISSN = table.Column<string>(maxLength: 255, nullable: false),
                    URLImage = table.Column<string>(maxLength: 255, nullable: true),
                    AvatarImage = table.Column<byte[]>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("NewspaperID", x => x.NewspaperID);
                });

            migrationBuilder.CreateTable(
                name: "Users",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    UserName = table.Column<string>(maxLength: 256, nullable: true),
                    NormalizedUserName = table.Column<string>(maxLength: 256, nullable: true),
                    Email = table.Column<string>(maxLength: 256, nullable: true),
                    NormalizedEmail = table.Column<string>(maxLength: 256, nullable: true),
                    EmailConfirmed = table.Column<bool>(nullable: false),
                    PasswordHash = table.Column<string>(nullable: true),
                    SecurityStamp = table.Column<string>(nullable: true),
                    ConcurrencyStamp = table.Column<string>(nullable: true),
                    PhoneNumber = table.Column<string>(nullable: true),
                    PhoneNumberConfirmed = table.Column<bool>(nullable: false),
                    TwoFactorEnabled = table.Column<bool>(nullable: false),
                    LockoutEnd = table.Column<DateTimeOffset>(nullable: true),
                    LockoutEnabled = table.Column<bool>(nullable: false),
                    AccessFailedCount = table.Column<int>(nullable: false),
                    Firstname = table.Column<string>(maxLength: 40, nullable: false),
                    Lastname = table.Column<string>(maxLength: 80, nullable: false),
                    User_CPF = table.Column<string>(maxLength: 11, nullable: true),
                    URLProfilePicture = table.Column<string>(maxLength: 255, nullable: true),
                    AvatarImage = table.Column<byte[]>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Users", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "AspNetRoleClaims",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    RoleId = table.Column<int>(nullable: false),
                    ClaimType = table.Column<string>(nullable: true),
                    ClaimValue = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetRoleClaims", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AspNetRoleClaims_AspNetRoles_RoleId",
                        column: x => x.RoleId,
                        principalTable: "AspNetRoles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserClaims",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    UserId = table.Column<int>(nullable: false),
                    ClaimType = table.Column<string>(nullable: true),
                    ClaimValue = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserClaims", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AspNetUserClaims_Users_UserId",
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserLogins",
                columns: table => new
                {
                    LoginProvider = table.Column<string>(nullable: false),
                    ProviderKey = table.Column<string>(nullable: false),
                    ProviderDisplayName = table.Column<string>(nullable: true),
                    UserId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserLogins", x => new { x.LoginProvider, x.ProviderKey });
                    table.ForeignKey(
                        name: "FK_AspNetUserLogins_Users_UserId",
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserRoles",
                columns: table => new
                {
                    UserId = table.Column<int>(nullable: false),
                    RoleId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserRoles", x => new { x.UserId, x.RoleId });
                    table.ForeignKey(
                        name: "FK_AspNetUserRoles_AspNetRoles_RoleId",
                        column: x => x.RoleId,
                        principalTable: "AspNetRoles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_AspNetUserRoles_Users_UserId",
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserTokens",
                columns: table => new
                {
                    UserId = table.Column<int>(nullable: false),
                    LoginProvider = table.Column<string>(nullable: false),
                    Name = table.Column<string>(nullable: false),
                    Value = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserTokens", x => new { x.UserId, x.LoginProvider, x.Name });
                    table.ForeignKey(
                        name: "FK_AspNetUserTokens_Users_UserId",
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "BookComment",
                columns: table => new
                {
                    BookCommentID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    UserID = table.Column<int>(nullable: false),
                    BookID = table.Column<int>(nullable: false),
                    Comment = table.Column<string>(maxLength: 100, nullable: false),
                    CommentDate = table.Column<DateTime>(nullable: false),
                    CommentEnabled = table.Column<bool>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BookComment", x => x.BookCommentID);
                    table.ForeignKey(
                        name: "FK_BookComment_Book_BookID",
                        column: x => x.BookID,
                        principalTable: "Book",
                        principalColumn: "BookID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_BookComment_Users_UserID",
                        column: x => x.UserID,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "BookLike",
                columns: table => new
                {
                    BookLikeID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    UserId = table.Column<int>(nullable: false),
                    BookID = table.Column<int>(nullable: false),
                    LikeDate = table.Column<DateTime>(nullable: false),
                    LikeEnabled = table.Column<bool>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BookLike", x => x.BookLikeID);
                    table.ForeignKey(
                        name: "FK_BookLike_Book_BookID",
                        column: x => x.BookID,
                        principalTable: "Book",
                        principalColumn: "BookID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_BookLike_Users_UserId",
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "BookLoan",
                columns: table => new
                {
                    BookLoanID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    LoanDate = table.Column<DateTime>(nullable: false),
                    DevolutionDate = table.Column<DateTime>(nullable: false),
                    DevolutionDateMade = table.Column<DateTime>(nullable: false),
                    UserID = table.Column<int>(nullable: false),
                    BookID = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BookLoan", x => x.BookLoanID);
                    table.ForeignKey(
                        name: "FK_BookLoan_Book_BookID",
                        column: x => x.BookID,
                        principalTable: "Book",
                        principalColumn: "BookID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_BookLoan_Users_UserID",
                        column: x => x.UserID,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "FavoriteBook",
                columns: table => new
                {
                    FavoriteBookID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    UserID = table.Column<int>(nullable: false),
                    BookID = table.Column<int>(nullable: false),
                    FavoriteDate = table.Column<DateTime>(nullable: false),
                    FavoriteEnabled = table.Column<bool>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_FavoriteBook", x => x.FavoriteBookID);
                    table.ForeignKey(
                        name: "FK_FavoriteBook_Book_BookID",
                        column: x => x.BookID,
                        principalTable: "Book",
                        principalColumn: "BookID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_FavoriteBook_Users_UserID",
                        column: x => x.UserID,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "FavoriteMultimedia",
                columns: table => new
                {
                    FavoriteMultimediaID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    UserID = table.Column<int>(nullable: false),
                    MultimediaID = table.Column<int>(nullable: false),
                    FavoriteDate = table.Column<DateTime>(nullable: false),
                    FavoriteEnabled = table.Column<bool>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_FavoriteMultimedia", x => x.FavoriteMultimediaID);
                    table.ForeignKey(
                        name: "FK_FavoriteMultimedia_Multimedia_MultimediaID",
                        column: x => x.MultimediaID,
                        principalTable: "Multimedia",
                        principalColumn: "MultimediaID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_FavoriteMultimedia_Users_UserID",
                        column: x => x.UserID,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "FavoriteNewspaper",
                columns: table => new
                {
                    FavoriteNewspaperID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    UserID = table.Column<int>(nullable: false),
                    NewspaperID = table.Column<int>(nullable: false),
                    FavoriteDate = table.Column<DateTime>(nullable: false),
                    FavoriteEnabled = table.Column<bool>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_FavoriteNewspaper", x => x.FavoriteNewspaperID);
                    table.ForeignKey(
                        name: "FK_FavoriteNewspaper_Newspaper_NewspaperID",
                        column: x => x.NewspaperID,
                        principalTable: "Newspaper",
                        principalColumn: "NewspaperID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_FavoriteNewspaper_Users_UserID",
                        column: x => x.UserID,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "MultimediaComment",
                columns: table => new
                {
                    MultimediaCommentID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    UserID = table.Column<int>(nullable: false),
                    MultimediaID = table.Column<int>(nullable: false),
                    Comment = table.Column<string>(maxLength: 255, nullable: false),
                    CommentDate = table.Column<DateTime>(nullable: false),
                    CommentEnabled = table.Column<bool>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MultimediaComment", x => x.MultimediaCommentID);
                    table.ForeignKey(
                        name: "FK_MultimediaComment_Multimedia_MultimediaID",
                        column: x => x.MultimediaID,
                        principalTable: "Multimedia",
                        principalColumn: "MultimediaID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_MultimediaComment_Users_UserID",
                        column: x => x.UserID,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "MultimediaLike",
                columns: table => new
                {
                    MultimediaLikeID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    UserId = table.Column<int>(nullable: false),
                    MultimediaID = table.Column<int>(nullable: false),
                    LikeDate = table.Column<DateTime>(nullable: false),
                    LikeEnabled = table.Column<bool>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MultimediaLike", x => x.MultimediaLikeID);
                    table.ForeignKey(
                        name: "FK_MultimediaLike_Multimedia_MultimediaID",
                        column: x => x.MultimediaID,
                        principalTable: "Multimedia",
                        principalColumn: "MultimediaID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_MultimediaLike_Users_UserId",
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "MultimediaLoan",
                columns: table => new
                {
                    MultimediaLoanID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    LoanDate = table.Column<DateTime>(nullable: false),
                    DevolutionDate = table.Column<DateTime>(nullable: false),
                    DevolutionDateMade = table.Column<DateTime>(nullable: false),
                    UserID = table.Column<int>(nullable: false),
                    MultimediaID = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MultimediaLoan", x => x.MultimediaLoanID);
                    table.ForeignKey(
                        name: "FK_MultimediaLoan_Multimedia_MultimediaID",
                        column: x => x.MultimediaID,
                        principalTable: "Multimedia",
                        principalColumn: "MultimediaID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_MultimediaLoan_Users_UserID",
                        column: x => x.UserID,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "NewspaperComment",
                columns: table => new
                {
                    NewspaperCommentID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    UserID = table.Column<int>(nullable: false),
                    NewspaperID = table.Column<int>(nullable: false),
                    Comment = table.Column<string>(maxLength: 100, nullable: false),
                    CommentDate = table.Column<DateTime>(nullable: false),
                    CommentEnabled = table.Column<bool>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_NewspaperComment", x => x.NewspaperCommentID);
                    table.ForeignKey(
                        name: "FK_NewspaperComment_Newspaper_NewspaperID",
                        column: x => x.NewspaperID,
                        principalTable: "Newspaper",
                        principalColumn: "NewspaperID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_NewspaperComment_Users_UserID",
                        column: x => x.UserID,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "NewspaperLike",
                columns: table => new
                {
                    NewspaperLikeID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    UserId = table.Column<int>(nullable: false),
                    NewspaperID = table.Column<int>(nullable: false),
                    LikeDate = table.Column<DateTime>(nullable: false),
                    LikeEnabled = table.Column<bool>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_NewspaperLike", x => x.NewspaperLikeID);
                    table.ForeignKey(
                        name: "FK_NewspaperLike_Newspaper_NewspaperID",
                        column: x => x.NewspaperID,
                        principalTable: "Newspaper",
                        principalColumn: "NewspaperID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_NewspaperLike_Users_UserId",
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "NewspaperLoan",
                columns: table => new
                {
                    NewspaperLoanID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    LoanDate = table.Column<DateTime>(nullable: false),
                    DevolutionDate = table.Column<DateTime>(nullable: false),
                    DevolutionDateMade = table.Column<DateTime>(nullable: false),
                    UserID = table.Column<int>(nullable: false),
                    NewspaperID = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_NewspaperLoan", x => x.NewspaperLoanID);
                    table.ForeignKey(
                        name: "FK_NewspaperLoan_Newspaper_NewspaperID",
                        column: x => x.NewspaperID,
                        principalTable: "Newspaper",
                        principalColumn: "NewspaperID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_NewspaperLoan_Users_UserID",
                        column: x => x.UserID,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "BookLikeInComment",
                columns: table => new
                {
                    BookLikeInCommentID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    UserId = table.Column<int>(nullable: false),
                    BookCommentID = table.Column<int>(nullable: false),
                    LikeDate = table.Column<DateTime>(nullable: false),
                    LikeEnabled = table.Column<bool>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BookLikeInComment", x => x.BookLikeInCommentID);
                    table.ForeignKey(
                        name: "FK_BookLikeInComment_BookComment_BookCommentID",
                        column: x => x.BookCommentID,
                        principalTable: "BookComment",
                        principalColumn: "BookCommentID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_BookLikeInComment_Users_UserId",
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "MultimediaLikeInComment",
                columns: table => new
                {
                    MultimediaLikeInCommentID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    UserId = table.Column<int>(nullable: false),
                    MultimediaCommentID = table.Column<int>(nullable: false),
                    LikeDate = table.Column<DateTime>(nullable: false),
                    LikeEnabled = table.Column<bool>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MultimediaLikeInComment", x => x.MultimediaLikeInCommentID);
                    table.ForeignKey(
                        name: "FK_MultimediaLikeInComment_MultimediaComment_MultimediaCommentID",
                        column: x => x.MultimediaCommentID,
                        principalTable: "MultimediaComment",
                        principalColumn: "MultimediaCommentID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_MultimediaLikeInComment_Users_UserId",
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "NewspaperLikeInComment",
                columns: table => new
                {
                    NewspaperLikeInCommentID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    UserId = table.Column<int>(nullable: false),
                    NewspaperCommentID = table.Column<int>(nullable: false),
                    LikeDate = table.Column<DateTime>(nullable: false),
                    LikeEnabled = table.Column<bool>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_NewspaperLikeInComment", x => x.NewspaperLikeInCommentID);
                    table.ForeignKey(
                        name: "FK_NewspaperLikeInComment_NewspaperComment_NewspaperCommentID",
                        column: x => x.NewspaperCommentID,
                        principalTable: "NewspaperComment",
                        principalColumn: "NewspaperCommentID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_NewspaperLikeInComment_Users_UserId",
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_AspNetRoleClaims_RoleId",
                table: "AspNetRoleClaims",
                column: "RoleId");

            migrationBuilder.CreateIndex(
                name: "RoleNameIndex",
                table: "AspNetRoles",
                column: "NormalizedName",
                unique: true,
                filter: "[NormalizedName] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserClaims_UserId",
                table: "AspNetUserClaims",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserLogins_UserId",
                table: "AspNetUserLogins",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserRoles_RoleId",
                table: "AspNetUserRoles",
                column: "RoleId");

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
                name: "IX_BookLike_UserId",
                table: "BookLike",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_BookLikeInComment_BookCommentID",
                table: "BookLikeInComment",
                column: "BookCommentID");

            migrationBuilder.CreateIndex(
                name: "IX_BookLikeInComment_UserId",
                table: "BookLikeInComment",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_BookLoan_BookID",
                table: "BookLoan",
                column: "BookID");

            migrationBuilder.CreateIndex(
                name: "IX_BookLoan_UserID",
                table: "BookLoan",
                column: "UserID");

            migrationBuilder.CreateIndex(
                name: "IX_FavoriteBook_BookID",
                table: "FavoriteBook",
                column: "BookID");

            migrationBuilder.CreateIndex(
                name: "IX_FavoriteBook_UserID",
                table: "FavoriteBook",
                column: "UserID");

            migrationBuilder.CreateIndex(
                name: "IX_FavoriteMultimedia_MultimediaID",
                table: "FavoriteMultimedia",
                column: "MultimediaID");

            migrationBuilder.CreateIndex(
                name: "IX_FavoriteMultimedia_UserID",
                table: "FavoriteMultimedia",
                column: "UserID");

            migrationBuilder.CreateIndex(
                name: "IX_FavoriteNewspaper_NewspaperID",
                table: "FavoriteNewspaper",
                column: "NewspaperID");

            migrationBuilder.CreateIndex(
                name: "IX_FavoriteNewspaper_UserID",
                table: "FavoriteNewspaper",
                column: "UserID");

            migrationBuilder.CreateIndex(
                name: "IX_MultimediaComment_MultimediaID",
                table: "MultimediaComment",
                column: "MultimediaID");

            migrationBuilder.CreateIndex(
                name: "IX_MultimediaComment_UserID",
                table: "MultimediaComment",
                column: "UserID");

            migrationBuilder.CreateIndex(
                name: "IX_MultimediaLike_MultimediaID",
                table: "MultimediaLike",
                column: "MultimediaID");

            migrationBuilder.CreateIndex(
                name: "IX_MultimediaLike_UserId",
                table: "MultimediaLike",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_MultimediaLikeInComment_MultimediaCommentID",
                table: "MultimediaLikeInComment",
                column: "MultimediaCommentID");

            migrationBuilder.CreateIndex(
                name: "IX_MultimediaLikeInComment_UserId",
                table: "MultimediaLikeInComment",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_MultimediaLoan_MultimediaID",
                table: "MultimediaLoan",
                column: "MultimediaID");

            migrationBuilder.CreateIndex(
                name: "IX_MultimediaLoan_UserID",
                table: "MultimediaLoan",
                column: "UserID");

            migrationBuilder.CreateIndex(
                name: "IX_NewspaperComment_NewspaperID",
                table: "NewspaperComment",
                column: "NewspaperID");

            migrationBuilder.CreateIndex(
                name: "IX_NewspaperComment_UserID",
                table: "NewspaperComment",
                column: "UserID");

            migrationBuilder.CreateIndex(
                name: "IX_NewspaperLike_NewspaperID",
                table: "NewspaperLike",
                column: "NewspaperID");

            migrationBuilder.CreateIndex(
                name: "IX_NewspaperLike_UserId",
                table: "NewspaperLike",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_NewspaperLikeInComment_NewspaperCommentID",
                table: "NewspaperLikeInComment",
                column: "NewspaperCommentID");

            migrationBuilder.CreateIndex(
                name: "IX_NewspaperLikeInComment_UserId",
                table: "NewspaperLikeInComment",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_NewspaperLoan_NewspaperID",
                table: "NewspaperLoan",
                column: "NewspaperID");

            migrationBuilder.CreateIndex(
                name: "IX_NewspaperLoan_UserID",
                table: "NewspaperLoan",
                column: "UserID");

            migrationBuilder.CreateIndex(
                name: "EmailIndex",
                table: "Users",
                column: "NormalizedEmail");

            migrationBuilder.CreateIndex(
                name: "UserNameIndex",
                table: "Users",
                column: "NormalizedUserName",
                unique: true,
                filter: "[NormalizedUserName] IS NOT NULL");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "AspNetRoleClaims");

            migrationBuilder.DropTable(
                name: "AspNetUserClaims");

            migrationBuilder.DropTable(
                name: "AspNetUserLogins");

            migrationBuilder.DropTable(
                name: "AspNetUserRoles");

            migrationBuilder.DropTable(
                name: "AspNetUserTokens");

            migrationBuilder.DropTable(
                name: "BookLike");

            migrationBuilder.DropTable(
                name: "BookLikeInComment");

            migrationBuilder.DropTable(
                name: "BookLoan");

            migrationBuilder.DropTable(
                name: "FavoriteBook");

            migrationBuilder.DropTable(
                name: "FavoriteMultimedia");

            migrationBuilder.DropTable(
                name: "FavoriteNewspaper");

            migrationBuilder.DropTable(
                name: "MultimediaLike");

            migrationBuilder.DropTable(
                name: "MultimediaLikeInComment");

            migrationBuilder.DropTable(
                name: "MultimediaLoan");

            migrationBuilder.DropTable(
                name: "NewspaperLike");

            migrationBuilder.DropTable(
                name: "NewspaperLikeInComment");

            migrationBuilder.DropTable(
                name: "NewspaperLoan");

            migrationBuilder.DropTable(
                name: "AspNetRoles");

            migrationBuilder.DropTable(
                name: "BookComment");

            migrationBuilder.DropTable(
                name: "MultimediaComment");

            migrationBuilder.DropTable(
                name: "NewspaperComment");

            migrationBuilder.DropTable(
                name: "Book");

            migrationBuilder.DropTable(
                name: "Multimedia");

            migrationBuilder.DropTable(
                name: "Newspaper");

            migrationBuilder.DropTable(
                name: "Users");
        }
    }
}
