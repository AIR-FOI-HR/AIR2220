using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DataAccess.Migrations
{
    /// <inheritdoc />
    public partial class secondMigration : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Logs_Gates_GateId",
                table: "Logs");

            migrationBuilder.AlterColumn<string>(
                name: "GateId",
                table: "Logs",
                type: "nvarchar(450)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(450)");

            migrationBuilder.AddForeignKey(
                name: "FK_Logs_Gates_GateId",
                table: "Logs",
                column: "GateId",
                principalTable: "Gates",
                principalColumn: "GateId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Logs_Gates_GateId",
                table: "Logs");

            migrationBuilder.AlterColumn<string>(
                name: "GateId",
                table: "Logs",
                type: "nvarchar(450)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(450)",
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Logs_Gates_GateId",
                table: "Logs",
                column: "GateId",
                principalTable: "Gates",
                principalColumn: "GateId",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
