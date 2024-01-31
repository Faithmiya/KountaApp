using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace KountaApp.Migrations
{
    public partial class ClientDate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<DateTime>(
                name: "StartDate",
                table: "Clients",
                type: "datetime2",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "StartDate",
                table: "Clients");
        }
    }
}
