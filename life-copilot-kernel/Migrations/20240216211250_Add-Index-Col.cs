using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace life_copilot_kernel.Migrations
{
    /// <inheritdoc />
    public partial class AddIndexCol : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "index",
                table: "Actions",
                type: "integer",
                nullable: false,
                defaultValue: 0);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "index",
                table: "Actions");
        }
    }
}
