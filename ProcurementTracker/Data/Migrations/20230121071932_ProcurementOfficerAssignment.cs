using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ProcurementTracker.Data.Migrations
{
    /// <inheritdoc />
    public partial class ProcurementOfficerAssignment : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "ProcurementOfficerAssignments",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    ProcurementId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    OfficerId = table.Column<string>(type: "nvarchar(450)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ProcurementOfficerAssignments", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ProcurementOfficerAssignments_AspNetUsers_OfficerId",
                        column: x => x.OfficerId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_ProcurementOfficerAssignments_Procurements_ProcurementId",
                        column: x => x.ProcurementId,
                        principalTable: "Procurements",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateIndex(
                name: "IX_ProcurementOfficerAssignments_OfficerId",
                table: "ProcurementOfficerAssignments",
                column: "OfficerId");

            migrationBuilder.CreateIndex(
                name: "IX_ProcurementOfficerAssignments_ProcurementId",
                table: "ProcurementOfficerAssignments",
                column: "ProcurementId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ProcurementOfficerAssignments");
        }
    }
}
