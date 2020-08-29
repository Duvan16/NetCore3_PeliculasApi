using Microsoft.EntityFrameworkCore.Migrations;
using NetTopologySuite.Geometries;

namespace NetCore3_PeliculasApi.Migrations
{
    public partial class SalaDeCineUbicacion : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<Point>(
                name: "Ubicacion",
                table: "SalaDeCine",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Ubicacion",
                table: "SalaDeCine");
        }
    }
}
