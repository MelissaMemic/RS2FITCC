using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace FITCCRS2.Services.Migrations.RS2Seminarski
{
    public partial class NapomenaTablePopulate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "ApiResourceSecrets",
                keyColumn: "Id",
                keyValue: 1,
                column: "Created",
                value: new DateTime(2023, 12, 17, 13, 45, 34, 536, DateTimeKind.Local).AddTicks(940));

            migrationBuilder.UpdateData(
                table: "ApiResources",
                keyColumn: "Id",
                keyValue: 1,
                column: "Created",
                value: new DateTime(2023, 12, 17, 13, 45, 34, 536, DateTimeKind.Local).AddTicks(820));

            migrationBuilder.UpdateData(
                table: "ClientSecrets",
                keyColumn: "Id",
                keyValue: 1,
                column: "Created",
                value: new DateTime(2023, 12, 17, 13, 45, 34, 536, DateTimeKind.Local).AddTicks(1080));

            migrationBuilder.UpdateData(
                table: "ClientSecrets",
                keyColumn: "Id",
                keyValue: 2,
                column: "Created",
                value: new DateTime(2023, 12, 17, 13, 45, 34, 536, DateTimeKind.Local).AddTicks(1090));

            migrationBuilder.UpdateData(
                table: "Clients",
                keyColumn: "Id",
                keyValue: 1,
                column: "Created",
                value: new DateTime(2023, 12, 17, 13, 45, 34, 536, DateTimeKind.Local).AddTicks(1010));

            migrationBuilder.UpdateData(
                table: "Clients",
                keyColumn: "Id",
                keyValue: 2,
                column: "Created",
                value: new DateTime(2023, 12, 17, 13, 45, 34, 536, DateTimeKind.Local).AddTicks(1020));

            migrationBuilder.UpdateData(
                table: "IdentityResources",
                keyColumn: "Id",
                keyValue: 1,
                column: "Created",
                value: new DateTime(2023, 12, 17, 13, 45, 34, 536, DateTimeKind.Local).AddTicks(1120));

            migrationBuilder.UpdateData(
                table: "IdentityResources",
                keyColumn: "Id",
                keyValue: 2,
                column: "Created",
                value: new DateTime(2023, 12, 17, 13, 45, 34, 536, DateTimeKind.Local).AddTicks(1130));

            migrationBuilder.UpdateData(
                table: "IdentityResources",
                keyColumn: "Id",
                keyValue: 3,
                column: "Created",
                value: new DateTime(2023, 12, 17, 13, 45, 34, 536, DateTimeKind.Local).AddTicks(1130));

            migrationBuilder.InsertData(
                table: "Napomenas",
                columns: new[] { "NapomenaId", "Poruka", "UserName", "UsernameTakmicar" },
                values: new object[] { 1, "Takmicar pokazuje interes.", "sponzor", "bablamija" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Napomenas",
                keyColumn: "NapomenaId",
                keyValue: 1);

            migrationBuilder.UpdateData(
                table: "ApiResourceSecrets",
                keyColumn: "Id",
                keyValue: 1,
                column: "Created",
                value: new DateTime(2023, 12, 17, 13, 42, 47, 507, DateTimeKind.Local).AddTicks(5190));

            migrationBuilder.UpdateData(
                table: "ApiResources",
                keyColumn: "Id",
                keyValue: 1,
                column: "Created",
                value: new DateTime(2023, 12, 17, 13, 42, 47, 507, DateTimeKind.Local).AddTicks(4900));

            migrationBuilder.UpdateData(
                table: "ClientSecrets",
                keyColumn: "Id",
                keyValue: 1,
                column: "Created",
                value: new DateTime(2023, 12, 17, 13, 42, 47, 507, DateTimeKind.Local).AddTicks(5410));

            migrationBuilder.UpdateData(
                table: "ClientSecrets",
                keyColumn: "Id",
                keyValue: 2,
                column: "Created",
                value: new DateTime(2023, 12, 17, 13, 42, 47, 507, DateTimeKind.Local).AddTicks(5500));

            migrationBuilder.UpdateData(
                table: "Clients",
                keyColumn: "Id",
                keyValue: 1,
                column: "Created",
                value: new DateTime(2023, 12, 17, 13, 42, 47, 507, DateTimeKind.Local).AddTicks(5340));

            migrationBuilder.UpdateData(
                table: "Clients",
                keyColumn: "Id",
                keyValue: 2,
                column: "Created",
                value: new DateTime(2023, 12, 17, 13, 42, 47, 507, DateTimeKind.Local).AddTicks(5350));

            migrationBuilder.UpdateData(
                table: "IdentityResources",
                keyColumn: "Id",
                keyValue: 1,
                column: "Created",
                value: new DateTime(2023, 12, 17, 13, 42, 47, 507, DateTimeKind.Local).AddTicks(5540));

            migrationBuilder.UpdateData(
                table: "IdentityResources",
                keyColumn: "Id",
                keyValue: 2,
                column: "Created",
                value: new DateTime(2023, 12, 17, 13, 42, 47, 507, DateTimeKind.Local).AddTicks(5550));

            migrationBuilder.UpdateData(
                table: "IdentityResources",
                keyColumn: "Id",
                keyValue: 3,
                column: "Created",
                value: new DateTime(2023, 12, 17, 13, 42, 47, 507, DateTimeKind.Local).AddTicks(5560));
        }
    }
}
