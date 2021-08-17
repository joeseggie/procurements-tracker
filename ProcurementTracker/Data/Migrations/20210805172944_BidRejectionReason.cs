using Microsoft.EntityFrameworkCore.Migrations;

namespace ProcurementTracker.Data.Migrations
{
    public partial class BidRejectionReason : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "RejectionReason",
                table: "Bid",
                type: "nvarchar(max)",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "RejectionReason",
                table: "Bid");
        }
    }
}
