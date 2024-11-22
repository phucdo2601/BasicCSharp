using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BlogWebApi.Model.Migrations
{
    /// <inheritdoc />
    public partial class DbInitb01 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "blog_cates_tbl",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    BlogCategoryTitle = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    DateOfCreated = table.Column<DateTime>(type: "datetime2", nullable: false),
                    DateOfModified = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_blog_cates_tbl", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "interaction_types_tbl",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Title = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    DateOfCreated = table.Column<DateTime>(type: "datetime2", nullable: false),
                    DateOfModified = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_interaction_types_tbl", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "roles_tbl",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    RoleTitle = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    DateOfCreated = table.Column<DateTime>(type: "datetime2", nullable: false),
                    DateOfModified = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_roles_tbl", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "users_tbl",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Username = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Passord = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Fullname = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    DateOfBirth = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Bio = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ProfilePicture = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    RoleId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    DateOfCreated = table.Column<DateTime>(type: "datetime2", nullable: false),
                    DateOfModified = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_users_tbl", x => x.Id);
                    table.ForeignKey(
                        name: "FK_users_tbl_roles_tbl_RoleId",
                        column: x => x.RoleId,
                        principalTable: "roles_tbl",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "blogs_tbl",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Title = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Content = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Tags = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    BlogCategoryId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    UserId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    DateOfCreated = table.Column<DateTime>(type: "datetime2", nullable: false),
                    DateOfModified = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_blogs_tbl", x => x.Id);
                    table.ForeignKey(
                        name: "FK_blogs_tbl_blog_cates_tbl_BlogCategoryId",
                        column: x => x.BlogCategoryId,
                        principalTable: "blog_cates_tbl",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_blogs_tbl_users_tbl_UserId",
                        column: x => x.UserId,
                        principalTable: "users_tbl",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "comments_tbl",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Content = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    UserId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    BlogId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    DateOfCreated = table.Column<DateTime>(type: "datetime2", nullable: false),
                    DateOfModified = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_comments_tbl", x => x.Id);
                    table.ForeignKey(
                        name: "FK_comments_tbl_blogs_tbl_BlogId",
                        column: x => x.BlogId,
                        principalTable: "blogs_tbl",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_comments_tbl_users_tbl_UserId",
                        column: x => x.UserId,
                        principalTable: "users_tbl",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "interaction_tbl",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    UserId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    BlogId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    InteractionTypeId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    DateOfCreated = table.Column<DateTime>(type: "datetime2", nullable: false),
                    DateOfModified = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_interaction_tbl", x => x.Id);
                    table.ForeignKey(
                        name: "FK_interaction_tbl_blogs_tbl_BlogId",
                        column: x => x.BlogId,
                        principalTable: "blogs_tbl",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_interaction_tbl_interaction_types_tbl_InteractionTypeId",
                        column: x => x.InteractionTypeId,
                        principalTable: "interaction_types_tbl",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_interaction_tbl_users_tbl_UserId",
                        column: x => x.UserId,
                        principalTable: "users_tbl",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "likes_tbl",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    BlogId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    UserId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    DateOfCreated = table.Column<DateTime>(type: "datetime2", nullable: false),
                    DateOfModified = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_likes_tbl", x => x.Id);
                    table.ForeignKey(
                        name: "FK_likes_tbl_blogs_tbl_BlogId",
                        column: x => x.BlogId,
                        principalTable: "blogs_tbl",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_likes_tbl_users_tbl_UserId",
                        column: x => x.UserId,
                        principalTable: "users_tbl",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "shares_tbl",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    UserId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    BlogId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    DateOfCreated = table.Column<DateTime>(type: "datetime2", nullable: false),
                    DateOfModified = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_shares_tbl", x => x.Id);
                    table.ForeignKey(
                        name: "FK_shares_tbl_blogs_tbl_BlogId",
                        column: x => x.BlogId,
                        principalTable: "blogs_tbl",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_shares_tbl_users_tbl_UserId",
                        column: x => x.UserId,
                        principalTable: "users_tbl",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_blogs_tbl_BlogCategoryId",
                table: "blogs_tbl",
                column: "BlogCategoryId");

            migrationBuilder.CreateIndex(
                name: "IX_blogs_tbl_UserId",
                table: "blogs_tbl",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_comments_tbl_BlogId",
                table: "comments_tbl",
                column: "BlogId");

            migrationBuilder.CreateIndex(
                name: "IX_comments_tbl_UserId",
                table: "comments_tbl",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_interaction_tbl_BlogId",
                table: "interaction_tbl",
                column: "BlogId");

            migrationBuilder.CreateIndex(
                name: "IX_interaction_tbl_InteractionTypeId",
                table: "interaction_tbl",
                column: "InteractionTypeId");

            migrationBuilder.CreateIndex(
                name: "IX_interaction_tbl_UserId",
                table: "interaction_tbl",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_likes_tbl_BlogId",
                table: "likes_tbl",
                column: "BlogId");

            migrationBuilder.CreateIndex(
                name: "IX_likes_tbl_UserId",
                table: "likes_tbl",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_shares_tbl_BlogId",
                table: "shares_tbl",
                column: "BlogId");

            migrationBuilder.CreateIndex(
                name: "IX_shares_tbl_UserId",
                table: "shares_tbl",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_users_tbl_RoleId",
                table: "users_tbl",
                column: "RoleId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "comments_tbl");

            migrationBuilder.DropTable(
                name: "interaction_tbl");

            migrationBuilder.DropTable(
                name: "likes_tbl");

            migrationBuilder.DropTable(
                name: "shares_tbl");

            migrationBuilder.DropTable(
                name: "interaction_types_tbl");

            migrationBuilder.DropTable(
                name: "blogs_tbl");

            migrationBuilder.DropTable(
                name: "blog_cates_tbl");

            migrationBuilder.DropTable(
                name: "users_tbl");

            migrationBuilder.DropTable(
                name: "roles_tbl");
        }
    }
}
