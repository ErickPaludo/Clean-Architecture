using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Financ.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class IncluiIdFixoIdBanco : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "IdBanco",
                table: "fnc_tb_saldos",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "IdFixo",
                table: "fnc_tb_saldos",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "IdBanco",
                table: "fnc_tb_debitos",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "IdFixo",
                table: "fnc_tb_debitos",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "IdBanco",
                table: "fnc_tb_creditos",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "IdFixo",
                table: "fnc_tb_creditos",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "IdBanco",
                table: "fnc_tb_saldos");

            migrationBuilder.DropColumn(
                name: "IdFixo",
                table: "fnc_tb_saldos");

            migrationBuilder.DropColumn(
                name: "IdBanco",
                table: "fnc_tb_debitos");

            migrationBuilder.DropColumn(
                name: "IdFixo",
                table: "fnc_tb_debitos");

            migrationBuilder.DropColumn(
                name: "IdBanco",
                table: "fnc_tb_creditos");

            migrationBuilder.DropColumn(
                name: "IdFixo",
                table: "fnc_tb_creditos");
        }
    }
}
