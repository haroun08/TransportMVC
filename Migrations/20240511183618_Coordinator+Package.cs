using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace TransportMVC.Migrations
{
    /// <inheritdoc />
    public partial class CoordinatorPackage : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Notifications_AspNetUsers_CreatedById",
                table: "Notifications");

            migrationBuilder.DropForeignKey(
                name: "FK_Notifications_AspNetUsers_LastModifiedById",
                table: "Notifications");

            migrationBuilder.AddColumn<Guid>(
                name: "CoordinatorId",
                table: "Packages",
                type: "char(36)",
                nullable: true,
                collation: "ascii_general_ci");

            migrationBuilder.AlterColumn<string>(
                name: "LastModifiedById",
                table: "Notifications",
                type: "varchar(255)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "varchar(255)")
                .Annotation("MySql:CharSet", "utf8mb4")
                .OldAnnotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.AlterColumn<string>(
                name: "CreatedById",
                table: "Notifications",
                type: "varchar(255)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "varchar(255)")
                .Annotation("MySql:CharSet", "utf8mb4")
                .OldAnnotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.AlterColumn<string>(
                name: "Name",
                table: "Coordinators",
                type: "varchar(255)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "longtext")
                .Annotation("MySql:CharSet", "utf8mb4")
                .OldAnnotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateIndex(
                name: "IX_Packages_CoordinatorId",
                table: "Packages",
                column: "CoordinatorId");

            migrationBuilder.CreateIndex(
                name: "IX_Coordinators_Name",
                table: "Coordinators",
                column: "Name",
                unique: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Notifications_AspNetUsers_CreatedById",
                table: "Notifications",
                column: "CreatedById",
                principalTable: "AspNetUsers",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Notifications_AspNetUsers_LastModifiedById",
                table: "Notifications",
                column: "LastModifiedById",
                principalTable: "AspNetUsers",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Packages_Coordinators_CoordinatorId",
                table: "Packages",
                column: "CoordinatorId",
                principalTable: "Coordinators",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Notifications_AspNetUsers_CreatedById",
                table: "Notifications");

            migrationBuilder.DropForeignKey(
                name: "FK_Notifications_AspNetUsers_LastModifiedById",
                table: "Notifications");

            migrationBuilder.DropForeignKey(
                name: "FK_Packages_Coordinators_CoordinatorId",
                table: "Packages");

            migrationBuilder.DropIndex(
                name: "IX_Packages_CoordinatorId",
                table: "Packages");

            migrationBuilder.DropIndex(
                name: "IX_Coordinators_Name",
                table: "Coordinators");

            migrationBuilder.DropColumn(
                name: "CoordinatorId",
                table: "Packages");

            migrationBuilder.UpdateData(
                table: "Notifications",
                keyColumn: "LastModifiedById",
                keyValue: null,
                column: "LastModifiedById",
                value: "");

            migrationBuilder.AlterColumn<string>(
                name: "LastModifiedById",
                table: "Notifications",
                type: "varchar(255)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "varchar(255)",
                oldNullable: true)
                .Annotation("MySql:CharSet", "utf8mb4")
                .OldAnnotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.UpdateData(
                table: "Notifications",
                keyColumn: "CreatedById",
                keyValue: null,
                column: "CreatedById",
                value: "");

            migrationBuilder.AlterColumn<string>(
                name: "CreatedById",
                table: "Notifications",
                type: "varchar(255)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "varchar(255)",
                oldNullable: true)
                .Annotation("MySql:CharSet", "utf8mb4")
                .OldAnnotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.AlterColumn<string>(
                name: "Name",
                table: "Coordinators",
                type: "longtext",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "varchar(255)")
                .Annotation("MySql:CharSet", "utf8mb4")
                .OldAnnotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.AddForeignKey(
                name: "FK_Notifications_AspNetUsers_CreatedById",
                table: "Notifications",
                column: "CreatedById",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Notifications_AspNetUsers_LastModifiedById",
                table: "Notifications",
                column: "LastModifiedById",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
