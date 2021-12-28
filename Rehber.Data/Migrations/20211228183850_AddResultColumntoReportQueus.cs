using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Rehber.Infrastructure.Migrations
{
    public partial class AddResultColumntoReportQueus : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<byte[]>(
                name: "Result",
                table: "ReportQueus",
                type: "bytea",
                nullable: false,
                defaultValue: new byte[0]);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Result",
                table: "ReportQueus");
        }
    }
}
