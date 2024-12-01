using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace BlogWebApi.Model.Migrations
{
    /// <inheritdoc />
    public partial class DbUpdateConfigdtypeblogs_tblb01 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "roles_tbl",
                keyColumn: "Id",
                keyValue: new Guid("9f0533a2-64fd-40e5-a454-a39771a52ab7"));

            migrationBuilder.DeleteData(
                table: "roles_tbl",
                keyColumn: "Id",
                keyValue: new Guid("b7e215a2-a31b-4c75-af65-9485cb9bdaa0"));

            migrationBuilder.AlterColumn<string>(
                name: "Content",
                table: "blogs_tbl",
                type: "ntext",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.InsertData(
                table: "roles_tbl",
                columns: new[] { "Id", "DateOfCreated", "DateOfModified", "RoleTitle" },
                values: new object[,]
                {
                    { new Guid("1a633bf0-09ba-4ad2-9c0e-2fb61fba200a"), new DateTime(2024, 11, 27, 9, 16, 50, 723, DateTimeKind.Local).AddTicks(1534), new DateTime(2024, 11, 27, 9, 16, 50, 724, DateTimeKind.Local).AddTicks(981), "ADMIN" },
                    { new Guid("ef367267-a0cc-4608-b549-358e10a6c405"), new DateTime(2024, 11, 27, 9, 16, 50, 724, DateTimeKind.Local).AddTicks(1181), new DateTime(2024, 11, 27, 9, 16, 50, 724, DateTimeKind.Local).AddTicks(1182), "USER" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "roles_tbl",
                keyColumn: "Id",
                keyValue: new Guid("1a633bf0-09ba-4ad2-9c0e-2fb61fba200a"));

            migrationBuilder.DeleteData(
                table: "roles_tbl",
                keyColumn: "Id",
                keyValue: new Guid("ef367267-a0cc-4608-b549-358e10a6c405"));

            migrationBuilder.AlterColumn<string>(
                name: "Content",
                table: "blogs_tbl",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "ntext");

            migrationBuilder.InsertData(
                table: "roles_tbl",
                columns: new[] { "Id", "DateOfCreated", "DateOfModified", "RoleTitle" },
                values: new object[,]
                {
                    { new Guid("9f0533a2-64fd-40e5-a454-a39771a52ab7"), new DateTime(2024, 11, 26, 8, 49, 47, 688, DateTimeKind.Local).AddTicks(4765), new DateTime(2024, 11, 26, 8, 49, 47, 688, DateTimeKind.Local).AddTicks(4768), "USER" },
                    { new Guid("b7e215a2-a31b-4c75-af65-9485cb9bdaa0"), new DateTime(2024, 11, 26, 8, 49, 47, 687, DateTimeKind.Local).AddTicks(246), new DateTime(2024, 11, 26, 8, 49, 47, 688, DateTimeKind.Local).AddTicks(4484), "ADMIN" }
                });
        }
    }
}
