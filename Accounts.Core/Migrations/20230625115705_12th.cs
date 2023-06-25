using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Accounts.Core.Migrations
{
    public partial class _12th : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "PayeeAcContactId",
                table: "AccountTransDetail");

            migrationBuilder.DropColumn(
                name: "PayeeAcLedgerId",
                table: "AccountTransDetail");

            migrationBuilder.DropColumn(
                name: "PayeeAcSubLedgerId",
                table: "AccountTransDetail");

            migrationBuilder.DropColumn(
                name: "ReceiverAcContactId",
                table: "AccountTransDetail");

            migrationBuilder.RenameColumn(
                name: "ReceiverRemarks",
                table: "AccountTransDetail",
                newName: "Remarks");

            migrationBuilder.RenameColumn(
                name: "ReceiverAcSubLedgerId",
                table: "AccountTransDetail",
                newName: "AccountId");

            migrationBuilder.RenameColumn(
                name: "ReceiverAcLedgerId",
                table: "AccountTransDetail",
                newName: "AcContactId");

            migrationBuilder.RenameColumn(
                name: "PayeeRemarks",
                table: "AccountTransDetail",
                newName: "ChqTrType");

            migrationBuilder.RenameColumn(
                name: "ChqNum",
                table: "AccountTransDetail",
                newName: "ChqTrIdNum");

            migrationBuilder.RenameColumn(
                name: "ChqDate",
                table: "AccountTransDetail",
                newName: "ChqTrDate");

            migrationBuilder.RenameColumn(
                name: "Amount",
                table: "AccountTransDetail",
                newName: "DebitAmount");

            migrationBuilder.AddColumn<string>(
                name: "AcTitle",
                table: "AccountTransDetail",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Bank",
                table: "AccountTransDetail",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "BankBranch",
                table: "AccountTransDetail",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "ChqTrTitle",
                table: "AccountTransDetail",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<decimal>(
                name: "CreditAmount",
                table: "AccountTransDetail",
                type: "decimal(19,4)",
                nullable: false,
                defaultValue: 0m);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "AcTitle",
                table: "AccountTransDetail");

            migrationBuilder.DropColumn(
                name: "Bank",
                table: "AccountTransDetail");

            migrationBuilder.DropColumn(
                name: "BankBranch",
                table: "AccountTransDetail");

            migrationBuilder.DropColumn(
                name: "ChqTrTitle",
                table: "AccountTransDetail");

            migrationBuilder.DropColumn(
                name: "CreditAmount",
                table: "AccountTransDetail");

            migrationBuilder.RenameColumn(
                name: "Remarks",
                table: "AccountTransDetail",
                newName: "ReceiverRemarks");

            migrationBuilder.RenameColumn(
                name: "DebitAmount",
                table: "AccountTransDetail",
                newName: "Amount");

            migrationBuilder.RenameColumn(
                name: "ChqTrType",
                table: "AccountTransDetail",
                newName: "PayeeRemarks");

            migrationBuilder.RenameColumn(
                name: "ChqTrIdNum",
                table: "AccountTransDetail",
                newName: "ChqNum");

            migrationBuilder.RenameColumn(
                name: "ChqTrDate",
                table: "AccountTransDetail",
                newName: "ChqDate");

            migrationBuilder.RenameColumn(
                name: "AccountId",
                table: "AccountTransDetail",
                newName: "ReceiverAcSubLedgerId");

            migrationBuilder.RenameColumn(
                name: "AcContactId",
                table: "AccountTransDetail",
                newName: "ReceiverAcLedgerId");

            migrationBuilder.AddColumn<long>(
                name: "PayeeAcContactId",
                table: "AccountTransDetail",
                type: "bigint",
                nullable: false,
                defaultValue: 0L);

            migrationBuilder.AddColumn<long>(
                name: "PayeeAcLedgerId",
                table: "AccountTransDetail",
                type: "bigint",
                nullable: false,
                defaultValue: 0L);

            migrationBuilder.AddColumn<long>(
                name: "PayeeAcSubLedgerId",
                table: "AccountTransDetail",
                type: "bigint",
                nullable: false,
                defaultValue: 0L);

            migrationBuilder.AddColumn<long>(
                name: "ReceiverAcContactId",
                table: "AccountTransDetail",
                type: "bigint",
                nullable: false,
                defaultValue: 0L);
        }
    }
}
