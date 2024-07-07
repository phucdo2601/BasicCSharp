using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace PracNet7ApiProB01.Model.Migrations
{
    /// <inheritdoc />
    public partial class UpdateEnDb01 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "general_user_info_tbl",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    Address = table.Column<string>(type: "text", nullable: false),
                    DateOfBirth = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    DateOfCreate = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    DateOfUpdate = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    Email = table.Column<string>(type: "text", nullable: false),
                    FullName = table.Column<string>(type: "text", nullable: false),
                    Gender = table.Column<string>(type: "text", nullable: false),
                    IsActive = table.Column<bool>(type: "boolean", nullable: false),
                    NationalId = table.Column<string>(type: "text", nullable: false),
                    Password = table.Column<string>(type: "text", nullable: false),
                    PhoneNumber = table.Column<string>(type: "text", nullable: false),
                    UserName = table.Column<string>(type: "text", nullable: false),
                    GenRoleId = table.Column<Guid>(type: "uuid", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_general_user_info_tbl", x => x.Id);
                    table.ForeignKey(
                        name: "FK_general_user_info_tbl_general_roles_tbl_GenRoleId",
                        column: x => x.GenRoleId,
                        principalTable: "general_roles_tbl",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "staff_roles_tbl",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    StaffRoleCode = table.Column<string>(type: "text", nullable: false),
                    StaffRoleTitle = table.Column<string>(type: "text", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_staff_roles_tbl", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "customes_tbl",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    CustomerCode = table.Column<string>(type: "text", nullable: false),
                    CustomerPoint = table.Column<float>(type: "real", nullable: false),
                    LastPurchaseDate = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    GenUserInfoId = table.Column<Guid>(type: "uuid", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_customes_tbl", x => x.Id);
                    table.ForeignKey(
                        name: "FK_customes_tbl_general_user_info_tbl_GenUserInfoId",
                        column: x => x.GenUserInfoId,
                        principalTable: "general_user_info_tbl",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "staffs_tbl",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    StaffRoleCode = table.Column<string>(type: "text", nullable: false),
                    StaffRoleTitle = table.Column<string>(type: "text", nullable: false),
                    StaffRoleId = table.Column<Guid>(type: "uuid", nullable: false),
                    GenUserInfoId = table.Column<Guid>(type: "uuid", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_staffs_tbl", x => x.Id);
                    table.ForeignKey(
                        name: "FK_staffs_tbl_general_user_info_tbl_GenUserInfoId",
                        column: x => x.GenUserInfoId,
                        principalTable: "general_user_info_tbl",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_staffs_tbl_staff_roles_tbl_StaffRoleId",
                        column: x => x.StaffRoleId,
                        principalTable: "staff_roles_tbl",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_customes_tbl_GenUserInfoId",
                table: "customes_tbl",
                column: "GenUserInfoId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_general_user_info_tbl_GenRoleId",
                table: "general_user_info_tbl",
                column: "GenRoleId");

            migrationBuilder.CreateIndex(
                name: "IX_staffs_tbl_GenUserInfoId",
                table: "staffs_tbl",
                column: "GenUserInfoId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_staffs_tbl_StaffRoleId",
                table: "staffs_tbl",
                column: "StaffRoleId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "customes_tbl");

            migrationBuilder.DropTable(
                name: "staffs_tbl");

            migrationBuilder.DropTable(
                name: "general_user_info_tbl");

            migrationBuilder.DropTable(
                name: "staff_roles_tbl");
        }
    }
}
