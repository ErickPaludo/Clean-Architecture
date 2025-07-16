using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Financ.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class desativhafkdebito : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_fnc_tb_debitos_AspNetUsers_UserId",
                table: "fnc_tb_debitos");

            migrationBuilder.DropIndex(
                name: "IX_fnc_tb_debitos_UserId",
                table: "fnc_tb_debitos");

            migrationBuilder.AlterColumn<string>(
                name: "UserId",
                table: "fnc_tb_debitos",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(450)");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "UserId",
                table: "fnc_tb_debitos",
                type: "nvarchar(450)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

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
        }
    }
}
