using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Rehber.Infrastructure.Migrations
{
    public partial class CreateReportQueu : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Contacts_Persons_PersonUUID",
                table: "Contacts");

            migrationBuilder.AlterColumn<Guid>(
                name: "PersonUUID",
                table: "Contacts",
                type: "uuid",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"),
                oldClrType: typeof(Guid),
                oldType: "uuid",
                oldNullable: true);

            migrationBuilder.CreateTable(
                name: "ReportQueus",
                columns: table => new
                {
                    UUID = table.Column<Guid>(type: "uuid", nullable: false),
                    State = table.Column<int>(type: "integer", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    UpdatedAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ReportQueus", x => x.UUID);
                });

            migrationBuilder.AddForeignKey(
                name: "FK_Contacts_Persons_PersonUUID",
                table: "Contacts",
                column: "PersonUUID",
                principalTable: "Persons",
                principalColumn: "UUID",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Contacts_Persons_PersonUUID",
                table: "Contacts");

            migrationBuilder.DropTable(
                name: "ReportQueus");

            migrationBuilder.AlterColumn<Guid>(
                name: "PersonUUID",
                table: "Contacts",
                type: "uuid",
                nullable: true,
                oldClrType: typeof(Guid),
                oldType: "uuid");

            migrationBuilder.AddForeignKey(
                name: "FK_Contacts_Persons_PersonUUID",
                table: "Contacts",
                column: "PersonUUID",
                principalTable: "Persons",
                principalColumn: "UUID");
        }
    }
}
