using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DesarrolloTec.API.Migrations
{
    /// <inheritdoc />
    public partial class endTable : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Employees_Projects_ProjectsId",
                table: "Employees");

            migrationBuilder.DropIndex(
                name: "IX_Employees_ProjectsId",
                table: "Employees");

            migrationBuilder.DropColumn(
                name: "ProjectsId",
                table: "Employees");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "ProjectsId",
                table: "Employees",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Employees_ProjectsId",
                table: "Employees",
                column: "ProjectsId");

            migrationBuilder.AddForeignKey(
                name: "FK_Employees_Projects_ProjectsId",
                table: "Employees",
                column: "ProjectsId",
                principalTable: "Projects",
                principalColumn: "Id");
        }
    }
}
