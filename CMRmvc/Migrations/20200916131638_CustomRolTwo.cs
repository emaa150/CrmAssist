using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace CMRmvc.Migrations
{
    public partial class CustomRolTwo : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "IsActive",
                table: "AspNetRoles",
                nullable: true,
                defaultValue: false);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "IsActive",
                table: "AspNetRoles");
        }
    }
}
