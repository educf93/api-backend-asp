using Microsoft.EntityFrameworkCore.Migrations;

namespace apigtt.Migrations
{
    public partial class SomeChangesMigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "component",
                table: "Jira",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "description",
                table: "Jira",
                nullable: true);

            migrationBuilder.AddColumn<long>(
                name: "iduser",
                table: "Jira",
                nullable: false,
                defaultValue: 0L);

            migrationBuilder.AddColumn<string>(
                name: "issuer",
                table: "Jira",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "proyect",
                table: "Jira",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "url",
                table: "Jira",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "notice",
                table: "Certificates",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "ticketed",
                table: "Certificates",
                nullable: false,
                defaultValue: false);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "component",
                table: "Jira");

            migrationBuilder.DropColumn(
                name: "description",
                table: "Jira");

            migrationBuilder.DropColumn(
                name: "iduser",
                table: "Jira");

            migrationBuilder.DropColumn(
                name: "issuer",
                table: "Jira");

            migrationBuilder.DropColumn(
                name: "proyect",
                table: "Jira");

            migrationBuilder.DropColumn(
                name: "url",
                table: "Jira");

            migrationBuilder.DropColumn(
                name: "notice",
                table: "Certificates");

            migrationBuilder.DropColumn(
                name: "ticketed",
                table: "Certificates");
        }
    }
}
