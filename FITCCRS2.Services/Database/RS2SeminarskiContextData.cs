using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FITCCRS2.Services.Database
{
    public partial class RS2SeminarskiContext
    {
        partial void OnModelCreatingPartial(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<ApiResource>().HasData(new ApiResource() { Id = 1, Enabled = true, Name = "FITCCRS2", DisplayName = "FITCCRS2", ShowInDiscoveryDocument = true, Created = DateTime.Now, NonEditable = false });

            modelBuilder.Entity<ApiResourceClaim>().HasData(new ApiResourceClaim() { Id = 1, ApiResourceId = 1, Type = "role" });

            modelBuilder.Entity<ApiResourceScope>().HasData(new ApiResourceScope() { Id = 1, Scope = "FITCCRS2.read", ApiResourceId = 1 });
            modelBuilder.Entity<ApiResourceScope>().HasData(new ApiResourceScope() { Id = 2, Scope = "FITCCRS2.write", ApiResourceId = 1 });

            modelBuilder.Entity<ApiResourceSecret>().HasData(new ApiResourceSecret() { Id = 1, ApiResourceId = 1, Value = "DbsYVAAscQ1HaJn5nUwONjP7UzJJclRpWGn/GKOKSw8=", Type = "SharedSecret", Created = DateTime.Now });

            modelBuilder.Entity<ApiScope>().HasData(new ApiScope() { Id = 1, Enabled = true, Name = "FITCCRS2.read", DisplayName = "FITCCRS2.read", Required = false, Emphasize = false, ShowInDiscoveryDocument = true });
            modelBuilder.Entity<ApiScope>().HasData(new ApiScope() { Id = 2, Enabled = true, Name = "FITCCRS2.write", DisplayName = "FITCCRS2.write", Required = false, Emphasize = false, ShowInDiscoveryDocument = true });

            modelBuilder.Entity<Client>().HasData(new Client()
            {
                Id = 1,
                Enabled = true,
                ClientId = "m2m.client",
                ProtocolType = "oidc",
                RequireClientSecret = true,
                ClientName = "Client Credentials Client",
                RequireConsent = false,
                AllowRememberConsent = true,
                AlwaysIncludeUserClaimsInIdToken = false,
                RequirePkce = true,
                AllowPlainTextPkce = false,
                RequireRequestObject = false,
                AllowAccessTokensViaBrowser = false,
                FrontChannelLogoutSessionRequired = true,
                BackChannelLogoutSessionRequired = true,
                AllowOfflineAccess = false,
                IdentityTokenLifetime = 300,
                AccessTokenLifetime = 3600,
                AuthorizationCodeLifetime = 300,
                AbsoluteRefreshTokenLifetime = 2592000,
                SlidingRefreshTokenLifetime = 1296000,
                RefreshTokenUsage = 1,
                UpdateAccessTokenClaimsOnRefresh = false,
                RefreshTokenExpiration = 1,
                AccessTokenType = 0,
                EnableLocalLogin = true,
                IncludeJwtId = true,
                AlwaysSendClientClaims = false,
                ClientClaimsPrefix = "client_",
                Created = DateTime.Now,
                DeviceCodeLifetime = 300,
                NonEditable = false
            });

            modelBuilder.Entity<Client>().HasData(new Client()
            {
                Id = 2,
                Enabled = true,
                ClientId = "interactive",
                ProtocolType = "oidc",
                RequireClientSecret = true,
                RequireConsent = true,
                AllowRememberConsent = true,
                AlwaysIncludeUserClaimsInIdToken = false,
                RequirePkce = true,
                AllowPlainTextPkce = false,
                RequireRequestObject = false,
                AllowAccessTokensViaBrowser = false,
                FrontChannelLogoutUri = "https://localhost:5444/signout-oidc",
                FrontChannelLogoutSessionRequired = true,
                BackChannelLogoutSessionRequired = true,
                AllowOfflineAccess = true,
                IdentityTokenLifetime = 300,
                AccessTokenLifetime = 3600,
                AuthorizationCodeLifetime = 300,
                AbsoluteRefreshTokenLifetime = 2592000,
                SlidingRefreshTokenLifetime = 1296000,
                RefreshTokenUsage = 1,
                UpdateAccessTokenClaimsOnRefresh = false,
                RefreshTokenExpiration = 1,
                AccessTokenType = 0,
                EnableLocalLogin = true,
                IncludeJwtId = true,
                AlwaysSendClientClaims = false,
                ClientClaimsPrefix = "client_",
                Created = DateTime.Now,
                DeviceCodeLifetime = 300,
                NonEditable = false
            });

            modelBuilder.Entity<ClientGrantType>().HasData(new ClientGrantType() { Id = 1, GrantType = "client_credentials", ClientId = 1 });
            modelBuilder.Entity<ClientGrantType>().HasData(new ClientGrantType() { Id = 2, GrantType = "authorization_code", ClientId = 2 });

            modelBuilder.Entity<ClientScope>().HasData(new ClientScope() { Id = 1, Scope = "FITCCRS2.read", ClientId = 1 });
            modelBuilder.Entity<ClientScope>().HasData(new ClientScope() { Id = 2, Scope = "FITCCRS2.write", ClientId = 1 });
            modelBuilder.Entity<ClientScope>().HasData(new ClientScope() { Id = 3, Scope = "openid", ClientId = 2 });
            modelBuilder.Entity<ClientScope>().HasData(new ClientScope() { Id = 4, Scope = "profile", ClientId = 2 });
            modelBuilder.Entity<ClientScope>().HasData(new ClientScope() { Id = 5, Scope = "FITCCRS2.read", ClientId = 2 });

            modelBuilder.Entity<ClientSecret>().HasData(new ClientSecret() { Id = 1, ClientId = 1, Value = "mvcbFoR2Z9+D9UMKjmSJ3rngEopZ+G/oaH+EafS3BLo=", Type = "SharedSecret", Created = DateTime.Now });
            modelBuilder.Entity<ClientSecret>().HasData(new ClientSecret() { Id = 2, ClientId = 2, Value = "mvcbFoR2Z9+D9UMKjmSJ3rngEopZ+G/oaH+EafS3BLo=", Type = "SharedSecret", Created = DateTime.Now });

            modelBuilder.Entity<ClientRedirectUri>().HasData(new ClientRedirectUri() { Id = 1, RedirectUri = "https://localhost:5000/signin-oidc", ClientId = 2 });

            modelBuilder.Entity<ClientPostLogoutRedirectUri>().HasData(new ClientPostLogoutRedirectUri() { Id = 1, PostLogoutRedirectUri = "https://localhost:5000/signout-callback-oidc", ClientId = 2 });

            modelBuilder.Entity<IdentityResource>().HasData(new IdentityResource() { Id = 1, Enabled = true, Name = "openid", DisplayName = "Your user identifier", Required = true, Emphasize = false, ShowInDiscoveryDocument = true, Created = DateTime.Now, NonEditable = false });
            modelBuilder.Entity<IdentityResource>().HasData(new IdentityResource() { Id = 2, Enabled = true, Name = "profile", DisplayName = "User profile", Description = "Your user profile information (first name, last name, etc.)", Required = false, Emphasize = true, ShowInDiscoveryDocument = true, Created = DateTime.Now, NonEditable = false });
            modelBuilder.Entity<IdentityResource>().HasData(new IdentityResource() { Id = 3, Enabled = true, Name = "role", Required = false, Emphasize = false, ShowInDiscoveryDocument = true, Created = DateTime.Now, NonEditable = false });

            modelBuilder.Entity<IdentityResourceClaim>().HasData(new IdentityResourceClaim() { Id = 1, IdentityResourceId = 1, Type = "sub" });
            modelBuilder.Entity<IdentityResourceClaim>().HasData(new IdentityResourceClaim() { Id = 2, IdentityResourceId = 2, Type = "name" });
            modelBuilder.Entity<IdentityResourceClaim>().HasData(new IdentityResourceClaim() { Id = 3, IdentityResourceId = 2, Type = "family_name" });
            modelBuilder.Entity<IdentityResourceClaim>().HasData(new IdentityResourceClaim() { Id = 4, IdentityResourceId = 2, Type = "given_name" });
            modelBuilder.Entity<IdentityResourceClaim>().HasData(new IdentityResourceClaim() { Id = 5, IdentityResourceId = 2, Type = "middle_name" });
            modelBuilder.Entity<IdentityResourceClaim>().HasData(new IdentityResourceClaim() { Id = 6, IdentityResourceId = 2, Type = "nickname" });
            modelBuilder.Entity<IdentityResourceClaim>().HasData(new IdentityResourceClaim() { Id = 7, IdentityResourceId = 2, Type = "preferred_username" });
            modelBuilder.Entity<IdentityResourceClaim>().HasData(new IdentityResourceClaim() { Id = 8, IdentityResourceId = 2, Type = "profile" });
            modelBuilder.Entity<IdentityResourceClaim>().HasData(new IdentityResourceClaim() { Id = 9, IdentityResourceId = 2, Type = "picture" });
            modelBuilder.Entity<IdentityResourceClaim>().HasData(new IdentityResourceClaim() { Id = 10, IdentityResourceId = 2, Type = "website" });
            modelBuilder.Entity<IdentityResourceClaim>().HasData(new IdentityResourceClaim() { Id = 11, IdentityResourceId = 2, Type = "gender" });
            modelBuilder.Entity<IdentityResourceClaim>().HasData(new IdentityResourceClaim() { Id = 12, IdentityResourceId = 2, Type = "birthdate" });
            modelBuilder.Entity<IdentityResourceClaim>().HasData(new IdentityResourceClaim() { Id = 13, IdentityResourceId = 2, Type = "zoneinfo" });
            modelBuilder.Entity<IdentityResourceClaim>().HasData(new IdentityResourceClaim() { Id = 14, IdentityResourceId = 2, Type = "locale" });
            modelBuilder.Entity<IdentityResourceClaim>().HasData(new IdentityResourceClaim() { Id = 15, IdentityResourceId = 2, Type = "updated_at" });
            modelBuilder.Entity<IdentityResourceClaim>().HasData(new IdentityResourceClaim() { Id = 16, IdentityResourceId = 3, Type = "role" });

            modelBuilder.Entity<AspNetRole>().HasData(new AspNetRole() { Id = "37d3d51d-ca09-45ff-b3b1-111b548c3db7", Name = "takmicar", NormalizedName = "TAKMICAR", ConcurrencyStamp = "582faf8e-eb53-4f12-a597-e8dc349010d9" });
            modelBuilder.Entity<AspNetRole>().HasData(new AspNetRole() { Id = "5963d28a-f188-4aa4-b863-910d91022e1d", Name = "sponzor", NormalizedName = "SPONZOR", ConcurrencyStamp = "0dc2bd01-8e63-4d1b-b6fd-e4b750d64463" });
            modelBuilder.Entity<AspNetRole>().HasData(new AspNetRole() { Id = "94c2ed89-8d43-420f-be46-a770a3c483f0", Name = "ziri", NormalizedName = "ZIRI", ConcurrencyStamp = "ff459d69-5e90-4397-8ebd-86984f218e1c" });
            modelBuilder.Entity<AspNetRole>().HasData(new AspNetRole() { Id = "e6d3c95c-3fd1-43c0-b764-3e074b086963", Name = "admin", NormalizedName = "ADMIN", ConcurrencyStamp = "a7f6affb-f83d-46f1-b8f6-3be28d990b4c" });
            modelBuilder.Entity<AspNetRole>().HasData(new AspNetRole() { Id = "ed46d55f-5819-4435-9bed-745d9a138cac", Name = "predavac", NormalizedName = "PREDAVAC", ConcurrencyStamp = "fe164d12-d17a-4b67-be8d-c48ed577f90d" });

            modelBuilder.Entity<AspNetUser>().HasData(new AspNetUser() { Id = "090bdbbc-926a-41f6-9573-a48ba9f64303", UserName = "meli", NormalizedUserName = "MELI", Email = "mellimostar@gmail.com", NormalizedEmail = "MELLIMOSTAR@GMAIL.COM", EmailConfirmed = true, PasswordHash = "AQAAAAEAACcQAAAAENRCLecZkCvoTWVxS7oZR1j+bFCIgDw4L7dqdpCTK/sE67Ai/4nW9zI24Ot75D1UVA==", SecurityStamp = "H7K7Q3VFIDZ36LXORHOX5NIEOCUCNBNB", ConcurrencyStamp = "cbb68c5b-3dae-4106-a2d6-62a4c1be35e9", PhoneNumberConfirmed = false, TwoFactorEnabled = false, LockoutEnabled = true, AccessFailedCount = 0 });
            modelBuilder.Entity<AspNetUser>().HasData(new AspNetUser() { Id = "f16b92c8-c7d6-486e-9635-9103263eed30", UserName = "lamija", NormalizedUserName = "LAMIJA", Email = "lamija.babovic@edu.fit.ba", NormalizedEmail = "LAMIJA.BABOVIC@EDU.FIT.BA", EmailConfirmed = true, PasswordHash = "AQAAAAEAACcQAAAAEMJjk/A6GZEi1sMeNfQz6BSfAoYMQHbha61zcKwboANM2UAy7nspzn7NMQ/m4MBhgg==", SecurityStamp = "N3ELBRQMOT6K6U6HJCF5324JMXWPSS57", ConcurrencyStamp = "80afc46a-3055-476e-8c2a-294f90f72afa", PhoneNumberConfirmed = false, TwoFactorEnabled = false, LockoutEnabled = true, AccessFailedCount = 0 });
            modelBuilder.Entity<AspNetUser>().HasData(new AspNetUser() { Id = "4668c178-3b13-4876-b305-608b1c41548f", UserName = "ziri", NormalizedUserName = "ZIRI", Email = "ziri@ziri.ba", NormalizedEmail = "ZIRI@ZIRI.BA", EmailConfirmed = true, PasswordHash = "AQAAAAEAACcQAAAAEEg2oudD+BP4sB+ORU7mfyJpuSQ/woVogn8bj3P1JP4BAOVIPKOx7dUrdsdK0yxnmQ==", SecurityStamp = "2BEJCF6VFEDLX4ABGLYTYWXCYU37RPHB", ConcurrencyStamp = "84a598f8-bc6e-4ece-bfe7-d5aa71cf1995", PhoneNumberConfirmed = false, TwoFactorEnabled = false, LockoutEnabled = true, AccessFailedCount = 0 });
            modelBuilder.Entity<AspNetUser>().HasData(new AspNetUser() { Id = "2adbed90-e3d3-4786-9115-241e02cf5c96", UserName = "bablamija", NormalizedUserName = "BABLAMIJA", Email = "bablamija@gmail.com", NormalizedEmail = "BABLAMIJA@GMAIL.COM", EmailConfirmed = true, PasswordHash = "AQAAAAEAACcQAAAAED4Q8lm8HuZKCoxF5hbQe/Q0dZRlEn0yCUCFnZXFx2GZLjhEd9VCW3ezjkd6BeBymw==", SecurityStamp = "BOSLSMZK63NKAXROUVKFEAUMQJV6KJPK", ConcurrencyStamp = "e142fa65-04f0-4fc2-b971-1e731caca934", PhoneNumberConfirmed = false, TwoFactorEnabled = false, LockoutEnabled = true, AccessFailedCount = 0 });

            modelBuilder.Entity<AspNetUserRole>().HasData(new AspNetUserRole() { RoleId = "e6d3c95c-3fd1-43c0-b764-3e074b086963", UserId = "090bdbbc-926a-41f6-9573-a48ba9f64303" });
            modelBuilder.Entity<AspNetUserRole>().HasData(new AspNetUserRole() { RoleId = "e6d3c95c-3fd1-43c0-b764-3e074b086963", UserId = "f16b92c8-c7d6-486e-9635-9103263eed30" });
            modelBuilder.Entity<AspNetUserRole>().HasData(new AspNetUserRole() { RoleId = "94c2ed89-8d43-420f-be46-a770a3c483f0", UserId = "4668c178-3b13-4876-b305-608b1c41548f" });
            modelBuilder.Entity<AspNetUserRole>().HasData(new AspNetUserRole() { RoleId = "37d3d51d-ca09-45ff-b3b1-111b548c3db7", UserId = "2adbed90-e3d3-4786-9115-241e02cf5c96" });
            modelBuilder.Entity<AspNetUserRole>().HasData(new AspNetUserRole() { RoleId = "5963d28a-f188-4aa4-b863-910d91022e1d", UserId = "f16b92c8-c7d6-486e-9635-9103263eed30" });


            modelBuilder.Entity<AspNetUserClaim>().HasData(new AspNetUserClaim() { Id = 1, UserId = "090bdbbc-926a-41f6-9573-a48ba9f64303", ClaimType = "name", ClaimValue = "Melissa Memic" });
            modelBuilder.Entity<AspNetUserClaim>().HasData(new AspNetUserClaim() { Id = 2, UserId = "090bdbbc-926a-41f6-9573-a48ba9f64303", ClaimType = "given_name", ClaimValue = "Melissa" });
            modelBuilder.Entity<AspNetUserClaim>().HasData(new AspNetUserClaim() { Id = 3, UserId = "090bdbbc-926a-41f6-9573-a48ba9f64303", ClaimType = "family_name", ClaimValue = "Memic" });
            modelBuilder.Entity<AspNetUserClaim>().HasData(new AspNetUserClaim() { Id = 4, UserId = "090bdbbc-926a-41f6-9573-a48ba9f64303", ClaimType = "website", ClaimValue = "http://google.com" });

            modelBuilder.Entity<AspNetUserClaim>().HasData(new AspNetUserClaim() { Id = 5, UserId = "f16b92c8-c7d6-486e-9635-9103263eed30", ClaimType = "name", ClaimValue = "Lamija Babovic" });
            modelBuilder.Entity<AspNetUserClaim>().HasData(new AspNetUserClaim() { Id = 6, UserId = "f16b92c8-c7d6-486e-9635-9103263eed30", ClaimType = "given_name", ClaimValue = "Lamija" });
            modelBuilder.Entity<AspNetUserClaim>().HasData(new AspNetUserClaim() { Id = 7, UserId = "f16b92c8-c7d6-486e-9635-9103263eed30", ClaimType = "family_name", ClaimValue = "Babovic" });
            modelBuilder.Entity<AspNetUserClaim>().HasData(new AspNetUserClaim() { Id = 8, UserId = "f16b92c8-c7d6-486e-9635-9103263eed30", ClaimType = "website", ClaimValue = "http://google.com" });

            modelBuilder.Entity<AspNetUserClaim>().HasData(new AspNetUserClaim() { Id = 9, UserId = "4668c178-3b13-4876-b305-608b1c41548f", ClaimType = "name", ClaimValue = "Ziri" });
            modelBuilder.Entity<AspNetUserClaim>().HasData(new AspNetUserClaim() { Id = 10, UserId = "4668c178-3b13-4876-b305-608b1c41548f", ClaimType = "given_name", ClaimValue = "Ziri" });
            modelBuilder.Entity<AspNetUserClaim>().HasData(new AspNetUserClaim() { Id = 11, UserId = "4668c178-3b13-4876-b305-608b1c41548f", ClaimType = "family_name", ClaimValue = "Ziri" });
            modelBuilder.Entity<AspNetUserClaim>().HasData(new AspNetUserClaim() { Id = 12, UserId = "4668c178-3b13-4876-b305-608b1c41548f", ClaimType = "website", ClaimValue = "http://google.com" });

            modelBuilder.Entity<AspNetUserClaim>().HasData(new AspNetUserClaim() { Id = 13, UserId = "2adbed90-e3d3-4786-9115-241e02cf5c96", ClaimType = "name", ClaimValue = "Lamija Bab" });
            modelBuilder.Entity<AspNetUserClaim>().HasData(new AspNetUserClaim() { Id = 14, UserId = "2adbed90-e3d3-4786-9115-241e02cf5c96", ClaimType = "given_name", ClaimValue = "Lamija" });
            modelBuilder.Entity<AspNetUserClaim>().HasData(new AspNetUserClaim() { Id = 15, UserId = "2adbed90-e3d3-4786-9115-241e02cf5c96", ClaimType = "family_name", ClaimValue = "Bab" });
            modelBuilder.Entity<AspNetUserClaim>().HasData(new AspNetUserClaim() { Id = 16, UserId = "2adbed90-e3d3-4786-9115-241e02cf5c96", ClaimType = "website", ClaimValue = "https://github.com/LamijaBabovic" });

            modelBuilder.Entity<User>().HasData(new User() { UserId = 1, Name = "Melissa", Lastname = "Memic", IsAllowed = true, Username = "meli", Website = "http://google.com", Role = "admin" });
            modelBuilder.Entity<User>().HasData(new User() { UserId = 2, Name = "lamija", Lastname = "Babovic", IsAllowed = true, Username = "lamija", Website = "http://google.com", Role = "admin" });
            modelBuilder.Entity<User>().HasData(new User() { UserId = 3, Name = "Ziri", Lastname = "Ziri", IsAllowed = true, Username = "ziri", Website = "http://google.com", Role = "ziri" });
            modelBuilder.Entity<User>().HasData(new User() { UserId = 4, Name = "lamija", Lastname = "Bab", IsAllowed = true, Username = "bablamija", Website = "http://google.com", Role = "takmicar" });
            modelBuilder.Entity<User>().HasData(new User() { UserId = 5, Name = "Sponzor", Lastname = "Sponzor", IsAllowed = true, Username = "sponzor", Website = "http://google.com", Role = "sponzor" });

            modelBuilder.Entity<Takmicenje>().HasData(new Takmicenje() { TakmicenjeId = 1, BrojDana = 2, Pocetak = Convert.ToDateTime("2022-05-01 10:00:00.000"), Kraj = Convert.ToDateTime("2022-05-02 10:00:00.000"), Naziv = "FIT Coding Challenge 2022", Godina = 2022, Slogan = " " });

            modelBuilder.Entity<Kategorija>().HasData(new Kategorija() { KategorijaId = 1, Naziv = "Programiraje", Opis = "Takmicenje u oblasti poznavanja programiranja", TakmicenjeId = 1 });
            modelBuilder.Entity<Kategorija>().HasData(new Kategorija() { KategorijaId = 2, Naziv = "Inovacije", Opis = "Kreiranje najinovativnijeg rjesenja", TakmicenjeId = 1 });
            modelBuilder.Entity<Kategorija>().HasData(new Kategorija() { KategorijaId = 3, Naziv = "Programiraje igara", Opis = "Takmicenje u oblasti poznavanja programiranja igara", TakmicenjeId = 1 });

            modelBuilder.Entity<Agendum>().HasData(new Agendum() { AgendaId = 1, TakmicenjeId = 1, Dan = 1 });
            modelBuilder.Entity<Agendum>().HasData(new Agendum() { AgendaId = 2, TakmicenjeId = 1, Dan = 2 });

            modelBuilder.Entity<Dogadjaj>().HasData(new Dogadjaj() { DogadjajId = 1, AgendaId = 1, Naziv = "Otvaranje", Lokacija = "Amfiteatar 1", Pocetak = Convert.ToDateTime("2022-05-01 10:00:00.000"), Kraj = Convert.ToDateTime("2022-05-01 10:30:00.000"), Trajanje = 30 });
            modelBuilder.Entity<Dogadjaj>().HasData(new Dogadjaj() { DogadjajId = 2, AgendaId = 1, Naziv = "Tribine", Lokacija = "Amfiteatar 1", Pocetak = Convert.ToDateTime("2022-05-01 11:00:00.000"), Kraj = Convert.ToDateTime("2022-05-01 12:30:00.000"), Trajanje = 90 });
            modelBuilder.Entity<Dogadjaj>().HasData(new Dogadjaj() { DogadjajId = 3, AgendaId = 1, Naziv = "Inovacije", Lokacija = "Amfiteatar 3", Pocetak = Convert.ToDateTime("2022-05-01 11:00:00.000"), Kraj = Convert.ToDateTime("2022-05-01 12:30:00.000"), Trajanje = 90 });
            modelBuilder.Entity<Dogadjaj>().HasData(new Dogadjaj() { DogadjajId = 4, AgendaId = 1, Naziv = "Programiranja", Lokacija = "Amfiteatar 2", Pocetak = Convert.ToDateTime("2022-05-01 11:00:00.000"), Kraj = Convert.ToDateTime("2022-05-01 12:30:00.000"), Trajanje = 90 });
            modelBuilder.Entity<Dogadjaj>().HasData(new Dogadjaj() { DogadjajId = 5, AgendaId = 1, Naziv = "Programiranja igara", Lokacija = "AKS", Pocetak = Convert.ToDateTime("2022-05-01 11:00:00.000"), Kraj = Convert.ToDateTime("2022-05-01 12:30:00.000"), Trajanje = 90 });
            modelBuilder.Entity<Dogadjaj>().HasData(new Dogadjaj() { DogadjajId = 6, AgendaId = 2, Naziv = "Proglasenje pobjednjika", Lokacija = "Amfiteatar 1", Pocetak = Convert.ToDateTime("2022-05-02 11:00:00.000"), Kraj = Convert.ToDateTime("2022-05-01 12:30:00.000"), Trajanje = 90 });
            modelBuilder.Entity<Dogadjaj>().HasData(new Dogadjaj() { DogadjajId = 7, AgendaId = 2, Naziv = "Zatvaranje", Lokacija = "Amfiteatar 1", Pocetak = Convert.ToDateTime("2022-05-02 12:30:00.000"), Kraj = Convert.ToDateTime("2022-05-01 13:00:00.000"), Trajanje = 30 });

            modelBuilder.Entity<Predavac>().HasData(new Predavac() { Ime = "Neko", Prezime = "Neko", DogadjaId = 2, PredavacId = 1, Email = "neko.ne@nesto.ba", Ustanova = "Firma", Zvanje = "Software inzenjer" });
            modelBuilder.Entity<Predavac>().HasData(new Predavac() { Ime = "Neko", Prezime = "Drugi", DogadjaId = 2, PredavacId = 2, Email = "neko.dr@nesto.ba", Ustanova = "Firma nova", Zvanje = "Software inzenjer" });

            modelBuilder.Entity<Database.PredavacDogadjaj>().HasData(new Database.PredavacDogadjaj() { PredavacId = 1, DogadjaId = 2 });
            modelBuilder.Entity<Database.PredavacDogadjaj>().HasData(new Database.PredavacDogadjaj() { PredavacId = 2, DogadjaId = 2 });

            modelBuilder.Entity<Tim>().HasData(new Tim() { UserId = 4, Naziv = "Tim", BrojClanova = 1, TakmicenjeId = 1, TimId = 1, Username = "bablamija" });
            modelBuilder.Entity<Napomena>().HasData(new Napomena() { NapomenaId = 1, Poruka = "Takmicar pokazuje interes.", UsernameTakmicar = "bablamija", UserName = "sponzor" });

            modelBuilder.Entity<Sponzor>().HasData(new Sponzor() { SponzorId = 1, Godina = 2022, KategorijaId=2, Iznos = 5000, Naziv = "Sponzor", SponzorKategorije = false, TipSponzorstva = "Zlatni" });
            modelBuilder.Entity<Sponzor>().HasData(new Sponzor() { SponzorId = 2, Godina = 2022, KategorijaId=null, Iznos = 2500, Naziv = "Sponzor", SponzorKategorije = false, TipSponzorstva = "Srebreni" });

            modelBuilder.Entity<Projekat>().HasData(new Projekat() { ProjekatId = 1, TimId = 1, UserId = 4, Username = "bablamija", KategorijaId = 2, Naziv = "Neki projekat", Opis = "Inovativan projekat. Code dostupan na githubu." });

            modelBuilder.Entity<Rezultat>().HasData(new Rezultat() { RezultatId = 1, ProjekatId = 1, Bod = 90, Napomena = "Neka napomena" });

            modelBuilder.Entity<Kriterij>().HasData(new Kriterij() { KriterijId = 1, KategorijaId = 2, Naziv = "Inovativnost", Vrijednost = "50" });
            modelBuilder.Entity<Kriterij>().HasData(new Kriterij() { KriterijId = 2, KategorijaId = 2, Naziv = "Implementacija", Vrijednost = "50" });

        }
    }
}
