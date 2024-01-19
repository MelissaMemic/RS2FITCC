using FITCCRS2.Auth;
using FITCCRS2.Helper.ActiveUser;
using FITCCRS2.Helper.Middleware;
using FITCCRS2.Model;
using FITCCRS2.Services.AgendaService;
using FITCCRS2.Services.Auth;
using FITCCRS2.Services.Database;
using FITCCRS2.Services.DogadjajService;
using FITCCRS2.Services.KategorijaService;
using FITCCRS2.Services.KriterijService;
using FITCCRS2.Services.NapomenaService;
using FITCCRS2.Services.PredavacService;
using FITCCRS2.Services.ProjekatService;
using FITCCRS2.Services.RabbitMQ;
using FITCCRS2.Services.RezultatiService;
using FITCCRS2.Services.RolesService;
using FITCCRS2.Services.SponzorService;
using FITCCRS2.Services.TakmicenjeService;
using FITCCRS2.Services.Tim;
using FITCCRS2.Services.UserMService;
using FITCCRS2.Services.UserService;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using Microsoft.OpenApi.Models;
using System.Data.Entity;
using System.Text;

var builder = WebApplication.CreateBuilder(args);


// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();

// Add services to the container.
var connectionString = builder.Configuration.GetConnectionString("DefaultConnection");
Console.WriteLine("Connection string: ", connectionString);

builder.Services.AddDbContext<RS2SeminarskiContext>(options =>
    options.UseSqlServer(connectionString));

var connectionString1 = builder.Configuration.GetConnectionString("IdentityConnection");
Console.WriteLine("Identity string: ", connectionString1);

builder.Services.AddDbContext<AppIdentityDbContext>(options =>
    options.UseSqlServer(connectionString1));


builder.Services.AddIdentity<IdentityUser, IdentityRole>().AddEntityFrameworkStores<AppIdentityDbContext>().AddDefaultTokenProviders();

//builder.Services.AddSwaggerGen();

builder.Services.AddTransient<IKategorijaService, KategorijaService>();
builder.Services.AddTransient<ITakmicenjeService, TakmicenjeService>();
builder.Services.AddTransient<IRezultatiService, RezultatiService>();
builder.Services.AddTransient<ISponzorService, SponzorService>();
builder.Services.AddTransient<IKriterijService, KriterijService>();
builder.Services.AddTransient<IPredavacService, PredavacService>();
builder.Services.AddTransient<IProjekatService, ProjekatService>();
builder.Services.AddTransient<ITimService, TimService>();
builder.Services.AddTransient<IDogadjajService, DogadjajService>();
builder.Services.AddTransient<ITokenClaimService, IdentityTokenClaimService>();
builder.Services.AddTransient<IUserService, UserService>();
builder.Services.AddTransient<IRolesService, RolesService>();
builder.Services.AddTransient<INapomenaService, NapomenaService>();
builder.Services.AddTransient<IAgendaService, AgendaService>();
builder.Services.AddTransient<IUserMService, UserMService>();
builder.Services.AddSingleton<IActiveUser, ActiveUser>();
builder.Services.AddTransient<IEmailService, EmailService>();


//builder.Services.AddAuthentication("Bearer").AddIdentityServerAuthentication("Bearer", options =>
//{
//    options.RequireHttpsMetadata = false;
//    options.Authority = "https://localhost:5443";
//    options.ApiName = "FITCCRS2";

//});
var key = Encoding.ASCII.GetBytes("SecretKeyOfDoomThatMustBeAMinimumNumberOfBytes");
builder.Services.AddAuthentication(o => o.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme)
    .AddJwtBearer(options =>
    {
        options.Authority = "https://localhost:5443";
        options.RequireHttpsMetadata = false; 
        options.SaveToken = true;

        options.TokenValidationParameters = new TokenValidationParameters
        {
            ValidateAudience = false,
            ValidAudience = "FITCCRS2",
            ValidateIssuer = false,
            ValidIssuer = "http://identityserver",
            ValidateIssuerSigningKey = true,
            IssuerSigningKey = new SymmetricSecurityKey(key),
        };
    });

//builder.Services.AddAuthentication(o => o.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme).AddJwtBearer(options =>
//{
//    //options.Authority = "http://identity-server-fitcc:5000/";
//    //options.Authority = "http://identityserver";
//    options.Authority = "https://localhost:5443/";
//    options.RequireHttpsMetadata = false;
//    options.SaveToken = true;

//    options.TokenValidationParameters.ValidIssuers = builder.Configuration["Issuer"].Split(',');
//    //options.TokenValidationParameters.ValidIssuers = new List<String>() { "http://localhost:5000/" };
//    options.TokenValidationParameters.ValidAudiences = new[] { "FITCCRS2" };
//    options.TokenValidationParameters.ValidTypes = new[] { "at+jwt" };
//    options.TokenValidationParameters = new TokenValidationParameters()
//    {
//        ValidateAudience = false,
//        ValidAudience = "FITCCRS2",
//        ValidateIssuer = false,
//        //ValidIssuer = "http://identity-server-fitcc:5000/",
//        //ValidIssuer = "http://identityserver",
//        ValidIssuer = "http://localhost:5443/",

//        ValidateIssuerSigningKey = true,
//        IssuerSigningKey = new SymmetricSecurityKey(key),
//    };
//});

//builder.Services.AddAuthorization(options =>
//{
//    options.AddPolicy(PolicyUtil.AuthorizeUserIdPolicy, policy =>
//        policy.Requirements.Add(new AuthorizationUserRequirement()));
//});
//builder.Services.AddAuthorization(options =>
//{
//    options.AddPolicy("Bearer", new AuthorizationPolicyBuilder()
//                    .AddAuthenticationSchemes(JwtBearerDefaults.AuthenticationScheme‌​)
//                    .RequireAuthenticatedUser().Build());
//});
builder.Services.AddControllers();


builder.Services.AddAutoMapper(typeof(IKategorijaService));

builder.Services.AddSwaggerGen(c =>
            {
    //c.SwaggerDoc("v1", new OpenApiInfo { Title = "My API", Version = "v1" });
    c.EnableAnnotations();
    c.SchemaFilter<CustomSchemaFilters>();
    c.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme
    {
        In = ParameterLocation.Header,
        Description = "Please insert JWT with Bearer into field",
        Name = "Authorization",
        Type = SecuritySchemeType.ApiKey
    });
    c.AddSecurityRequirement(new OpenApiSecurityRequirement 
    {
       {
           new OpenApiSecurityScheme
               {
                   Reference = new OpenApiReference
                   {
                       Type = ReferenceType.SecurityScheme,
                       Id = "Bearer"
                   },
                   Scheme = "oauth2",
                   Name = "Bearer",
                   In = ParameterLocation.Header,

               },
               new List<string>()
       }
     });
});



var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    //app.UseSwaggerUI();
    app.UseSwaggerUI(c => {
        c.RoutePrefix = string.Empty;
        c.SwaggerEndpoint("/swagger/v1/swagger.json", "Name of Your API v1");
    });
}

//app.UseHttpsRedirection();

app.UseRouting();
app.UseAuthentication();
app.UseAuthorization();

app.UseMiddleware<ActiveUserM>();

app.MapControllers();

using (var scope = app.Services.CreateScope())
{
    var dataContext = scope.ServiceProvider.GetRequiredService<RS2SeminarskiContext>();
    dataContext.Database.Migrate();
}

app.Run();
