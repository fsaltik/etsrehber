using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Rehber.Infrastructure.Migrations
{
    public partial class AddColumntoTables : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "UpdateDateTime",
                table: "Persons",
                newName: "UpdatedAt");

            migrationBuilder.RenameColumn(
                name: "CreateDateTime",
                table: "Persons",
                newName: "CreatedAt");

            migrationBuilder.RenameColumn(
                name: "Ad",
                table: "Persons",
                newName: "SurName");

            migrationBuilder.RenameColumn(
                name: "UpdateDateTime",
                table: "Contacts",
                newName: "UpdatedAt");

            migrationBuilder.RenameColumn(
                name: "CreateDateTime",
                table: "Contacts",
                newName: "CreatedAt");

            migrationBuilder.AddColumn<string>(
                name: "Email",
                table: "Contacts",
                type: "text",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "Location",
                table: "Contacts",
                type: "text",
                nullable: false,
                defaultValue: "");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Email",
                table: "Contacts");

            migrationBuilder.DropColumn(
                name: "Location",
                table: "Contacts");

            migrationBuilder.RenameColumn(
                name: "UpdatedAt",
                table: "Persons",
                newName: "UpdateDateTime");

            migrationBuilder.RenameColumn(
                name: "SurName",
                table: "Persons",
                newName: "Ad");

            migrationBuilder.RenameColumn(
                name: "CreatedAt",
                table: "Persons",
                newName: "CreateDateTime");

            migrationBuilder.RenameColumn(
                name: "UpdatedAt",
                table: "Contacts",
                newName: "UpdateDateTime");

            migrationBuilder.RenameColumn(
                name: "CreatedAt",
                table: "Contacts",
                newName: "CreateDateTime");
        }
    }
}
