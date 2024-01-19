using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace FITCCRS2.Services.Migrations.RS2Seminarski
{
    public partial class NapomenaTable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Napomenas",
                columns: table => new
                {
                    NapomenaId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Poruka = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    UsernameTakmicar = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    UserName = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Napomenas", x => x.NapomenaId);
                });

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

            migrationBuilder.InsertData(
                table: "AspNetUserRoles",
                columns: new[] { "RoleId", "UserId" },
                values: new object[] { "5963d28a-f188-4aa4-b863-910d91022e1d", "f16b92c8-c7d6-486e-9635-9103263eed30" });

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

            migrationBuilder.UpdateData(
                table: "Sponzor",
                keyColumn: "SponzorID",
                keyValue: 1,
                column: "SponzorKategorije",
                value: false);

            migrationBuilder.UpdateData(
                table: "Sponzor",
                keyColumn: "SponzorID",
                keyValue: 2,
                column: "KategorijaID",
                value: null);

            migrationBuilder.InsertData(
                table: "User",
                columns: new[] { "UserId", "IsAllowed", "Lastname", "Name", "Role", "Username", "Website" },
                values: new object[] { 5, true, "Sponzor", "Sponzor", "sponzor", "sponzor", "http://google.com" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Napomenas");

            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { "5963d28a-f188-4aa4-b863-910d91022e1d", "f16b92c8-c7d6-486e-9635-9103263eed30" });

            migrationBuilder.DeleteData(
                table: "User",
                keyColumn: "UserId",
                keyValue: 5);

            migrationBuilder.UpdateData(
                table: "ApiResourceSecrets",
                keyColumn: "Id",
                keyValue: 1,
                column: "Created",
                value: new DateTime(2022, 11, 25, 22, 29, 44, 35, DateTimeKind.Local).AddTicks(9823));

            migrationBuilder.UpdateData(
                table: "ApiResources",
                keyColumn: "Id",
                keyValue: 1,
                column: "Created",
                value: new DateTime(2022, 11, 25, 22, 29, 44, 35, DateTimeKind.Local).AddTicks(9599));

            migrationBuilder.UpdateData(
                table: "ClientSecrets",
                keyColumn: "Id",
                keyValue: 1,
                column: "Created",
                value: new DateTime(2022, 11, 25, 22, 29, 44, 36, DateTimeKind.Local).AddTicks(30));

            migrationBuilder.UpdateData(
                table: "ClientSecrets",
                keyColumn: "Id",
                keyValue: 2,
                column: "Created",
                value: new DateTime(2022, 11, 25, 22, 29, 44, 36, DateTimeKind.Local).AddTicks(43));

            migrationBuilder.UpdateData(
                table: "Clients",
                keyColumn: "Id",
                keyValue: 1,
                column: "Created",
                value: new DateTime(2022, 11, 25, 22, 29, 44, 35, DateTimeKind.Local).AddTicks(9893));

            migrationBuilder.UpdateData(
                table: "Clients",
                keyColumn: "Id",
                keyValue: 2,
                column: "Created",
                value: new DateTime(2022, 11, 25, 22, 29, 44, 35, DateTimeKind.Local).AddTicks(9932));

            migrationBuilder.UpdateData(
                table: "IdentityResources",
                keyColumn: "Id",
                keyValue: 1,
                column: "Created",
                value: new DateTime(2022, 11, 25, 22, 29, 44, 36, DateTimeKind.Local).AddTicks(95));

            migrationBuilder.UpdateData(
                table: "IdentityResources",
                keyColumn: "Id",
                keyValue: 2,
                column: "Created",
                value: new DateTime(2022, 11, 25, 22, 29, 44, 36, DateTimeKind.Local).AddTicks(111));

            migrationBuilder.UpdateData(
                table: "IdentityResources",
                keyColumn: "Id",
                keyValue: 3,
                column: "Created",
                value: new DateTime(2022, 11, 25, 22, 29, 44, 36, DateTimeKind.Local).AddTicks(123));

            migrationBuilder.UpdateData(
                table: "Sponzor",
                keyColumn: "SponzorID",
                keyValue: 1,
                column: "SponzorKategorije",
                value: true);

            migrationBuilder.UpdateData(
                table: "Sponzor",
                keyColumn: "SponzorID",
                keyValue: 2,
                column: "KategorijaID",
                value: 0);
        }
    }
}
