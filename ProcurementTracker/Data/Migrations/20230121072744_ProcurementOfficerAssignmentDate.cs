using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ProcurementTracker.Data.Migrations
{
    /// <inheritdoc />
    public partial class ProcurementOfficerAssignmentDate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<DateTime>(
                name: "DateAssigned",
                table: "ProcurementOfficerAssignments",
                type: "datetime2",
                nullable: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "DateAssigned",
                table: "ProcurementOfficerAssignments");
        }
    }
}
