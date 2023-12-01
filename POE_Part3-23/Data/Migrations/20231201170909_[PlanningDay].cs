using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace POE_Part3_23.Data.Migrations
{
    public partial class PlanningDay : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "PlannedDay",
                table: "Modules",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "PlannedDay",
                table: "Modules");
        }
    }
}
