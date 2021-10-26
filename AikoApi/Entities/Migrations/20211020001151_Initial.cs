using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Entities.Migrations
{
    public partial class Initial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.EnsureSchema(
                name: "operation");

            migrationBuilder.CreateTable(
                name: "equipment_model",
                schema: "operation",
                columns: table => new
                {
                    id = table.Column<Guid>(type: "uuid", nullable: false),
                    name = table.Column<string>(type: "text", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_equipment_model", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "equipment",
                schema: "operation",
                columns: table => new
                {
                    id = table.Column<Guid>(type: "uuid", nullable: false),
                    equipment_model_id = table.Column<Guid>(type: "uuid", nullable: false),
                    name = table.Column<string>(type: "text", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_equipment", x => x.id);
                    table.ForeignKey(
                        name: "FK_equipment_equipment_model_equipment_model_id",
                        column: x => x.equipment_model_id,
                        principalSchema: "operation",
                        principalTable: "equipment_model",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_equipment_equipment_model_id",
                schema: "operation",
                table: "equipment",
                column: "equipment_model_id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "equipment",
                schema: "operation");

            migrationBuilder.DropTable(
                name: "equipment_model",
                schema: "operation");
        }
    }
}
