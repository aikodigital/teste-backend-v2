using Microsoft.EntityFrameworkCore.Migrations;

namespace Infrastructure.Persistence.Migrations
{
    public partial class state : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "equipment_State",
                columns: new[] { "id", "name" },
                values: new object[,]
                {
                    { 1, "Operando" },
                    { 2, "Parado" },
                    { 4, "Manutenção" }
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "equipment_State",
                keyColumn: "id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "equipment_State",
                keyColumn: "id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "equipment_State",
                keyColumn: "id",
                keyValue: 4);
        }
    }
}
