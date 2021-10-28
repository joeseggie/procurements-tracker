using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace ProcurementTracker.Data.Migrations
{
    public partial class Chk : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_RoleApplicationActions_ApplicationActions_ApplicationActionId",
                table: "RoleApplicationActions");

            migrationBuilder.AlterColumn<Guid>(
                name: "RoleId",
                table: "RoleApplicationActions",
                type: "uniqueidentifier",
                nullable: true,
                oldClrType: typeof(Guid),
                oldType: "uniqueidentifier");

            migrationBuilder.AlterColumn<Guid>(
                name: "ApplicationActionId",
                table: "RoleApplicationActions",
                type: "uniqueidentifier",
                nullable: true,
                oldClrType: typeof(Guid),
                oldType: "uniqueidentifier");

            migrationBuilder.AddForeignKey(
                name: "FK_RoleApplicationActions_ApplicationActions_ApplicationActionId",
                table: "RoleApplicationActions",
                column: "ApplicationActionId",
                principalTable: "ApplicationActions",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_RoleApplicationActions_ApplicationActions_ApplicationActionId",
                table: "RoleApplicationActions");

            migrationBuilder.AlterColumn<Guid>(
                name: "RoleId",
                table: "RoleApplicationActions",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"),
                oldClrType: typeof(Guid),
                oldType: "uniqueidentifier",
                oldNullable: true);

            migrationBuilder.AlterColumn<Guid>(
                name: "ApplicationActionId",
                table: "RoleApplicationActions",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"),
                oldClrType: typeof(Guid),
                oldType: "uniqueidentifier",
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_RoleApplicationActions_ApplicationActions_ApplicationActionId",
                table: "RoleApplicationActions",
                column: "ApplicationActionId",
                principalTable: "ApplicationActions",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
