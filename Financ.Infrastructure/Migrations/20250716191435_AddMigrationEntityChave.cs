using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Financ.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class AddMigrationEntityChave : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "UserId",
                table: "fnc_tb_creditos",
                type: "nvarchar(450)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.CreateIndex(
                name: "IX_fnc_tb_creditos_UserId",
                table: "fnc_tb_creditos",
                column: "UserId");

            migrationBuilder.AddForeignKey(
                name: "FK_fnc_tb_creditos_AspNetUsers_UserId",
                table: "fnc_tb_creditos",
                column: "UserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_fnc_tb_creditos_AspNetUsers_UserId",
                table: "fnc_tb_creditos");

            migrationBuilder.DropIndex(
                name: "IX_fnc_tb_creditos_UserId",
                table: "fnc_tb_creditos");

            migrationBuilder.AlterColumn<string>(
                name: "UserId",
                table: "fnc_tb_creditos",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(450)");
        }
    }
}
