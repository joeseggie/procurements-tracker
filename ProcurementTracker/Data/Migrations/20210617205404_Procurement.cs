using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace ProcurementTracker.Data.Migrations
{
    public partial class Procurement : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<Guid>(
                name: "ProcurementId",
                table: "Bid",
                type: "uniqueidentifier",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "Procurement",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Details = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Amount = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    ProcurementMethod = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Status = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Procurement", x => x.Id);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Bid_ProcurementId",
                table: "Bid",
                column: "ProcurementId");

            migrationBuilder.AddForeignKey(
                name: "FK_Bid_Procurement_ProcurementId",
                table: "Bid",
                column: "ProcurementId",
                principalTable: "Procurement",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Bid_Procurement_ProcurementId",
                table: "Bid");

            migrationBuilder.DropTable(
                name: "Procurement");

            migrationBuilder.DropIndex(
                name: "IX_Bid_ProcurementId",
                table: "Bid");

            migrationBuilder.DropColumn(
                name: "ProcurementId",
                table: "Bid");
        }
    }
}
