using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace WebApplicationUI.Migrations
{
    public partial class CreatedDateDefault : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedUserId",
                table: "Todos",
                nullable: false,
                defaultValueSql: "DATEADD(HOUR,4,getutcdate())",
                oldClrType: typeof(DateTime),
                oldType: "datetime2");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedUserId",
                table: "Todos",
                type: "datetime2",
                nullable: false,
                oldClrType: typeof(DateTime),
                oldDefaultValueSql: "DATEADD(HOUR,4,getutcdate())");
        }
    }
}
