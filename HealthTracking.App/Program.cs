using HealthTracking.BLL;
using HealthTracking.Common.Setting;
using HealthTracking.DAL;
using HealthTracking.DAL.Model;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Http.Features;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Text;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddDbContext<HealthTrackingContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));

builder.Services.AddIdentity<AppUser, IdentityRole>()
    .AddEntityFrameworkStores<HealthTrackingContext>()
    .AddDefaultTokenProviders();

builder.Services.AddAuthorization();

builder.Services.AddAuthentication(options =>
{
    options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
    options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
})
.AddJwtBearer(options =>
{
    options.TokenValidationParameters = new TokenValidationParameters
    {
        ValidateIssuer = true,
        ValidateAudience = true,
        ValidateLifetime = true,
        ValidateIssuerSigningKey = true,

        ValidIssuer = "your-api",
        ValidAudience = "your-client",
        IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes("safhhyrgfarfygarfkasneb2154eajghhegfgaey88755"))
    };
});

builder.Services.Configure<CloudinarySettings>(
    builder.Configuration.GetSection("CloudinarySettings"));
builder.Services.Configure<FormOptions>(o =>
{
    o.MultipartBodyLengthLimit = 209715200; // 200MB
});

builder.Services.AddScoped<AuthBLL>();
builder.Services.AddScoped<BodyMetricRep>();
builder.Services.AddScoped<BodyMetricService>();
builder.Services.AddScoped<ExerciseRep>();
builder.Services.AddScoped<ExerciseService>();
builder.Services.AddScoped<WaterService>();
builder.Services.AddScoped<WaterRep>();
builder.Services.AddScoped<UserSettingRep>();
builder.Services.AddScoped<UserSettingService>();
builder.Services.AddScoped<AppUserRep>();
builder.Services.AddScoped<UserService>();
builder.Services.AddScoped<SleepRep>();
builder.Services.AddScoped<SleepService>();
builder.Services.AddScoped<IPhotoService, PhotoService>();


var app = builder.Build();

using (var scope = app.Services.CreateScope())
{
    var roleManager = scope.ServiceProvider.GetRequiredService<RoleManager<IdentityRole>>();

    string[] roles = new[] { "Admin", "User", "Expert" };

    foreach (var role in roles)
    {
        if (!await roleManager.RoleExistsAsync(role))
        {
            await roleManager.CreateAsync(new IdentityRole(role));
        }
    }
}

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthentication();
app.UseAuthorization();

app.UseAuthorization();

app.MapControllers();

app.Run();
