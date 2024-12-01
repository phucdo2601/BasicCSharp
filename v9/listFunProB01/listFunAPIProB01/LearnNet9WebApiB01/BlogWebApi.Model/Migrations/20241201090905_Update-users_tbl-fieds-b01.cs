using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace BlogWebApi.Model.Migrations
{
    /// <inheritdoc />
    public partial class Updateusers_tblfiedsb01 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "roles_tbl",
                keyColumn: "Id",
                keyValue: new Guid("1a633bf0-09ba-4ad2-9c0e-2fb61fba200a"));

            migrationBuilder.DeleteData(
                table: "roles_tbl",
                keyColumn: "Id",
                keyValue: new Guid("ef367267-a0cc-4608-b549-358e10a6c405"));

            migrationBuilder.RenameColumn(
                name: "Passord",
                table: "users_tbl",
                newName: "Password");

            migrationBuilder.InsertData(
                table: "roles_tbl",
                columns: new[] { "Id", "DateOfCreated", "DateOfModified", "RoleTitle" },
                values: new object[,]
                {
                    { new Guid("15baee4b-c6fb-47ec-871a-e798ab9c5594"), new DateTime(2024, 12, 1, 16, 9, 4, 536, DateTimeKind.Local).AddTicks(7937), new DateTime(2024, 12, 1, 16, 9, 4, 536, DateTimeKind.Local).AddTicks(7940), "USER" },
                    { new Guid("81c2a943-c473-4fa4-b437-6b6d442d1f69"), new DateTime(2024, 12, 1, 16, 9, 4, 535, DateTimeKind.Local).AddTicks(4087), new DateTime(2024, 12, 1, 16, 9, 4, 536, DateTimeKind.Local).AddTicks(7579), "ADMIN" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "roles_tbl",
                keyColumn: "Id",
                keyValue: new Guid("15baee4b-c6fb-47ec-871a-e798ab9c5594"));

            migrationBuilder.DeleteData(
                table: "roles_tbl",
                keyColumn: "Id",
                keyValue: new Guid("81c2a943-c473-4fa4-b437-6b6d442d1f69"));

            migrationBuilder.RenameColumn(
                name: "Password",
                table: "users_tbl",
                newName: "Passord");

            migrationBuilder.InsertData(
                table: "roles_tbl",
                columns: new[] { "Id", "DateOfCreated", "DateOfModified", "RoleTitle" },
                values: new object[,]
                {
                    { new Guid("1a633bf0-09ba-4ad2-9c0e-2fb61fba200a"), new DateTime(2024, 11, 27, 9, 16, 50, 723, DateTimeKind.Local).AddTicks(1534), new DateTime(2024, 11, 27, 9, 16, 50, 724, DateTimeKind.Local).AddTicks(981), "ADMIN" },
                    { new Guid("ef367267-a0cc-4608-b549-358e10a6c405"), new DateTime(2024, 11, 27, 9, 16, 50, 724, DateTimeKind.Local).AddTicks(1181), new DateTime(2024, 11, 27, 9, 16, 50, 724, DateTimeKind.Local).AddTicks(1182), "USER" }
                });
        }
    }
}
