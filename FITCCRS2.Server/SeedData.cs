
using FITCCRS2.Server.Data;
using IdentityModel;
using IdentityServer4.EntityFramework.DbContexts;
using IdentityServer4.EntityFramework.Mappers;
using IdentityServer4.EntityFramework.Storage;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using System.Security.Claims;

namespace FITCCRS2.Server
{
    public class SeedData
    {
        //data koja je potrebna za identity server kako bi validacija uredno radila 
        public static void EnsureSeedData(string connectionString)
        {
            var services = new ServiceCollection();
            services.AddLogging();
            services.AddDbContext<AspNetIdentityDbContext>(options =>
              options.UseSqlServer(connectionString));

            services.AddIdentity<IdentityUser, IdentityRole>()
              .AddEntityFrameworkStores<AspNetIdentityDbContext>()
              .AddDefaultTokenProviders();

            services.AddOperationalDbContext(options =>
            {
                options.ConfigureDbContext = db =>
                  db.UseSqlServer(connectionString,
                  sql => sql.MigrationsAssembly(typeof(SeedData).Assembly.FullName));
            });
            services.AddConfigurationDbContext(options =>
            {
                options.ConfigureDbContext = db =>
                  db.UseSqlServer(connectionString,
                  sql => sql.MigrationsAssembly(typeof(SeedData).Assembly.FullName));
            });

            var serviceProvider = services.BuildServiceProvider();

            using (var scope = serviceProvider.GetRequiredService<IServiceScopeFactory>().CreateScope())
            {
                scope.ServiceProvider.GetService<PersistedGrantDbContext>().Database.Migrate();

                var context = scope.ServiceProvider.GetService<ConfigurationDbContext>();
                context.Database.Migrate();

                EnsureSeedData(context);

                var ctx = scope.ServiceProvider.GetService<AspNetIdentityDbContext>();
                ctx.Database.Migrate();
                EnsureUsers(scope);
            }
        }
        private static void EnsureUsers(IServiceScope scope)
        {

            var roleMgr = scope.ServiceProvider.GetRequiredService<RoleManager<IdentityRole>>();
            var takmicar = roleMgr.FindByNameAsync("takmicar").Result;
            if (takmicar == null)
            {
                takmicar = new IdentityRole
                {
                    Name="takmicar"
                };

                var result = roleMgr.CreateAsync(takmicar).Result;
                if (!result.Succeeded)
                {
                    throw new Exception(result.Errors.First().Description);
                }


            }
            var ziri = roleMgr.FindByNameAsync("ziri").Result;
            if (ziri == null)
            {
                ziri = new IdentityRole
                {
                    Name="ziri"
                };

                var result = roleMgr.CreateAsync(ziri).Result;
                if (!result.Succeeded)
                {
                    throw new Exception(result.Errors.First().Description);
                }


            }
            var admin = roleMgr.FindByNameAsync("admin").Result;
            if (admin == null)
            {
                admin = new IdentityRole
                {
                    Name="admin"
                };

                var result = roleMgr.CreateAsync(admin).Result;
                if (!result.Succeeded)
                {
                    throw new Exception(result.Errors.First().Description);
                }


            }
            var predavac = roleMgr.FindByNameAsync("predavac").Result;
            if (predavac == null)
            {
                predavac = new IdentityRole
                {
                    Name="predavac"
                };

                var result = roleMgr.CreateAsync(predavac).Result;
                if (!result.Succeeded)
                {
                    throw new Exception(result.Errors.First().Description);
                }


            }
            var sponzor = roleMgr.FindByNameAsync("sponzor").Result;
            if (sponzor == null)
            {
                sponzor = new IdentityRole
                {
                    Name="sponzor"
                };

                var result = roleMgr.CreateAsync(sponzor).Result;
                if (!result.Succeeded)
                {
                    throw new Exception(result.Errors.First().Description);
                }


            }


            var userMgr = scope.ServiceProvider.GetRequiredService<UserManager<IdentityUser>>();
            var meli = userMgr.FindByNameAsync("meli").Result;
            if (meli == null)
            {
                meli = new IdentityUser
                {
                    UserName = "meli",
                    Email = "mellimostar@gmail.com",
                    EmailConfirmed = true,
                };

                var result = userMgr.CreateAsync(meli, "Test123!").Result;
                if (!result.Succeeded)
                {
                    throw new Exception(result.Errors.First().Description);
                }

                if (!userMgr.IsInRoleAsync(meli, admin.Name).Result)
                {
                    _=userMgr.AddToRoleAsync(meli, admin.Name).Result;
                }

                result =
                    userMgr.AddClaimsAsync(meli,
                    new Claim[]
                    {
                      new Claim(JwtClaimTypes.Name, "Melissa Memic"),
                      new Claim(JwtClaimTypes.GivenName, "Melissa"),
                      new Claim(JwtClaimTypes.FamilyName, "Memic"),
                      new Claim(JwtClaimTypes.WebSite, "http://google.com"),
                    }).Result;
                if (!result.Succeeded)
                {
                    throw new Exception(result.Errors.First().Description);
                }
            }


            var lamija = userMgr.FindByNameAsync("lamija").Result;
            if (lamija == null)
            {
                lamija = new IdentityUser
                {
                    UserName = "lamija",
                    Email = "lamija.babovic@edu.fit.ba",
                    EmailConfirmed = true
                };
                var result = userMgr.CreateAsync(lamija, "Test123!").Result;
                if (!result.Succeeded)
                {
                    throw new Exception(result.Errors.First().Description);
                }
                if (!userMgr.IsInRoleAsync(lamija, admin.Name).Result)
                {
                    _=userMgr.AddToRoleAsync(lamija, admin.Name).Result;
                }
                result =
                    userMgr.AddClaimsAsync(lamija,
                    new Claim[]
                    {
                          new Claim(JwtClaimTypes.Name, "Lamija Babovic"),
                          new Claim(JwtClaimTypes.GivenName, "Lamija"),
                          new Claim(JwtClaimTypes.FamilyName, "Babovic"),
                          new Claim(JwtClaimTypes.WebSite, "http://google.com"),
                    }).Result;
                if (!result.Succeeded)
                {
                    throw new Exception(result.Errors.First().Description);
                }
            }
        }
       
        //dodaje sve ono sto smo dodali u conifg klasi 
        private static void EnsureSeedData(ConfigurationDbContext context)
        {
            if (!context.Clients.Any())
            {
                foreach (var client in Config.Clients.ToList())
                {
                    context.Clients.Add(client.ToEntity());
                }

                context.SaveChanges();
            }

            if (!context.IdentityResources.Any())
            {
                foreach (var resource in Config.IdentityResources.ToList())
                {
                    context.IdentityResources.Add(resource.ToEntity());
                }

                context.SaveChanges();
            }

            if (!context.ApiScopes.Any())
            {
                foreach (var resource in Config.ApiScopes.ToList())
                {
                    context.ApiScopes.Add(resource.ToEntity());
                }

                context.SaveChanges();
            }

            if (!context.ApiResources.Any())
            {
                foreach (var resource in Config.ApiResources.ToList())
                {
                    context.ApiResources.Add(resource.ToEntity());
                }

                context.SaveChanges();
            }

        }
    }
}
