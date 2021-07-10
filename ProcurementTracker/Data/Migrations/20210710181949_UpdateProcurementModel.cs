using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace ProcurementTracker.Data.Migrations
{
    public partial class UpdateProcurementModel : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Details",
                table: "Procurement",
                newName: "Subject");

            migrationBuilder.RenameColumn(
                name: "Amount",
                table: "Procurement",
                newName: "ExchangeRate");

            migrationBuilder.AddColumn<DateTime>(
                name: "AERCCDate",
                table: "Procurement",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<DateTime>(
                name: "ANRCCDate",
                table: "Procurement",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<DateTime>(
                name: "AccountingApprovalDate",
                table: "Procurement",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<DateTime>(
                name: "BEBNoticeDate",
                table: "Procurement",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<DateTime>(
                name: "BidClosingDate",
                table: "Procurement",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<DateTime>(
                name: "BidInvitationDate",
                table: "Procurement",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<DateTime>(
                name: "CCApprovalDate",
                table: "Procurement",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<DateTime>(
                name: "CCSABDApprovalDate",
                table: "Procurement",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<string>(
                name: "Currency",
                table: "Procurement",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Department",
                table: "Procurement",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "EOIClosingDate",
                table: "Procurement",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<DateTime>(
                name: "EOIInvitationDate",
                table: "Procurement",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<DateTime>(
                name: "EOINotificationDate",
                table: "Procurement",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<DateTime>(
                name: "EOIShortlistApprovalDate",
                table: "Procurement",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<decimal>(
                name: "EstimatedAmount",
                table: "Procurement",
                type: "decimal(18,2)",
                nullable: false,
                defaultValue: 0m);

            migrationBuilder.AddColumn<string>(
                name: "FundingSource",
                table: "Procurement",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "NegotiationDate",
                table: "Procurement",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<DateTime>(
                name: "PPQNoticeDate",
                table: "Procurement",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<DateTime>(
                name: "PQPSClosingDate",
                table: "Procurement",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<string>(
                name: "ProcurementType",
                table: "Procurement",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "Quantity",
                table: "Procurement",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<DateTime>(
                name: "SERCCDate",
                table: "Procurement",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "AERCCDate",
                table: "Procurement");

            migrationBuilder.DropColumn(
                name: "ANRCCDate",
                table: "Procurement");

            migrationBuilder.DropColumn(
                name: "AccountingApprovalDate",
                table: "Procurement");

            migrationBuilder.DropColumn(
                name: "BEBNoticeDate",
                table: "Procurement");

            migrationBuilder.DropColumn(
                name: "BidClosingDate",
                table: "Procurement");

            migrationBuilder.DropColumn(
                name: "BidInvitationDate",
                table: "Procurement");

            migrationBuilder.DropColumn(
                name: "CCApprovalDate",
                table: "Procurement");

            migrationBuilder.DropColumn(
                name: "CCSABDApprovalDate",
                table: "Procurement");

            migrationBuilder.DropColumn(
                name: "Currency",
                table: "Procurement");

            migrationBuilder.DropColumn(
                name: "Department",
                table: "Procurement");

            migrationBuilder.DropColumn(
                name: "EOIClosingDate",
                table: "Procurement");

            migrationBuilder.DropColumn(
                name: "EOIInvitationDate",
                table: "Procurement");

            migrationBuilder.DropColumn(
                name: "EOINotificationDate",
                table: "Procurement");

            migrationBuilder.DropColumn(
                name: "EOIShortlistApprovalDate",
                table: "Procurement");

            migrationBuilder.DropColumn(
                name: "EstimatedAmount",
                table: "Procurement");

            migrationBuilder.DropColumn(
                name: "FundingSource",
                table: "Procurement");

            migrationBuilder.DropColumn(
                name: "NegotiationDate",
                table: "Procurement");

            migrationBuilder.DropColumn(
                name: "PPQNoticeDate",
                table: "Procurement");

            migrationBuilder.DropColumn(
                name: "PQPSClosingDate",
                table: "Procurement");

            migrationBuilder.DropColumn(
                name: "ProcurementType",
                table: "Procurement");

            migrationBuilder.DropColumn(
                name: "Quantity",
                table: "Procurement");

            migrationBuilder.DropColumn(
                name: "SERCCDate",
                table: "Procurement");

            migrationBuilder.RenameColumn(
                name: "Subject",
                table: "Procurement",
                newName: "Details");

            migrationBuilder.RenameColumn(
                name: "ExchangeRate",
                table: "Procurement",
                newName: "Amount");
        }
    }
}
