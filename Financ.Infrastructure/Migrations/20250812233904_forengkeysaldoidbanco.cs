using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Financ.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class forengkeysaldoidbanco : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_fnc_tb_saldos_AspNetUsers_UserId",
                table: "fnc_tb_saldos");

            migrationBuilder.DropIndex(
                name: "IX_fnc_tb_saldos_UserId",
                table: "fnc_tb_saldos");

            migrationBuilder.AlterColumn<string>(
                name: "UserId",
                table: "fnc_tb_saldos",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(450)");

            migrationBuilder.CreateIndex(
                name: "IX_fnc_tb_saldos_IdBanco",
                table: "fnc_tb_saldos",
                column: "IdBanco");

            migrationBuilder.AddForeignKey(
                name: "FK_fnc_tb_saldos_fnc_tb_banco_IdBanco",
                table: "fnc_tb_saldos",
                column: "IdBanco",
                principalTable: "fnc_tb_banco",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_fnc_tb_saldos_fnc_tb_banco_IdBanco",
                table: "fnc_tb_saldos");

            migrationBuilder.DropIndex(
                name: "IX_fnc_tb_saldos_IdBanco",
                table: "fnc_tb_saldos");

            migrationBuilder.AlterColumn<string>(
                name: "UserId",
                table: "fnc_tb_saldos",
                type: "nvarchar(450)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.CreateIndex(
                name: "IX_fnc_tb_saldos_UserId",
                table: "fnc_tb_saldos",
                column: "UserId");

            migrationBuilder.AddForeignKey(
                name: "FK_fnc_tb_saldos_AspNetUsers_UserId",
                table: "fnc_tb_saldos",
                column: "UserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
