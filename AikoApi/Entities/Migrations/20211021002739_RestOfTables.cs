using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Entities.Migrations
{
    public partial class RestOfTables : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddPrimaryKey(
                name: "PK_equipment_position_history",
                schema: "operation",
                table: "equipment_position_history",
                column: "date");

            migrationBuilder.CreateTable(
                name: "equipment_state",
                schema: "operation",
                columns: table => new
                {
                    id = table.Column<Guid>(type: "uuid", nullable: false),
                    name = table.Column<string>(type: "text", nullable: true),
                    color = table.Column<string>(type: "text", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_equipment_state", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "equipment_model_state_hourly_earnings",
                schema: "operation",
                columns: table => new
                {
                    value = table.Column<double>(type: "double precision", nullable: false),
                    equipment_model_id = table.Column<Guid>(type: "uuid", nullable: false),
                    equipment_state_id = table.Column<Guid>(type: "uuid", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_equipment_model_state_hourly_earnings", x => x.value);
                    table.ForeignKey(
                        name: "FK_equipment_model_state_hourly_earnings_equipment_model_equip~",
                        column: x => x.equipment_model_id,
                        principalSchema: "operation",
                        principalTable: "equipment_model",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_equipment_model_state_hourly_earnings_equipment_state_equip~",
                        column: x => x.equipment_state_id,
                        principalSchema: "operation",
                        principalTable: "equipment_state",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "equipment_state_history",
                schema: "operation",
                columns: table => new
                {
                    date = table.Column<DateTime>(type: "timestamp without time zone", nullable: false),
                    equipment_id = table.Column<Guid>(type: "uuid", nullable: false),
                    equipment_state_id = table.Column<Guid>(type: "uuid", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_equipment_state_history", x => x.date);
                    table.ForeignKey(
                        name: "FK_equipment_state_history_equipment_equipment_id",
                        column: x => x.equipment_id,
                        principalSchema: "operation",
                        principalTable: "equipment",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_equipment_state_history_equipment_state_equipment_state_id",
                        column: x => x.equipment_state_id,
                        principalSchema: "operation",
                        principalTable: "equipment_state",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_equipment_model_state_hourly_earnings_equipment_model_id",
                schema: "operation",
                table: "equipment_model_state_hourly_earnings",
                column: "equipment_model_id");

            migrationBuilder.CreateIndex(
                name: "IX_equipment_model_state_hourly_earnings_equipment_state_id",
                schema: "operation",
                table: "equipment_model_state_hourly_earnings",
                column: "equipment_state_id");

            migrationBuilder.CreateIndex(
                name: "IX_equipment_state_history_equipment_id",
                schema: "operation",
                table: "equipment_state_history",
                column: "equipment_id");

            migrationBuilder.CreateIndex(
                name: "IX_equipment_state_history_equipment_state_id",
                schema: "operation",
                table: "equipment_state_history",
                column: "equipment_state_id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "equipment_model_state_hourly_earnings",
                schema: "operation");

            migrationBuilder.DropTable(
                name: "equipment_state_history",
                schema: "operation");

            migrationBuilder.DropTable(
                name: "equipment_state",
                schema: "operation");

            migrationBuilder.DropPrimaryKey(
                name: "PK_equipment_position_history",
                schema: "operation",
                table: "equipment_position_history");
        }
    }
}
