using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Infrastructure.Persistence.Migrations
{
    public partial class Models2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "CreatedBy",
                table: "Notas");

            migrationBuilder.DropColumn(
                name: "LastModifiedBy",
                table: "Notas");

            migrationBuilder.AddColumn<DateTime>(
                name: "Created",
                table: "equipment_state_history",
                type: "timestamp without time zone",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<DateTime>(
                name: "LastModified",
                table: "equipment_state_history",
                type: "timestamp without time zone",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "Created",
                table: "equipment_position_history",
                type: "timestamp without time zone",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<DateTime>(
                name: "LastModified",
                table: "equipment_position_history",
                type: "timestamp without time zone",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "Created",
                table: "equipment_model_state_hourly_earnings",
                type: "timestamp without time zone",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<DateTime>(
                name: "LastModified",
                table: "equipment_model_state_hourly_earnings",
                type: "timestamp without time zone",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "Created",
                table: "equipment_Model",
                type: "timestamp without time zone",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<DateTime>(
                name: "LastModified",
                table: "equipment_Model",
                type: "timestamp without time zone",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "Created",
                table: "equipment",
                type: "timestamp without time zone",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<DateTime>(
                name: "LastModified",
                table: "equipment",
                type: "timestamp without time zone",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Created",
                table: "equipment_state_history");

            migrationBuilder.DropColumn(
                name: "LastModified",
                table: "equipment_state_history");

            migrationBuilder.DropColumn(
                name: "Created",
                table: "equipment_position_history");

            migrationBuilder.DropColumn(
                name: "LastModified",
                table: "equipment_position_history");

            migrationBuilder.DropColumn(
                name: "Created",
                table: "equipment_model_state_hourly_earnings");

            migrationBuilder.DropColumn(
                name: "LastModified",
                table: "equipment_model_state_hourly_earnings");

            migrationBuilder.DropColumn(
                name: "Created",
                table: "equipment_Model");

            migrationBuilder.DropColumn(
                name: "LastModified",
                table: "equipment_Model");

            migrationBuilder.DropColumn(
                name: "Created",
                table: "equipment");

            migrationBuilder.DropColumn(
                name: "LastModified",
                table: "equipment");

            migrationBuilder.AddColumn<string>(
                name: "CreatedBy",
                table: "Notas",
                type: "text",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "LastModifiedBy",
                table: "Notas",
                type: "text",
                nullable: true);
        }
    }
}
