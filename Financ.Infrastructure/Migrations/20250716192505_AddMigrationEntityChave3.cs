using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Financ.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class AddMigrationEntityChave3 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "UserId",
                table: "fnc_tb_saldos",
                type: "nvarchar(450)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AlterColumn<string>(
                name: "UserId",
                table: "fnc_tb_parcelas",
                type: "nvarchar(450)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AlterColumn<string>(
                name: "UserId",
                table: "fnc_tb_debitos",
                type: "nvarchar(450)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.CreateIndex(
                name: "IX_fnc_tb_saldos_UserId",
                table: "fnc_tb_saldos",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_fnc_tb_parcelas_UserId",
                table: "fnc_tb_parcelas",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_fnc_tb_debitos_UserId",
                table: "fnc_tb_debitos",
                column: "UserId");

            migrationBuilder.AddForeignKey(
                name: "FK_fnc_tb_debitos_AspNetUsers_UserId",
                table: "fnc_tb_debitos",
                column: "UserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_fnc_tb_parcelas_AspNetUsers_UserId",
                table: "fnc_tb_parcelas",
                column: "UserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_fnc_tb_saldos_AspNetUsers_UserId",
                table: "fnc_tb_saldos",
                column: "UserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_fnc_tb_debitos_AspNetUsers_UserId",
                table: "fnc_tb_debitos");

            migrationBuilder.DropForeignKey(
                name: "FK_fnc_tb_parcelas_AspNetUsers_UserId",
                table: "fnc_tb_parcelas");

            migrationBuilder.DropForeignKey(
                name: "FK_fnc_tb_saldos_AspNetUsers_UserId",
                table: "fnc_tb_saldos");

            migrationBuilder.DropIndex(
                name: "IX_fnc_tb_saldos_UserId",
                table: "fnc_tb_saldos");

            migrationBuilder.DropIndex(
                name: "IX_fnc_tb_parcelas_UserId",
                table: "fnc_tb_parcelas");

            migrationBuilder.DropIndex(
                name: "IX_fnc_tb_debitos_UserId",
                table: "fnc_tb_debitos");

            migrationBuilder.AlterColumn<string>(
                name: "UserId",
                table: "fnc_tb_saldos",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(450)");

            migrationBuilder.AlterColumn<string>(
                name: "UserId",
                table: "fnc_tb_parcelas",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(450)");

            migrationBuilder.AlterColumn<string>(
                name: "UserId",
                table: "fnc_tb_debitos",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(450)");
        }
    }
}
