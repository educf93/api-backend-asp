using Microsoft.EntityFrameworkCore.Migrations;

namespace apigtt.Migrations
{
    public partial class UpdateColumn : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "issuer",
                table: "Jira",
                newName: "issue");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "issue",
                table: "Jira",
                newName: "issuer");
        }
    }
}
