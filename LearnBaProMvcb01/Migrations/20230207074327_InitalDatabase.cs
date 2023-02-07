using Microsoft.EntityFrameworkCore.Migrations;

namespace LearnBaProMvcb01.Migrations
{
    public partial class InitalDatabase : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Departments",
                columns: table => new
                {
                    IdDept = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    NameDept = table.Column<string>(type: "nvarchar(250)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Departments", x => x.IdDept);
                });

            migrationBuilder.CreateTable(
                name: "Employees",
                columns: table => new
                {
                    IdEmp = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    NameEmp = table.Column<string>(type: "nvarchar(250)", nullable: false),
                    Position = table.Column<string>(type: "nvarchar(250)", nullable: false),
                    PhotoPath = table.Column<string>(type: "nvarchar(500)", nullable: true),
                    EnrollDate = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    IdDept = table.Column<int>(type: "int", nullable: false),
                    DepartmentIdDept = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Employees", x => x.IdEmp);
                    table.ForeignKey(
                        name: "FK_Employees_Departments_DepartmentIdDept",
                        column: x => x.DepartmentIdDept,
                        principalTable: "Departments",
                        principalColumn: "IdDept",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Employees_DepartmentIdDept",
                table: "Employees",
                column: "DepartmentIdDept");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Employees");

            migrationBuilder.DropTable(
                name: "Departments");
        }
    }
}
