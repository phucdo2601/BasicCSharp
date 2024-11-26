using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace BlogWebApi.Model.Migrations
{
    /// <inheritdoc />
    public partial class Updateroledefdataroles_tblb01 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "roles_tbl",
                columns: new[] { "Id", "DateOfCreated", "DateOfModified", "RoleTitle" },
                values: new object[,]
                {
                    { new Guid("9f0533a2-64fd-40e5-a454-a39771a52ab7"), new DateTime(2024, 11, 26, 8, 49, 47, 688, DateTimeKind.Local).AddTicks(4765), new DateTime(2024, 11, 26, 8, 49, 47, 688, DateTimeKind.Local).AddTicks(4768), "USER" },
                    { new Guid("b7e215a2-a31b-4c75-af65-9485cb9bdaa0"), new DateTime(2024, 11, 26, 8, 49, 47, 687, DateTimeKind.Local).AddTicks(246), new DateTime(2024, 11, 26, 8, 49, 47, 688, DateTimeKind.Local).AddTicks(4484), "ADMIN" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "roles_tbl",
                keyColumn: "Id",
                keyValue: new Guid("9f0533a2-64fd-40e5-a454-a39771a52ab7"));

            migrationBuilder.DeleteData(
                table: "roles_tbl",
                keyColumn: "Id",
                keyValue: new Guid("b7e215a2-a31b-4c75-af65-9485cb9bdaa0"));
        }
    }
}
