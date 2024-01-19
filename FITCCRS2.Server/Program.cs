using FITCCRS2.Server;
using FITCCRS2.Server.Data;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

//provjeravamo da li argumenti sadrze /seed
//ako postoji neki seed argument  u pokretanju aplikacije treba da se ukloni 
//prvo treba da e seed aplikacija prije pokretanja

var seed = args.Contains("/seed");
if (seed)
{
    args=args.Except(new[] { "/seed"}).ToArray();
}
var builder = WebApplication.CreateBuilder(args);
var assembly = typeof(Program).Assembly.GetName().Name;
var defaultConnString = builder.Configuration.GetConnectionString("DefaultConnection");

if (seed)
{
    SeedData.EnsureSeedData(defaultConnString);
}

builder.Services.AddDbContext<AspNetIdentityDbContext>(options =>
    options.UseSqlServer(defaultConnString,
        b=>b.MigrationsAssembly(assembly)));

builder.Services.AddIdentity<IdentityUser,  IdentityRole>()
    .AddEntityFrameworkStores<AspNetIdentityDbContext>();

builder.Services.AddIdentityServer()
    .AddAspNetIdentity<IdentityUser>()
    .AddConfigurationStore(options =>
{
    options.ConfigureDbContext=b =>
    b.UseSqlServer(defaultConnString, opt => opt.MigrationsAssembly(assembly));
}).AddOperationalStore(options => {
    options.ConfigureDbContext=b =>
    b.UseSqlServer(defaultConnString, opt => opt.MigrationsAssembly(assembly));
}).AddDeveloperSigningCredential();

builder.Services.AddAuthorization();
builder.Services.AddControllers();
builder.Services.AddMvc();
builder.Services.AddRazorPages(); 


var app = builder.Build();
//sv ovo se radi kad se builder pozove
app.UseStaticFiles();
app.UseRouting();   
app.UseIdentityServer();

if (app.Environment.IsDevelopment())
{
    app.UseDeveloperExceptionPage();
}

//DODATI
//da bi dodali linije koda ispod i da bi pokrenuli treba da se doda service i bearer token gore u builder service.... 
// i treba da se pokrene pMC sa kontrolom: 
//dotnet run FITCCRS2.Server/bin/Debug/net6.0/FITCCRS2.Server /seed --project FITCCRS2.Server

app.UseAuthorization();

app.UseEndpoints(endpoints =>
{
    endpoints.MapDefaultControllerRoute();
});

app.Run();
