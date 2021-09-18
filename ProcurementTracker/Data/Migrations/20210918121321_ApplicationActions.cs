using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace ProcurementTracker.Data.Migrations
{
    public partial class ApplicationActions : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Bid_Procurement_ProcurementId",
                table: "Bid");

            migrationBuilder.DropForeignKey(
                name: "FK_Bid_Supplier_SupplierId",
                table: "Bid");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Supplier",
                table: "Supplier");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Procurement",
                table: "Procurement");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Bid",
                table: "Bid");

            migrationBuilder.RenameTable(
                name: "Supplier",
                newName: "Suppliers");

            migrationBuilder.RenameTable(
                name: "Procurement",
                newName: "Procurements");

            migrationBuilder.RenameTable(
                name: "Bid",
                newName: "Bids");

            migrationBuilder.RenameIndex(
                name: "IX_Bid_SupplierId",
                table: "Bids",
                newName: "IX_Bids_SupplierId");

            migrationBuilder.RenameIndex(
                name: "IX_Bid_ProcurementId",
                table: "Bids",
                newName: "IX_Bids_ProcurementId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Suppliers",
                table: "Suppliers",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Procurements",
                table: "Procurements",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Bids",
                table: "Bids",
                column: "Id");

            migrationBuilder.CreateTable(
                name: "ApplicationActions",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Action = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Area = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ApplicationActions", x => x.Id);
                });

            migrationBuilder.AddForeignKey(
                name: "FK_Bids_Procurements_ProcurementId",
                table: "Bids",
                column: "ProcurementId",
                principalTable: "Procurements",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Bids_Suppliers_SupplierId",
                table: "Bids",
                column: "SupplierId",
                principalTable: "Suppliers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Bids_Procurements_ProcurementId",
                table: "Bids");

            migrationBuilder.DropForeignKey(
                name: "FK_Bids_Suppliers_SupplierId",
                table: "Bids");

            migrationBuilder.DropTable(
                name: "ApplicationActions");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Suppliers",
                table: "Suppliers");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Procurements",
                table: "Procurements");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Bids",
                table: "Bids");

            migrationBuilder.RenameTable(
                name: "Suppliers",
                newName: "Supplier");

            migrationBuilder.RenameTable(
                name: "Procurements",
                newName: "Procurement");

            migrationBuilder.RenameTable(
                name: "Bids",
                newName: "Bid");

            migrationBuilder.RenameIndex(
                name: "IX_Bids_SupplierId",
                table: "Bid",
                newName: "IX_Bid_SupplierId");

            migrationBuilder.RenameIndex(
                name: "IX_Bids_ProcurementId",
                table: "Bid",
                newName: "IX_Bid_ProcurementId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Supplier",
                table: "Supplier",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Procurement",
                table: "Procurement",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Bid",
                table: "Bid",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Bid_Procurement_ProcurementId",
                table: "Bid",
                column: "ProcurementId",
                principalTable: "Procurement",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Bid_Supplier_SupplierId",
                table: "Bid",
                column: "SupplierId",
                principalTable: "Supplier",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
