using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace life_copilot_kernel.Migrations
{
    /// <inheritdoc />
    public partial class ChangeColumnType : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Status",
                table: "Actions");

            migrationBuilder.AddColumn<bool>(
                name: "isDone",
                table: "Actions",
                type: "boolean",
                nullable: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "isDone",
                table: "Actions");

            migrationBuilder.AddColumn<string>(
                name: "Status",
                table: "Actions",
                type: "text",
                nullable: true);
        }
    }
}
