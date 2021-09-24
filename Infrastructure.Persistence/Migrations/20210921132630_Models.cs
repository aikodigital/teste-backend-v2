using System;
using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

namespace Infrastructure.Persistence.Migrations
{
    public partial class Models : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "equipment_Model",
                columns: table => new
                {
                    id = table.Column<Guid>(type: "uuid", nullable: false),
                    name = table.Column<string>(type: "text", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_equipment_Model", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "equipment_State",
                columns: table => new
                {
                    id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    name = table.Column<string>(type: "text", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_equipment_State", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "equipment",
                columns: table => new
                {
                    id = table.Column<Guid>(type: "uuid", nullable: false),
                    name = table.Column<string>(type: "text", nullable: true),
                    equipment_model_id = table.Column<Guid>(type: "uuid", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_equipment", x => x.id);
                    table.ForeignKey(
                        name: "FK_equipment_equipment_Model_equipment_model_id",
                        column: x => x.equipment_model_id,
                        principalTable: "equipment_Model",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "equipment_model_state_hourly_earnings",
                columns: table => new
                {
                    id = table.Column<Guid>(type: "uuid", nullable: false),
                    equipment_model_id = table.Column<Guid>(type: "uuid", nullable: false),
                    equipment_state_id = table.Column<int>(type: "integer", nullable: false),
                    value = table.Column<double>(type: "double precision", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_equipment_model_state_hourly_earnings", x => x.id);
                    table.ForeignKey(
                        name: "FK_equipment_model_state_hourly_earnings_equipment_Model_equip~",
                        column: x => x.equipment_model_id,
                        principalTable: "equipment_Model",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_equipment_model_state_hourly_earnings_equipment_State_equip~",
                        column: x => x.equipment_state_id,
                        principalTable: "equipment_State",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "equipment_position_history",
                columns: table => new
                {
                    id = table.Column<Guid>(type: "uuid", nullable: false),
                    equipment_id = table.Column<Guid>(type: "uuid", nullable: false),
                    date = table.Column<DateTime>(type: "timestamp without time zone", nullable: false),
                    lat = table.Column<double>(type: "double precision", nullable: false),
                    lon = table.Column<double>(type: "double precision", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_equipment_position_history", x => x.id);
                    table.ForeignKey(
                        name: "FK_equipment_position_history_equipment_equipment_id",
                        column: x => x.equipment_id,
                        principalTable: "equipment",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "equipment_state_history",
                columns: table => new
                {
                    id = table.Column<Guid>(type: "uuid", nullable: false),
                    equipment_id = table.Column<Guid>(type: "uuid", nullable: false),
                    date = table.Column<DateTime>(type: "timestamp without time zone", nullable: false),
                    equipment_state_id = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_equipment_state_history", x => x.id);
                    table.ForeignKey(
                        name: "FK_equipment_state_history_equipment_equipment_id",
                        column: x => x.equipment_id,
                        principalTable: "equipment",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_equipment_state_history_equipment_State_equipment_state_id",
                        column: x => x.equipment_state_id,
                        principalTable: "equipment_State",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_equipment_equipment_model_id",
                table: "equipment",
                column: "equipment_model_id");

            migrationBuilder.CreateIndex(
                name: "IX_equipment_model_state_hourly_earnings_equipment_model_id",
                table: "equipment_model_state_hourly_earnings",
                column: "equipment_model_id");

            migrationBuilder.CreateIndex(
                name: "IX_equipment_model_state_hourly_earnings_equipment_state_id",
                table: "equipment_model_state_hourly_earnings",
                column: "equipment_state_id");

            migrationBuilder.CreateIndex(
                name: "IX_equipment_position_history_equipment_id",
                table: "equipment_position_history",
                column: "equipment_id");

            migrationBuilder.CreateIndex(
                name: "IX_equipment_state_history_equipment_id",
                table: "equipment_state_history",
                column: "equipment_id");

            migrationBuilder.CreateIndex(
                name: "IX_equipment_state_history_equipment_state_id",
                table: "equipment_state_history",
                column: "equipment_state_id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "equipment_model_state_hourly_earnings");

            migrationBuilder.DropTable(
                name: "equipment_position_history");

            migrationBuilder.DropTable(
                name: "equipment_state_history");

            migrationBuilder.DropTable(
                name: "equipment");

            migrationBuilder.DropTable(
                name: "equipment_State");

            migrationBuilder.DropTable(
                name: "equipment_Model");
        }
    }
}
