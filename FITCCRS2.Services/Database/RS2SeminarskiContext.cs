using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace FITCCRS2.Services.Database
{
    public partial class RS2SeminarskiContext : DbContext
    {
        public RS2SeminarskiContext()
        {
        }

        public RS2SeminarskiContext(DbContextOptions<RS2SeminarskiContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Agendum> Agenda { get; set; } = null!;
        public virtual DbSet<ApiResource> ApiResources { get; set; } = null!;
        public virtual DbSet<ApiResourceClaim> ApiResourceClaims { get; set; } = null!;
        public virtual DbSet<ApiResourceProperty> ApiResourceProperties { get; set; } = null!;
        public virtual DbSet<ApiResourceScope> ApiResourceScopes { get; set; } = null!;
        public virtual DbSet<ApiResourceSecret> ApiResourceSecrets { get; set; } = null!;
        public virtual DbSet<ApiScope> ApiScopes { get; set; } = null!;
        public virtual DbSet<ApiScopeClaim> ApiScopeClaims { get; set; } = null!;
        public virtual DbSet<ApiScopeProperty> ApiScopeProperties { get; set; } = null!;
        public virtual DbSet<AspNetRole> AspNetRoles { get; set; } = null!;
        public virtual DbSet<AspNetRoleClaim> AspNetRoleClaims { get; set; } = null!;
        public virtual DbSet<AspNetUser> AspNetUsers { get; set; } = null!;
        public virtual DbSet<AspNetUserClaim> AspNetUserClaims { get; set; } = null!;
        public virtual DbSet<AspNetUserLogin> AspNetUserLogins { get; set; } = null!;
        public virtual DbSet<AspNetUserToken> AspNetUserTokens { get; set; } = null!;
        public virtual DbSet<AspNetUserRole> AspNetUserRoles { get; set; } = null!;
        public virtual DbSet<Client> Clients { get; set; } = null!;
        public virtual DbSet<ClientClaim> ClientClaims { get; set; } = null!;
        public virtual DbSet<ClientCorsOrigin> ClientCorsOrigins { get; set; } = null!;
        public virtual DbSet<ClientGrantType> ClientGrantTypes { get; set; } = null!;
        public virtual DbSet<ClientIdPrestriction> ClientIdPrestrictions { get; set; } = null!;
        public virtual DbSet<ClientPostLogoutRedirectUri> ClientPostLogoutRedirectUris { get; set; } = null!;
        public virtual DbSet<ClientProperty> ClientProperties { get; set; } = null!;
        public virtual DbSet<ClientRedirectUri> ClientRedirectUris { get; set; } = null!;
        public virtual DbSet<ClientScope> ClientScopes { get; set; } = null!;
        public virtual DbSet<ClientSecret> ClientSecrets { get; set; } = null!;
        public virtual DbSet<DeviceCode> DeviceCodes { get; set; } = null!;
        public virtual DbSet<Dogadjaj> Dogadjajs { get; set; } = null!;
        public virtual DbSet<IdentityResource> IdentityResources { get; set; } = null!;
        public virtual DbSet<IdentityResourceClaim> IdentityResourceClaims { get; set; } = null!;
        public virtual DbSet<IdentityResourceProperty> IdentityResourceProperties { get; set; } = null!;
        public virtual DbSet<Kategorija> Kategorijas { get; set; } = null!;
        public virtual DbSet<Kriterij> Kriterijs { get; set; } = null!;
        public virtual DbSet<PersistedGrant> PersistedGrants { get; set; } = null!;
        public virtual DbSet<Predavac> Predavacs { get; set; } = null!;
        public virtual DbSet<Projekat> Projekats { get; set; } = null!;
        public virtual DbSet<Rezultat> Rezultats { get; set; } = null!;
        public virtual DbSet<Sponzor> Sponzors { get; set; } = null!;
        public virtual DbSet<Takmicenje> Takmicenjes { get; set; } = null!;
        public virtual DbSet<Tim> Tims { get; set; } = null!;
        public virtual DbSet<User> Users { get; set; } = null!;
        public virtual DbSet<Napomena> Napomenas { get; set; } = null!;

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
                optionsBuilder.UseSqlServer("Server=localhost, 1433;Initial Catalog=vol_1; user=SA; Password=Password123");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Agendum>(entity =>
            {
                entity.HasKey(e => e.AgendaId);

                entity.Property(e => e.AgendaId).HasColumnName("AgendaID");

                entity.Property(e => e.TakmicenjeId).HasColumnName("TakmicenjeID");

                entity.HasOne(d => d.Takmicenje)
                    .WithMany(p => p.Agendums)
                    .HasForeignKey(d => d.TakmicenjeId)
                    .HasConstraintName("FK_Agenda_Takmicenje");
            });

            modelBuilder.Entity<ApiResource>(entity =>
            {
                entity.HasIndex(e => e.Name, "IX_ApiResources_Name")
                    .IsUnique();

                entity.Property(e => e.AllowedAccessTokenSigningAlgorithms).HasMaxLength(100);

                entity.Property(e => e.Description).HasMaxLength(1000);

                entity.Property(e => e.DisplayName).HasMaxLength(200);

                entity.Property(e => e.Name).HasMaxLength(200);
            });

            modelBuilder.Entity<ApiResourceClaim>(entity =>
            {
                entity.HasIndex(e => e.ApiResourceId, "IX_ApiResourceClaims_ApiResourceId");

                entity.Property(e => e.Type).HasMaxLength(200);

                entity.HasOne(d => d.ApiResource)
                    .WithMany(p => p.ApiResourceClaims)
                    .HasForeignKey(d => d.ApiResourceId);
            });

            modelBuilder.Entity<ApiResourceProperty>(entity =>
            {
                entity.HasIndex(e => e.ApiResourceId, "IX_ApiResourceProperties_ApiResourceId");

                entity.Property(e => e.Key).HasMaxLength(250);

                entity.Property(e => e.Value).HasMaxLength(2000);

                entity.HasOne(d => d.ApiResource)
                    .WithMany(p => p.ApiResourceProperties)
                    .HasForeignKey(d => d.ApiResourceId);
            });

            modelBuilder.Entity<ApiResourceScope>(entity =>
            {
                entity.HasIndex(e => e.ApiResourceId, "IX_ApiResourceScopes_ApiResourceId");

                entity.Property(e => e.Scope).HasMaxLength(200);

                entity.HasOne(d => d.ApiResource)
                    .WithMany(p => p.ApiResourceScopes)
                    .HasForeignKey(d => d.ApiResourceId);
            });

            modelBuilder.Entity<ApiResourceSecret>(entity =>
            {
                entity.HasIndex(e => e.ApiResourceId, "IX_ApiResourceSecrets_ApiResourceId");

                entity.Property(e => e.Description).HasMaxLength(1000);

                entity.Property(e => e.Type).HasMaxLength(250);

                entity.Property(e => e.Value).HasMaxLength(4000);

                entity.HasOne(d => d.ApiResource)
                    .WithMany(p => p.ApiResourceSecrets)
                    .HasForeignKey(d => d.ApiResourceId);
            });

            modelBuilder.Entity<ApiScope>(entity =>
            {
                entity.HasIndex(e => e.Name, "IX_ApiScopes_Name")
                    .IsUnique();

                entity.Property(e => e.Description).HasMaxLength(1000);

                entity.Property(e => e.DisplayName).HasMaxLength(200);

                entity.Property(e => e.Name).HasMaxLength(200);
            });

            modelBuilder.Entity<ApiScopeClaim>(entity =>
            {
                entity.HasIndex(e => e.ScopeId, "IX_ApiScopeClaims_ScopeId");

                entity.Property(e => e.Type).HasMaxLength(200);

                entity.HasOne(d => d.Scope)
                    .WithMany(p => p.ApiScopeClaims)
                    .HasForeignKey(d => d.ScopeId);
            });

            modelBuilder.Entity<ApiScopeProperty>(entity =>
            {
                entity.HasIndex(e => e.ScopeId, "IX_ApiScopeProperties_ScopeId");

                entity.Property(e => e.Key).HasMaxLength(250);

                entity.Property(e => e.Value).HasMaxLength(2000);

                entity.HasOne(d => d.Scope)
                    .WithMany(p => p.ApiScopeProperties)
                    .HasForeignKey(d => d.ScopeId);
            });

            modelBuilder.Entity<AspNetRole>(entity =>
            {
                entity.HasIndex(e => e.NormalizedName, "RoleNameIndex")
                    .IsUnique()
                    .HasFilter("([NormalizedName] IS NOT NULL)");

                entity.Property(e => e.Name).HasMaxLength(256);

                entity.Property(e => e.NormalizedName).HasMaxLength(256);
            });

            modelBuilder.Entity<AspNetRoleClaim>(entity =>
            {
                entity.HasIndex(e => e.RoleId, "IX_AspNetRoleClaims_RoleId");

                entity.HasOne(d => d.Role)
                    .WithMany(p => p.AspNetRoleClaims)
                    .HasForeignKey(d => d.RoleId);
            });

            modelBuilder.Entity<AspNetUser>(entity =>
            {
                entity.HasIndex(e => e.NormalizedEmail, "EmailIndex");

                entity.HasIndex(e => e.NormalizedUserName, "UserNameIndex")
                    .IsUnique()
                    .HasFilter("([NormalizedUserName] IS NOT NULL)");

                entity.Property(e => e.Email).HasMaxLength(256);

                entity.Property(e => e.NormalizedEmail).HasMaxLength(256);

                entity.Property(e => e.NormalizedUserName).HasMaxLength(256);

                entity.Property(e => e.UserName).HasMaxLength(256);

                entity.HasMany(d => d.Roles)
                    .WithMany(p => p.Users);
                    //.UsingEntity<Dictionary<string, object>>(
                    //    "AspNetUserRole",
                    //    l => l.HasOne<AspNetRole>().WithMany().HasForeignKey("RoleId"),
                    //    r => r.HasOne<AspNetUser>().WithMany().HasForeignKey("UserId"),
                    //    j =>
                    //    {
                    //        j.HasKey("UserId", "RoleId");

                    //        j.ToTable("AspNetUserRoles");

                    //        j.HasIndex(new[] { "RoleId" }, "IX_AspNetUserRoles_RoleId");
                    //    });
            });

            modelBuilder.Entity<AspNetUserClaim>(entity =>
            {
                entity.HasIndex(e => e.UserId, "IX_AspNetUserClaims_UserId");

                entity.HasOne(d => d.User)
                    .WithMany(p => p.AspNetUserClaims)
                    .HasForeignKey(d => d.UserId);
            });

            modelBuilder.Entity<AspNetUserLogin>(entity =>
            {
                entity.HasKey(e => new { e.LoginProvider, e.ProviderKey });

                entity.HasIndex(e => e.UserId, "IX_AspNetUserLogins_UserId");

                entity.HasOne(d => d.User)
                    .WithMany(p => p.AspNetUserLogins)
                    .HasForeignKey(d => d.UserId);
            });

            modelBuilder.Entity<AspNetUserToken>(entity =>
            {
                entity.HasKey(e => new { e.UserId, e.LoginProvider, e.Name });

                entity.HasOne(d => d.User)
                    .WithMany(p => p.AspNetUserTokens)
                    .HasForeignKey(d => d.UserId);
            });

            modelBuilder.Entity<AspNetUserRole>(entity =>
            {
                entity.HasKey(e => new { e.UserId, e.RoleId });
                entity.HasIndex(e => e.UserId, "IX_AspNetUserRole_UserId");
                entity.HasIndex(e => e.RoleId, "IX_AspNetUserRole_RoleId");
            });

            modelBuilder.Entity<Client>(entity =>
            {
                entity.HasIndex(e => e.ClientId, "IX_Clients_ClientId")
                    .IsUnique();

                entity.Property(e => e.AllowedIdentityTokenSigningAlgorithms).HasMaxLength(100);

                entity.Property(e => e.BackChannelLogoutUri).HasMaxLength(2000);

                entity.Property(e => e.ClientClaimsPrefix).HasMaxLength(200);

                entity.Property(e => e.ClientId).HasMaxLength(200);

                entity.Property(e => e.ClientName).HasMaxLength(200);

                entity.Property(e => e.ClientUri).HasMaxLength(2000);

                entity.Property(e => e.Description).HasMaxLength(1000);

                entity.Property(e => e.FrontChannelLogoutUri).HasMaxLength(2000);

                entity.Property(e => e.LogoUri).HasMaxLength(2000);

                entity.Property(e => e.PairWiseSubjectSalt).HasMaxLength(200);

                entity.Property(e => e.ProtocolType).HasMaxLength(200);

                entity.Property(e => e.UserCodeType).HasMaxLength(100);
            });

            modelBuilder.Entity<ClientClaim>(entity =>
            {
                entity.HasIndex(e => e.ClientId, "IX_ClientClaims_ClientId");

                entity.Property(e => e.Type).HasMaxLength(250);

                entity.Property(e => e.Value).HasMaxLength(250);

                entity.HasOne(d => d.Client)
                    .WithMany(p => p.ClientClaims)
                    .HasForeignKey(d => d.ClientId);
            });

            modelBuilder.Entity<ClientCorsOrigin>(entity =>
            {
                entity.HasIndex(e => e.ClientId, "IX_ClientCorsOrigins_ClientId");

                entity.Property(e => e.Origin).HasMaxLength(150);

                entity.HasOne(d => d.Client)
                    .WithMany(p => p.ClientCorsOrigins)
                    .HasForeignKey(d => d.ClientId);
            });

            modelBuilder.Entity<ClientGrantType>(entity =>
            {
                entity.HasIndex(e => e.ClientId, "IX_ClientGrantTypes_ClientId");

                entity.Property(e => e.GrantType).HasMaxLength(250);

                entity.HasOne(d => d.Client)
                    .WithMany(p => p.ClientGrantTypes)
                    .HasForeignKey(d => d.ClientId);
            });

            modelBuilder.Entity<ClientIdPrestriction>(entity =>
            {
                entity.ToTable("ClientIdPRestrictions");

                entity.HasIndex(e => e.ClientId, "IX_ClientIdPRestrictions_ClientId");

                entity.Property(e => e.Provider).HasMaxLength(200);

                entity.HasOne(d => d.Client)
                    .WithMany(p => p.ClientIdPrestrictions)
                    .HasForeignKey(d => d.ClientId);
            });

            modelBuilder.Entity<ClientPostLogoutRedirectUri>(entity =>
            {
                entity.HasIndex(e => e.ClientId, "IX_ClientPostLogoutRedirectUris_ClientId");

                entity.Property(e => e.PostLogoutRedirectUri).HasMaxLength(2000);

                entity.HasOne(d => d.Client)
                    .WithMany(p => p.ClientPostLogoutRedirectUris)
                    .HasForeignKey(d => d.ClientId);
            });

            modelBuilder.Entity<ClientProperty>(entity =>
            {
                entity.HasIndex(e => e.ClientId, "IX_ClientProperties_ClientId");

                entity.Property(e => e.Key).HasMaxLength(250);

                entity.Property(e => e.Value).HasMaxLength(2000);

                entity.HasOne(d => d.Client)
                    .WithMany(p => p.ClientProperties)
                    .HasForeignKey(d => d.ClientId);
            });

            modelBuilder.Entity<ClientRedirectUri>(entity =>
            {
                entity.HasIndex(e => e.ClientId, "IX_ClientRedirectUris_ClientId");

                entity.Property(e => e.RedirectUri).HasMaxLength(2000);

                entity.HasOne(d => d.Client)
                    .WithMany(p => p.ClientRedirectUris)
                    .HasForeignKey(d => d.ClientId);
            });

            modelBuilder.Entity<ClientScope>(entity =>
            {
                entity.HasIndex(e => e.ClientId, "IX_ClientScopes_ClientId");

                entity.Property(e => e.Scope).HasMaxLength(200);

                entity.HasOne(d => d.Client)
                    .WithMany(p => p.ClientScopes)
                    .HasForeignKey(d => d.ClientId);
            });

            modelBuilder.Entity<ClientSecret>(entity =>
            {
                entity.HasIndex(e => e.ClientId, "IX_ClientSecrets_ClientId");

                entity.Property(e => e.Description).HasMaxLength(2000);

                entity.Property(e => e.Type).HasMaxLength(250);

                entity.Property(e => e.Value).HasMaxLength(4000);

                entity.HasOne(d => d.Client)
                    .WithMany(p => p.ClientSecrets)
                    .HasForeignKey(d => d.ClientId);
            });

            modelBuilder.Entity<DeviceCode>(entity =>
            {
                entity.HasKey(e => e.UserCode);

                entity.HasIndex(e => e.DeviceCode1, "IX_DeviceCodes_DeviceCode")
                    .IsUnique();

                entity.HasIndex(e => e.Expiration, "IX_DeviceCodes_Expiration");

                entity.Property(e => e.UserCode).HasMaxLength(200);

                entity.Property(e => e.ClientId).HasMaxLength(200);

                entity.Property(e => e.Description).HasMaxLength(200);

                entity.Property(e => e.DeviceCode1)
                    .HasMaxLength(200)
                    .HasColumnName("DeviceCode");

                entity.Property(e => e.SessionId).HasMaxLength(100);

                entity.Property(e => e.SubjectId).HasMaxLength(200);
            });

            modelBuilder.Entity<Dogadjaj>(entity =>
            {
                entity.HasKey(e => e.DogadjajId);

                entity.ToTable("Dogadjaj");

                entity.Property(e => e.DogadjajId).HasColumnName("DogadjajID");

                entity.Property(e => e.AgendaId).HasColumnName("AgendaID");

                entity.Property(e => e.Kraj).HasColumnType("datetime");

                entity.Property(e => e.Napomena).HasMaxLength(255);

                entity.Property(e => e.Naziv).HasMaxLength(50);

                entity.Property(e => e.Pocetak).HasColumnType("datetime");

                entity.HasOne(d => d.Agenda)
                    .WithMany(p => p.Dogadjajs)
                    .HasForeignKey(d => d.AgendaId)
                    .HasConstraintName("FK_Dogadjaj_Agenda");
            });

            modelBuilder.Entity<IdentityResource>(entity =>
            {
                entity.HasIndex(e => e.Name, "IX_IdentityResources_Name")
                    .IsUnique();

                entity.Property(e => e.Description).HasMaxLength(1000);

                entity.Property(e => e.DisplayName).HasMaxLength(200);

                entity.Property(e => e.Name).HasMaxLength(200);
            });

            modelBuilder.Entity<IdentityResourceClaim>(entity =>
            {
                entity.HasIndex(e => e.IdentityResourceId, "IX_IdentityResourceClaims_IdentityResourceId");

                entity.Property(e => e.Type).HasMaxLength(200);

                entity.HasOne(d => d.IdentityResource)
                    .WithMany(p => p.IdentityResourceClaims)
                    .HasForeignKey(d => d.IdentityResourceId);
            });

            modelBuilder.Entity<IdentityResourceProperty>(entity =>
            {
                entity.HasIndex(e => e.IdentityResourceId, "IX_IdentityResourceProperties_IdentityResourceId");

                entity.Property(e => e.Key).HasMaxLength(250);

                entity.Property(e => e.Value).HasMaxLength(2000);

                entity.HasOne(d => d.IdentityResource)
                    .WithMany(p => p.IdentityResourceProperties)
                    .HasForeignKey(d => d.IdentityResourceId);
            });

            modelBuilder.Entity<Kategorija>(entity =>
            {
                entity.HasKey(e => e.KategorijaId);

                entity.ToTable("Kategorija");

                entity.Property(e => e.KategorijaId).HasColumnName("KategorijaID");

                entity.Property(e => e.Naziv).HasMaxLength(255);

                entity.Property(e => e.Opis).HasMaxLength(255);

                entity.Property(e => e.TakmicenjeId).HasColumnName("TakmicenjeID");

                entity.HasOne(d => d.Takmicenje)
                    .WithMany(p => p.Kategorijas)
                    .HasForeignKey(d => d.TakmicenjeId)
                    .HasConstraintName("FK_Kategorija_Takmicenje");
            });

            modelBuilder.Entity<Kriterij>(entity =>
            {
                entity.HasKey(e => e.KriterijId);

                entity.ToTable("Kriterij");

                entity.Property(e => e.KriterijId).HasColumnName("KriterijID");

                entity.Property(e => e.KategorijaId).HasColumnName("KategorijaID");

                entity.Property(e => e.Naziv).HasMaxLength(255);

                entity.Property(e => e.Vrijednost).HasMaxLength(50);

                entity.HasOne(d => d.Kategorija)
                    .WithMany(p => p.Kriterijs)
                    .HasForeignKey(d => d.KategorijaId)
                    .HasConstraintName("FK_Kriterij_Kategorija");
            });

            modelBuilder.Entity<PersistedGrant>(entity =>
            {
                entity.HasKey(e => e.Key);

                entity.HasIndex(e => e.Expiration, "IX_PersistedGrants_Expiration");

                entity.HasIndex(e => new { e.SubjectId, e.ClientId, e.Type }, "IX_PersistedGrants_SubjectId_ClientId_Type");

                entity.HasIndex(e => new { e.SubjectId, e.SessionId, e.Type }, "IX_PersistedGrants_SubjectId_SessionId_Type");

                entity.Property(e => e.Key).HasMaxLength(200);

                entity.Property(e => e.ClientId).HasMaxLength(200);

                entity.Property(e => e.Description).HasMaxLength(200);

                entity.Property(e => e.SessionId).HasMaxLength(100);

                entity.Property(e => e.SubjectId).HasMaxLength(200);

                entity.Property(e => e.Type).HasMaxLength(50);
            });

            modelBuilder.Entity<Predavac>(entity =>
            {
                entity.HasKey(e => e.PredavacId);

                entity.ToTable("Predavac");

                entity.Property(e => e.Email).HasMaxLength(50);

                entity.Property(e => e.Ime)
                    .HasMaxLength(100)
                    .IsFixedLength();

                entity.Property(e => e.Prezime)
                    .HasMaxLength(100)
                    .IsFixedLength();

                entity.HasMany(d => d.Dogadjas)
                    .WithMany(p => p.Predavacs);
                    //.UsingEntity<Dictionary<string, object>>(
                    //    "PredavacDogadjaj",
                    //    l => l.HasOne<Dogadjaj>().WithMany().HasForeignKey("DogadjaId").OnDelete(DeleteBehavior.ClientSetNull).HasConstraintName("FK_PredavacDogadjaj_Dogadjaj"),
                    //    r => r.HasOne<Predavac>().WithMany().HasForeignKey("PredavacId").OnDelete(DeleteBehavior.ClientSetNull).HasConstraintName("FK_PredavacDogadjaj_Predavac"),
                    //    j =>
                    //    {
                    //        j.HasKey("PredavacId", "DogadjaId");

                    //        j.ToTable("PredavacDogadjaj");
                    //    });
            });

            modelBuilder.Entity<PredavacDogadjaj>(entity =>
            {
                entity.HasKey(e => new { e.PredavacId, e.DogadjaId });
            });

            modelBuilder.Entity<Projekat>(entity =>
            {
                entity.HasKey(e => e.ProjekatId);

                entity.ToTable("Projekat");

                entity.Property(e => e.ProjekatId).HasColumnName("ProjekatID");

                entity.Property(e => e.KategorijaId).HasColumnName("KategorijaID");

                entity.Property(e => e.Naziv).HasMaxLength(255);

                entity.Property(e => e.Opis).HasMaxLength(255);

                entity.Property(e => e.TimId).HasColumnName("TimID");

                entity.HasOne(d => d.Kategorija)
                    .WithMany(p => p.Projekats)
                    .HasForeignKey(d => d.KategorijaId)
                    .HasConstraintName("FK_Projekat_Kategorija");

                entity.HasOne(d => d.Tim)
                    .WithMany(p => p.Projekats)
                    .HasForeignKey(d => d.TimId)
                    .HasConstraintName("FK_Projekat_Tim");
            });

            modelBuilder.Entity<Rezultat>(entity =>
            {
                entity.HasKey(e => e.RezultatId);

                entity.ToTable("Rezultat");

                entity.Property(e => e.RezultatId).HasColumnName("RezultatID");

                entity.Property(e => e.Napomena).HasMaxLength(255);

                entity.Property(e => e.ProjekatId).HasColumnName("ProjekatID");

                entity.HasOne(d => d.Projekat)
                    .WithMany(p => p.Rezultats)
                    .HasForeignKey(d => d.ProjekatId)
                    .HasConstraintName("FK_Rezultat_Projekat");
            });

            modelBuilder.Entity<Sponzor>(entity =>
            {
                entity.ToTable("Sponzor");

                entity.Property(e => e.SponzorId).HasColumnName("SponzorID");

                entity.Property(e => e.KategorijaId).HasColumnName("KategorijaID");

                entity.HasOne(d => d.Kategorija)
                    .WithMany(p => p.Sponzors)
                    .HasForeignKey(d => d.KategorijaId)
                    .HasConstraintName("FK_Sponzor_Kategorija");
            });

            modelBuilder.Entity<Takmicenje>(entity =>
            {
                entity.HasKey(e => e.TakmicenjeId);

                entity.ToTable("Takmicenje");

                entity.Property(e => e.TakmicenjeId).HasColumnName("TakmicenjeID");

                entity.Property(e => e.Kraj).HasColumnType("datetime");

                entity.Property(e => e.Naziv).HasMaxLength(255);

                entity.Property(e => e.Pocetak).HasColumnType("datetime");
            });

            modelBuilder.Entity<Tim>(entity =>
            {
                entity.HasKey(e => e.TimId);

                entity.ToTable("Tim");

                entity.Property(e => e.TimId).HasColumnName("TimID");

                entity.Property(e => e.Naziv).HasMaxLength(255);

                entity.Property(e => e.TakmicenjeId).HasColumnName("TakmicenjeID");

                entity.HasOne(d => d.Takmicenje)
                    .WithMany(p => p.Tims)
                    .HasForeignKey(d => d.TakmicenjeId)
                    .HasConstraintName("FK_Tim_Takmicenje");
            });

            modelBuilder.Entity<User>(entity =>
            {
                entity.ToTable("User");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
