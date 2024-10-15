using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;

namespace EFCore.Domain.Data.Migrations;

[Migration("1_InitialMigration")]
[DbContext(typeof(DemoContext))]
public class InitialMigration : Migration
{
    protected override void Up(MigrationBuilder migrationBuilder)
    {
        migrationBuilder.CreateTable(
            name: "Vehicles",
            columns: table => new
            {
                Id = table.Column<int>().Annotation("SqlServer:Identity", "1, 1"),
                Vin = table.Column<string>(maxLength: 17)
            },
            constraints: table => { table.PrimaryKey("PK_Vehicles", x => x.Id); }
        );
        migrationBuilder.CreateTable(
            name: "People",
            columns: table => new
            {
                Id = table.Column<int>().Annotation("SqlServer:Identity", "1, 1"),
                FirstName = table.Column<string>(maxLength: 128),
                LastName = table.Column<string>(maxLength: 128)
            },
            constraints: table => { table.PrimaryKey("PK_People", x => x.Id); }
        );
        migrationBuilder.CreateTable(
            name: "VehicleOwners",
            columns: table => new
            {
                VehicleId = table.Column<int>(),
                PersonId = table.Column<int>(),
                From = table.Column<DateTime>(),
                To = table.Column<DateTime>(nullable: true)
            },
            constraints: table =>
            {
                table.PrimaryKey("PK_VehicleOwners", x => new { x.VehicleId });
                table.ForeignKey(
                    name: "FK_VehicleOwners_People_PersonId",
                    column: x => x.PersonId,
                    principalTable: "People",
                    principalColumn: "Id",
                    onDelete: ReferentialAction.Cascade
                );
                table.ForeignKey(
                    name: "FK_VehicleOwners_Vehicles_VehicleId",
                    column: x => x.VehicleId,
                    principalTable: "Vehicles",
                    principalColumn: "Id",
                    onDelete: ReferentialAction.Cascade
                );
            }
        );

        migrationBuilder.CreateIndex(
            name: "IX_Vehicles_VIN",
            table: "Vehicles",
            column: "VIN"
        );
        migrationBuilder.CreateIndex(
            name: "IX_VehicleOwners_PersonId",
            table: "VehicleOwners",
            column: "PersonId"
        );
    }

    protected override void Down(MigrationBuilder migrationBuilder)
    {
    }
}