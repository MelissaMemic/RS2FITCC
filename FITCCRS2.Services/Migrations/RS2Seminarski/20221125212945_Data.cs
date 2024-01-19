using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace FITCCRS2.Services.Migrations.RS2Seminarski
{
    public partial class Data : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_PredavacDogadjaj_Dogadjaj",
                table: "PredavacDogadjaj");

            migrationBuilder.DropForeignKey(
                name: "FK_PredavacDogadjaj_Predavac",
                table: "PredavacDogadjaj");

            migrationBuilder.DropIndex(
                name: "IX_PredavacDogadjaj_DogadjaId",
                table: "PredavacDogadjaj");

            migrationBuilder.RenameIndex(
                name: "IX_AspNetUserRoles_RoleId",
                table: "AspNetUserRoles",
                newName: "IX_AspNetUserRole_RoleId");

            migrationBuilder.CreateTable(
                name: "AspNetRoleAspNetUser",
                columns: table => new
                {
                    RolesId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    UsersId = table.Column<string>(type: "nvarchar(450)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetRoleAspNetUser", x => new { x.RolesId, x.UsersId });
                    table.ForeignKey(
                        name: "FK_AspNetRoleAspNetUser_AspNetRoles_RolesId",
                        column: x => x.RolesId,
                        principalTable: "AspNetRoles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_AspNetRoleAspNetUser_AspNetUsers_UsersId",
                        column: x => x.UsersId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "DogadjajPredavac",
                columns: table => new
                {
                    DogadjasDogadjajId = table.Column<int>(type: "int", nullable: false),
                    PredavacsPredavacId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DogadjajPredavac", x => new { x.DogadjasDogadjajId, x.PredavacsPredavacId });
                    table.ForeignKey(
                        name: "FK_DogadjajPredavac_Dogadjaj_DogadjasDogadjajId",
                        column: x => x.DogadjasDogadjajId,
                        principalTable: "Dogadjaj",
                        principalColumn: "DogadjajID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_DogadjajPredavac_Predavac_PredavacsPredavacId",
                        column: x => x.PredavacsPredavacId,
                        principalTable: "Predavac",
                        principalColumn: "PredavacId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "ApiResources",
                columns: new[] { "Id", "AllowedAccessTokenSigningAlgorithms", "Created", "Description", "DisplayName", "Enabled", "LastAccessed", "Name", "NonEditable", "ShowInDiscoveryDocument", "Updated" },
                values: new object[] { 1, null, new DateTime(2022, 11, 25, 22, 29, 44, 35, DateTimeKind.Local).AddTicks(9599), null, "FITCCRS2", true, null, "FITCCRS2", false, true, null });

            migrationBuilder.InsertData(
                table: "ApiScopes",
                columns: new[] { "Id", "Description", "DisplayName", "Emphasize", "Enabled", "Name", "Required", "ShowInDiscoveryDocument" },
                values: new object[,]
                {
                    { 1, null, "FITCCRS2.read", false, true, "FITCCRS2.read", false, true },
                    { 2, null, "FITCCRS2.write", false, true, "FITCCRS2.write", false, true }
                });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "37d3d51d-ca09-45ff-b3b1-111b548c3db7", "582faf8e-eb53-4f12-a597-e8dc349010d9", "takmicar", "TAKMICAR" },
                    { "5963d28a-f188-4aa4-b863-910d91022e1d", "0dc2bd01-8e63-4d1b-b6fd-e4b750d64463", "sponzor", "SPONZOR" },
                    { "94c2ed89-8d43-420f-be46-a770a3c483f0", "ff459d69-5e90-4397-8ebd-86984f218e1c", "ziri", "ZIRI" },
                    { "e6d3c95c-3fd1-43c0-b764-3e074b086963", "a7f6affb-f83d-46f1-b8f6-3be28d990b4c", "admin", "ADMIN" },
                    { "ed46d55f-5819-4435-9bed-745d9a138cac", "fe164d12-d17a-4b67-be8d-c48ed577f90d", "predavac", "PREDAVAC" }
                });

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "Email", "EmailConfirmed", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled", "UserName" },
                values: new object[,]
                {
                    { "090bdbbc-926a-41f6-9573-a48ba9f64303", 0, "cbb68c5b-3dae-4106-a2d6-62a4c1be35e9", "mellimostar@gmail.com", true, true, null, "MELLIMOSTAR@GMAIL.COM", "MELI", "AQAAAAEAACcQAAAAENRCLecZkCvoTWVxS7oZR1j+bFCIgDw4L7dqdpCTK/sE67Ai/4nW9zI24Ot75D1UVA==", null, false, "H7K7Q3VFIDZ36LXORHOX5NIEOCUCNBNB", false, "meli" },
                    { "2adbed90-e3d3-4786-9115-241e02cf5c96", 0, "e142fa65-04f0-4fc2-b971-1e731caca934", "bablamija@gmail.com", true, true, null, "BABLAMIJA@GMAIL.COM", "BABLAMIJA", "AQAAAAEAACcQAAAAED4Q8lm8HuZKCoxF5hbQe/Q0dZRlEn0yCUCFnZXFx2GZLjhEd9VCW3ezjkd6BeBymw==", null, false, "BOSLSMZK63NKAXROUVKFEAUMQJV6KJPK", false, "bablamija" },
                    { "4668c178-3b13-4876-b305-608b1c41548f", 0, "84a598f8-bc6e-4ece-bfe7-d5aa71cf1995", "ziri@ziri.ba", true, true, null, "ZIRI@ZIRI.BA", "ZIRI", "AQAAAAEAACcQAAAAEEg2oudD+BP4sB+ORU7mfyJpuSQ/woVogn8bj3P1JP4BAOVIPKOx7dUrdsdK0yxnmQ==", null, false, "2BEJCF6VFEDLX4ABGLYTYWXCYU37RPHB", false, "ziri" },
                    { "f16b92c8-c7d6-486e-9635-9103263eed30", 0, "80afc46a-3055-476e-8c2a-294f90f72afa", "lamija.babovic@edu.fit.ba", true, true, null, "LAMIJA.BABOVIC@EDU.FIT.BA", "LAMIJA", "AQAAAAEAACcQAAAAEMJjk/A6GZEi1sMeNfQz6BSfAoYMQHbha61zcKwboANM2UAy7nspzn7NMQ/m4MBhgg==", null, false, "N3ELBRQMOT6K6U6HJCF5324JMXWPSS57", false, "lamija" }
                });

            migrationBuilder.InsertData(
                table: "Clients",
                columns: new[] { "Id", "AbsoluteRefreshTokenLifetime", "AccessTokenLifetime", "AccessTokenType", "AllowAccessTokensViaBrowser", "AllowOfflineAccess", "AllowPlainTextPkce", "AllowRememberConsent", "AllowedIdentityTokenSigningAlgorithms", "AlwaysIncludeUserClaimsInIdToken", "AlwaysSendClientClaims", "AuthorizationCodeLifetime", "BackChannelLogoutSessionRequired", "BackChannelLogoutUri", "ClientClaimsPrefix", "ClientId", "ClientName", "ClientUri", "ConsentLifetime", "Created", "Description", "DeviceCodeLifetime", "EnableLocalLogin", "Enabled", "FrontChannelLogoutSessionRequired", "FrontChannelLogoutUri", "IdentityTokenLifetime", "IncludeJwtId", "LastAccessed", "LogoUri", "NonEditable", "PairWiseSubjectSalt", "ProtocolType", "RefreshTokenExpiration", "RefreshTokenUsage", "RequireClientSecret", "RequireConsent", "RequirePkce", "RequireRequestObject", "SlidingRefreshTokenLifetime", "UpdateAccessTokenClaimsOnRefresh", "Updated", "UserCodeType", "UserSsoLifetime" },
                values: new object[,]
                {
                    { 1, 2592000, 3600, 0, false, false, false, true, null, false, false, 300, true, null, "client_", "m2m.client", "Client Credentials Client", null, null, new DateTime(2022, 11, 25, 22, 29, 44, 35, DateTimeKind.Local).AddTicks(9893), null, 300, true, true, true, null, 300, true, null, null, false, null, "oidc", 1, 1, true, false, true, false, 1296000, false, null, null, null },
                    { 2, 2592000, 3600, 0, false, true, false, true, null, false, false, 300, true, null, "client_", "interactive", null, null, null, new DateTime(2022, 11, 25, 22, 29, 44, 35, DateTimeKind.Local).AddTicks(9932), null, 300, true, true, true, "https://localhost:5444/signout-oidc", 300, true, null, null, false, null, "oidc", 1, 1, true, true, true, false, 1296000, false, null, null, null }
                });

            migrationBuilder.InsertData(
                table: "IdentityResources",
                columns: new[] { "Id", "Created", "Description", "DisplayName", "Emphasize", "Enabled", "Name", "NonEditable", "Required", "ShowInDiscoveryDocument", "Updated" },
                values: new object[,]
                {
                    { 1, new DateTime(2022, 11, 25, 22, 29, 44, 36, DateTimeKind.Local).AddTicks(95), null, "Your user identifier", false, true, "openid", false, true, true, null },
                    { 2, new DateTime(2022, 11, 25, 22, 29, 44, 36, DateTimeKind.Local).AddTicks(111), "Your user profile information (first name, last name, etc.)", "User profile", true, true, "profile", false, false, true, null },
                    { 3, new DateTime(2022, 11, 25, 22, 29, 44, 36, DateTimeKind.Local).AddTicks(123), null, null, false, true, "role", false, false, true, null }
                });

            migrationBuilder.InsertData(
                table: "Predavac",
                columns: new[] { "PredavacId", "DogadjaId", "Email", "Ime", "Prezime", "Ustanova", "Zvanje" },
                values: new object[,]
                {
                    { 1, 2, "neko.ne@nesto.ba", "Neko", "Neko", "Firma", "Software inzenjer" },
                    { 2, 2, "neko.dr@nesto.ba", "Neko", "Drugi", "Firma nova", "Software inzenjer" }
                });

            migrationBuilder.InsertData(
                table: "PredavacDogadjaj",
                columns: new[] { "DogadjaId", "PredavacId" },
                values: new object[,]
                {
                    { 2, 1 },
                    { 2, 2 }
                });

            migrationBuilder.InsertData(
                table: "Sponzor",
                columns: new[] { "SponzorID", "Godina", "Iznos", "KategorijaID", "Naziv", "SponzorKategorije", "TipSponzorstva" },
                values: new object[] { 2, 2022, 2500.0, null, "Sponzor", false, "Srebreni" });

            migrationBuilder.InsertData(
                table: "Takmicenje",
                columns: new[] { "TakmicenjeID", "BrojDana", "Godina", "Kraj", "Naziv", "Pocetak", "Slika", "Slogan" },
                values: new object[] { 1, 2, 2022, new DateTime(2022, 5, 2, 10, 0, 0, 0, DateTimeKind.Unspecified), "FIT Coding Challenge 2022", new DateTime(2022, 5, 1, 10, 0, 0, 0, DateTimeKind.Unspecified), null, " " });

            migrationBuilder.InsertData(
                table: "User",
                columns: new[] { "UserId", "IsAllowed", "Lastname", "Name", "Role", "Username", "Website" },
                values: new object[,]
                {
                    { 1, true, "Memic", "Melissa", "admin", "melissa", "http://google.com" },
                    { 2, true, "Babovic", "lamija", "admin", "lamija", "http://google.com" },
                    { 3, true, "Ziri", "Ziri", "ziri", "ziri", "http://google.com" },
                    { 4, true, "Bab", "lamija", "takmicar", "bablamija", "http://google.com" }
                });

            migrationBuilder.InsertData(
                table: "Agenda",
                columns: new[] { "AgendaID", "Dan", "TakmicenjeID" },
                values: new object[,]
                {
                    { 1, 1, 1 },
                    { 2, 2, 1 }
                });

            migrationBuilder.InsertData(
                table: "ApiResourceClaims",
                columns: new[] { "Id", "ApiResourceId", "Type" },
                values: new object[] { 1, 1, "role" });

            migrationBuilder.InsertData(
                table: "ApiResourceScopes",
                columns: new[] { "Id", "ApiResourceId", "Scope" },
                values: new object[,]
                {
                    { 1, 1, "FITCCRS2.read" },
                    { 2, 1, "FITCCRS2.write" }
                });

            migrationBuilder.InsertData(
                table: "ApiResourceSecrets",
                columns: new[] { "Id", "ApiResourceId", "Created", "Description", "Expiration", "Type", "Value" },
                values: new object[] { 1, 1, new DateTime(2022, 11, 25, 22, 29, 44, 35, DateTimeKind.Local).AddTicks(9823), null, null, "SharedSecret", "DbsYVAAscQ1HaJn5nUwONjP7UzJJclRpWGn/GKOKSw8=" });

            migrationBuilder.InsertData(
                table: "AspNetUserClaims",
                columns: new[] { "Id", "ClaimType", "ClaimValue", "UserId" },
                values: new object[,]
                {
                    { 1, "name", "Melissa Memic", "090bdbbc-926a-41f6-9573-a48ba9f64303" },
                    { 2, "given_name", "Melissa", "090bdbbc-926a-41f6-9573-a48ba9f64303" },
                    { 3, "family_name", "Memic", "090bdbbc-926a-41f6-9573-a48ba9f64303" },
                    { 4, "website", "http://google.com", "090bdbbc-926a-41f6-9573-a48ba9f64303" },
                    { 5, "name", "Lamija Babovic", "f16b92c8-c7d6-486e-9635-9103263eed30" },
                    { 6, "given_name", "Lamija", "f16b92c8-c7d6-486e-9635-9103263eed30" },
                    { 7, "family_name", "Babovic", "f16b92c8-c7d6-486e-9635-9103263eed30" },
                    { 8, "website", "http://google.com", "f16b92c8-c7d6-486e-9635-9103263eed30" },
                    { 9, "name", "Ziri", "4668c178-3b13-4876-b305-608b1c41548f" },
                    { 10, "given_name", "Ziri", "4668c178-3b13-4876-b305-608b1c41548f" },
                    { 11, "family_name", "Ziri", "4668c178-3b13-4876-b305-608b1c41548f" },
                    { 12, "website", "http://google.com", "4668c178-3b13-4876-b305-608b1c41548f" },
                    { 13, "name", "Lamija Bab", "2adbed90-e3d3-4786-9115-241e02cf5c96" },
                    { 14, "given_name", "Lamija", "2adbed90-e3d3-4786-9115-241e02cf5c96" },
                    { 15, "family_name", "Bab", "2adbed90-e3d3-4786-9115-241e02cf5c96" },
                    { 16, "website", "https://github.com/LamijaBabovic", "2adbed90-e3d3-4786-9115-241e02cf5c96" }
                });

            migrationBuilder.InsertData(
                table: "AspNetUserRoles",
                columns: new[] { "RoleId", "UserId" },
                values: new object[,]
                {
                    { "e6d3c95c-3fd1-43c0-b764-3e074b086963", "090bdbbc-926a-41f6-9573-a48ba9f64303" },
                    { "37d3d51d-ca09-45ff-b3b1-111b548c3db7", "2adbed90-e3d3-4786-9115-241e02cf5c96" },
                    { "94c2ed89-8d43-420f-be46-a770a3c483f0", "4668c178-3b13-4876-b305-608b1c41548f" },
                    { "e6d3c95c-3fd1-43c0-b764-3e074b086963", "f16b92c8-c7d6-486e-9635-9103263eed30" }
                });

            migrationBuilder.InsertData(
                table: "ClientGrantTypes",
                columns: new[] { "Id", "ClientId", "GrantType" },
                values: new object[,]
                {
                    { 1, 1, "client_credentials" },
                    { 2, 2, "authorization_code" }
                });

            migrationBuilder.InsertData(
                table: "ClientPostLogoutRedirectUris",
                columns: new[] { "Id", "ClientId", "PostLogoutRedirectUri" },
                values: new object[] { 1, 2, "https://localhost:5000/signout-callback-oidc" });

            migrationBuilder.InsertData(
                table: "ClientRedirectUris",
                columns: new[] { "Id", "ClientId", "RedirectUri" },
                values: new object[] { 1, 2, "https://localhost:5000/signin-oidc" });

            migrationBuilder.InsertData(
                table: "ClientScopes",
                columns: new[] { "Id", "ClientId", "Scope" },
                values: new object[,]
                {
                    { 1, 1, "FITCCRS2.read" },
                    { 2, 1, "FITCCRS2.write" },
                    { 3, 2, "openid" },
                    { 4, 2, "profile" },
                    { 5, 2, "FITCCRS2.read" }
                });

            migrationBuilder.InsertData(
                table: "ClientSecrets",
                columns: new[] { "Id", "ClientId", "Created", "Description", "Expiration", "Type", "Value" },
                values: new object[,]
                {
                    { 1, 1, new DateTime(2022, 11, 25, 22, 29, 44, 36, DateTimeKind.Local).AddTicks(30), null, null, "SharedSecret", "mvcbFoR2Z9+D9UMKjmSJ3rngEopZ+G/oaH+EafS3BLo=" },
                    { 2, 2, new DateTime(2022, 11, 25, 22, 29, 44, 36, DateTimeKind.Local).AddTicks(43), null, null, "SharedSecret", "mvcbFoR2Z9+D9UMKjmSJ3rngEopZ+G/oaH+EafS3BLo=" }
                });

            migrationBuilder.InsertData(
                table: "IdentityResourceClaims",
                columns: new[] { "Id", "IdentityResourceId", "Type" },
                values: new object[,]
                {
                    { 1, 1, "sub" },
                    { 2, 2, "name" },
                    { 3, 2, "family_name" },
                    { 4, 2, "given_name" },
                    { 5, 2, "middle_name" }
                });

            migrationBuilder.InsertData(
                table: "IdentityResourceClaims",
                columns: new[] { "Id", "IdentityResourceId", "Type" },
                values: new object[,]
                {
                    { 6, 2, "nickname" },
                    { 7, 2, "preferred_username" },
                    { 8, 2, "profile" },
                    { 9, 2, "picture" },
                    { 10, 2, "website" },
                    { 11, 2, "gender" },
                    { 12, 2, "birthdate" },
                    { 13, 2, "zoneinfo" },
                    { 14, 2, "locale" },
                    { 15, 2, "updated_at" },
                    { 16, 3, "role" }
                });

            migrationBuilder.InsertData(
                table: "Kategorija",
                columns: new[] { "KategorijaID", "Naziv", "Opis", "TakmicenjeID" },
                values: new object[,]
                {
                    { 1, "Programiraje", "Takmicenje u oblasti poznavanja programiranja", 1 },
                    { 2, "Inovacije", "Kreiranje najinovativnijeg rjesenja", 1 },
                    { 3, "Programiraje igara", "Takmicenje u oblasti poznavanja programiranja igara", 1 }
                });

            migrationBuilder.InsertData(
                table: "Tim",
                columns: new[] { "TimID", "BrojClanova", "Naziv", "TakmicenjeID", "UserId", "Username" },
                values: new object[] { 1, 1, "Tim", 1, 4, "bablamija" });

            migrationBuilder.InsertData(
                table: "Dogadjaj",
                columns: new[] { "DogadjajID", "AgendaID", "Kraj", "Lokacija", "Napomena", "Naziv", "Pocetak", "Trajanje" },
                values: new object[,]
                {
                    { 1, 1, new DateTime(2022, 5, 1, 10, 30, 0, 0, DateTimeKind.Unspecified), "Amfiteatar 1", null, "Otvaranje", new DateTime(2022, 5, 1, 10, 0, 0, 0, DateTimeKind.Unspecified), 30 },
                    { 2, 1, new DateTime(2022, 5, 1, 12, 30, 0, 0, DateTimeKind.Unspecified), "Amfiteatar 1", null, "Tribine", new DateTime(2022, 5, 1, 11, 0, 0, 0, DateTimeKind.Unspecified), 90 },
                    { 3, 1, new DateTime(2022, 5, 1, 12, 30, 0, 0, DateTimeKind.Unspecified), "Amfiteatar 3", null, "Inovacije", new DateTime(2022, 5, 1, 11, 0, 0, 0, DateTimeKind.Unspecified), 90 },
                    { 4, 1, new DateTime(2022, 5, 1, 12, 30, 0, 0, DateTimeKind.Unspecified), "Amfiteatar 2", null, "Programiranja", new DateTime(2022, 5, 1, 11, 0, 0, 0, DateTimeKind.Unspecified), 90 },
                    { 5, 1, new DateTime(2022, 5, 1, 12, 30, 0, 0, DateTimeKind.Unspecified), "AKS", null, "Programiranja igara", new DateTime(2022, 5, 1, 11, 0, 0, 0, DateTimeKind.Unspecified), 90 },
                    { 6, 2, new DateTime(2022, 5, 1, 12, 30, 0, 0, DateTimeKind.Unspecified), "Amfiteatar 1", null, "Proglasenje pobjednjika", new DateTime(2022, 5, 2, 11, 0, 0, 0, DateTimeKind.Unspecified), 90 },
                    { 7, 2, new DateTime(2022, 5, 1, 13, 0, 0, 0, DateTimeKind.Unspecified), "Amfiteatar 1", null, "Zatvaranje", new DateTime(2022, 5, 2, 12, 30, 0, 0, DateTimeKind.Unspecified), 30 }
                });

            migrationBuilder.InsertData(
                table: "Kriterij",
                columns: new[] { "KriterijID", "KategorijaID", "Naziv", "Vrijednost" },
                values: new object[,]
                {
                    { 1, 2, "Inovativnost", "50" },
                    { 2, 2, "Implementacija", "50" }
                });

            migrationBuilder.InsertData(
                table: "Projekat",
                columns: new[] { "ProjekatID", "KategorijaID", "Naziv", "Opis", "TimID", "UserId", "Username" },
                values: new object[] { 1, 2, "Neki projekat", "Inovativan projekat. Code dostupan na githubu.", 1, 4, "bablamija" });

            migrationBuilder.InsertData(
                table: "Sponzor",
                columns: new[] { "SponzorID", "Godina", "Iznos", "KategorijaID", "Naziv", "SponzorKategorije", "TipSponzorstva" },
                values: new object[] { 1, 2022, 5000.0, 2, "Sponzor", true, "Zlatni" });

            migrationBuilder.InsertData(
                table: "Rezultat",
                columns: new[] { "RezultatID", "Bod", "Napomena", "ProjekatID" },
                values: new object[] { 1, 90, "Neka napomena", 1 });

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserRole_UserId",
                table: "AspNetUserRoles",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetRoleAspNetUser_UsersId",
                table: "AspNetRoleAspNetUser",
                column: "UsersId");

            migrationBuilder.CreateIndex(
                name: "IX_DogadjajPredavac_PredavacsPredavacId",
                table: "DogadjajPredavac",
                column: "PredavacsPredavacId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "AspNetRoleAspNetUser");

            migrationBuilder.DropTable(
                name: "DogadjajPredavac");

            migrationBuilder.DropIndex(
                name: "IX_AspNetUserRole_UserId",
                table: "AspNetUserRoles");

            migrationBuilder.DeleteData(
                table: "ApiResourceClaims",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "ApiResourceScopes",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "ApiResourceScopes",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "ApiResourceSecrets",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "ApiScopes",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "ApiScopes",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "5963d28a-f188-4aa4-b863-910d91022e1d");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "ed46d55f-5819-4435-9bed-745d9a138cac");

            migrationBuilder.DeleteData(
                table: "AspNetUserClaims",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "AspNetUserClaims",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "AspNetUserClaims",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "AspNetUserClaims",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "AspNetUserClaims",
                keyColumn: "Id",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "AspNetUserClaims",
                keyColumn: "Id",
                keyValue: 6);

            migrationBuilder.DeleteData(
                table: "AspNetUserClaims",
                keyColumn: "Id",
                keyValue: 7);

            migrationBuilder.DeleteData(
                table: "AspNetUserClaims",
                keyColumn: "Id",
                keyValue: 8);

            migrationBuilder.DeleteData(
                table: "AspNetUserClaims",
                keyColumn: "Id",
                keyValue: 9);

            migrationBuilder.DeleteData(
                table: "AspNetUserClaims",
                keyColumn: "Id",
                keyValue: 10);

            migrationBuilder.DeleteData(
                table: "AspNetUserClaims",
                keyColumn: "Id",
                keyValue: 11);

            migrationBuilder.DeleteData(
                table: "AspNetUserClaims",
                keyColumn: "Id",
                keyValue: 12);

            migrationBuilder.DeleteData(
                table: "AspNetUserClaims",
                keyColumn: "Id",
                keyValue: 13);

            migrationBuilder.DeleteData(
                table: "AspNetUserClaims",
                keyColumn: "Id",
                keyValue: 14);

            migrationBuilder.DeleteData(
                table: "AspNetUserClaims",
                keyColumn: "Id",
                keyValue: 15);

            migrationBuilder.DeleteData(
                table: "AspNetUserClaims",
                keyColumn: "Id",
                keyValue: 16);

            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { "e6d3c95c-3fd1-43c0-b764-3e074b086963", "090bdbbc-926a-41f6-9573-a48ba9f64303" });

            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { "37d3d51d-ca09-45ff-b3b1-111b548c3db7", "2adbed90-e3d3-4786-9115-241e02cf5c96" });

            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { "94c2ed89-8d43-420f-be46-a770a3c483f0", "4668c178-3b13-4876-b305-608b1c41548f" });

            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { "e6d3c95c-3fd1-43c0-b764-3e074b086963", "f16b92c8-c7d6-486e-9635-9103263eed30" });

            migrationBuilder.DeleteData(
                table: "ClientGrantTypes",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "ClientGrantTypes",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "ClientPostLogoutRedirectUris",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "ClientRedirectUris",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "ClientScopes",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "ClientScopes",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "ClientScopes",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "ClientScopes",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "ClientScopes",
                keyColumn: "Id",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "ClientSecrets",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "ClientSecrets",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Dogadjaj",
                keyColumn: "DogadjajID",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Dogadjaj",
                keyColumn: "DogadjajID",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Dogadjaj",
                keyColumn: "DogadjajID",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Dogadjaj",
                keyColumn: "DogadjajID",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "Dogadjaj",
                keyColumn: "DogadjajID",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "Dogadjaj",
                keyColumn: "DogadjajID",
                keyValue: 6);

            migrationBuilder.DeleteData(
                table: "Dogadjaj",
                keyColumn: "DogadjajID",
                keyValue: 7);

            migrationBuilder.DeleteData(
                table: "IdentityResourceClaims",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "IdentityResourceClaims",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "IdentityResourceClaims",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "IdentityResourceClaims",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "IdentityResourceClaims",
                keyColumn: "Id",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "IdentityResourceClaims",
                keyColumn: "Id",
                keyValue: 6);

            migrationBuilder.DeleteData(
                table: "IdentityResourceClaims",
                keyColumn: "Id",
                keyValue: 7);

            migrationBuilder.DeleteData(
                table: "IdentityResourceClaims",
                keyColumn: "Id",
                keyValue: 8);

            migrationBuilder.DeleteData(
                table: "IdentityResourceClaims",
                keyColumn: "Id",
                keyValue: 9);

            migrationBuilder.DeleteData(
                table: "IdentityResourceClaims",
                keyColumn: "Id",
                keyValue: 10);

            migrationBuilder.DeleteData(
                table: "IdentityResourceClaims",
                keyColumn: "Id",
                keyValue: 11);

            migrationBuilder.DeleteData(
                table: "IdentityResourceClaims",
                keyColumn: "Id",
                keyValue: 12);

            migrationBuilder.DeleteData(
                table: "IdentityResourceClaims",
                keyColumn: "Id",
                keyValue: 13);

            migrationBuilder.DeleteData(
                table: "IdentityResourceClaims",
                keyColumn: "Id",
                keyValue: 14);

            migrationBuilder.DeleteData(
                table: "IdentityResourceClaims",
                keyColumn: "Id",
                keyValue: 15);

            migrationBuilder.DeleteData(
                table: "IdentityResourceClaims",
                keyColumn: "Id",
                keyValue: 16);

            migrationBuilder.DeleteData(
                table: "Kategorija",
                keyColumn: "KategorijaID",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Kategorija",
                keyColumn: "KategorijaID",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Kriterij",
                keyColumn: "KriterijID",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Kriterij",
                keyColumn: "KriterijID",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Predavac",
                keyColumn: "PredavacId",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Predavac",
                keyColumn: "PredavacId",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "PredavacDogadjaj",
                keyColumns: new[] { "DogadjaId", "PredavacId" },
                keyValues: new object[] { 2, 1 });

            migrationBuilder.DeleteData(
                table: "PredavacDogadjaj",
                keyColumns: new[] { "DogadjaId", "PredavacId" },
                keyValues: new object[] { 2, 2 });

            migrationBuilder.DeleteData(
                table: "Rezultat",
                keyColumn: "RezultatID",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Sponzor",
                keyColumn: "SponzorID",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Sponzor",
                keyColumn: "SponzorID",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "User",
                keyColumn: "UserId",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "User",
                keyColumn: "UserId",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "User",
                keyColumn: "UserId",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "User",
                keyColumn: "UserId",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "Agenda",
                keyColumn: "AgendaID",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Agenda",
                keyColumn: "AgendaID",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "ApiResources",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "37d3d51d-ca09-45ff-b3b1-111b548c3db7");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "94c2ed89-8d43-420f-be46-a770a3c483f0");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "e6d3c95c-3fd1-43c0-b764-3e074b086963");

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "090bdbbc-926a-41f6-9573-a48ba9f64303");

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "2adbed90-e3d3-4786-9115-241e02cf5c96");

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "4668c178-3b13-4876-b305-608b1c41548f");

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "f16b92c8-c7d6-486e-9635-9103263eed30");

            migrationBuilder.DeleteData(
                table: "Clients",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Clients",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "IdentityResources",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "IdentityResources",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "IdentityResources",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Projekat",
                keyColumn: "ProjekatID",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Kategorija",
                keyColumn: "KategorijaID",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Tim",
                keyColumn: "TimID",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Takmicenje",
                keyColumn: "TakmicenjeID",
                keyValue: 1);

            migrationBuilder.RenameIndex(
                name: "IX_AspNetUserRole_RoleId",
                table: "AspNetUserRoles",
                newName: "IX_AspNetUserRoles_RoleId");

            migrationBuilder.CreateIndex(
                name: "IX_PredavacDogadjaj_DogadjaId",
                table: "PredavacDogadjaj",
                column: "DogadjaId");

            migrationBuilder.AddForeignKey(
                name: "FK_PredavacDogadjaj_Dogadjaj",
                table: "PredavacDogadjaj",
                column: "DogadjaId",
                principalTable: "Dogadjaj",
                principalColumn: "DogadjajID");

            migrationBuilder.AddForeignKey(
                name: "FK_PredavacDogadjaj_Predavac",
                table: "PredavacDogadjaj",
                column: "PredavacId",
                principalTable: "Predavac",
                principalColumn: "PredavacId");
        }
    }
}
