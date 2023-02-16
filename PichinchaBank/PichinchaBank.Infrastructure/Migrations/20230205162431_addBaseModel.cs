using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace PichinchaBank.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class addBaseModel : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Type",
                table: "BankTransactions",
                newName: "TransactionType");

            migrationBuilder.AddColumn<DateTime>(
                name: "CreateDate",
                table: "Clients",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreateDate",
                table: "BankTransactions",
                type: "datetime2",
                nullable: true,
                oldClrType: typeof(DateTime),
                oldType: "datetime2");

            migrationBuilder.AddColumn<bool>(
                name: "State",
                table: "BankTransactions",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<DateTime>(
                name: "CreateDate",
                table: "Accounts",
                type: "datetime2",
                nullable: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "CreateDate",
                table: "Clients");

            migrationBuilder.DropColumn(
                name: "State",
                table: "BankTransactions");

            migrationBuilder.DropColumn(
                name: "CreateDate",
                table: "Accounts");

            migrationBuilder.RenameColumn(
                name: "TransactionType",
                table: "BankTransactions",
                newName: "Type");

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreateDate",
                table: "BankTransactions",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldNullable: true);
        }
    }
}
