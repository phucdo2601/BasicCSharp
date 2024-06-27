using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace PracNet7ApiProB01.Model.Migrations
{
    /// <inheritdoc />
    public partial class DbUpdateidtypeb01 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "general_roles_tbl",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    GenRoleCode = table.Column<string>(type: "text", nullable: false),
                    GenRoleTitle = table.Column<string>(type: "text", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_general_roles_tbl", x => x.Id);
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "general_roles_tbl");
        }
    }
}
