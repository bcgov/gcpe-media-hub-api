using Microsoft.EntityFrameworkCore;
using Gcpe.MediaHub.API.Data;
using Microsoft.OpenApi.Models;
using System.Text.Json.Serialization;
using Gcpe.MediaHub.API.Services;
using Microsoft.AspNetCore.Authentication;
var builder = WebApplication.CreateBuilder(args);
builder.Services.AddDbContext<GcpeMediaHubAPIContext>(options =>
    options.UseSqlite(builder.Configuration.GetConnectionString("GcpeMediaHubAPIContext") ?? throw new InvalidOperationException("Connection string 'GcpeMediaHubAPIContext' not found.")));

builder.Services.AddControllers()
    .AddJsonOptions(options =>
    {
        options.JsonSerializerOptions.ReferenceHandler = ReferenceHandler.IgnoreCycles;
        options.JsonSerializerOptions.DefaultIgnoreCondition = JsonIgnoreCondition.WhenWritingNull;
        options.JsonSerializerOptions.WriteIndented = true;
    });

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddSwaggerGen(c =>
{
    c.SwaggerDoc("v1", new OpenApiInfo
    {
        Title = "GCPE Media Hub 2.0 API",
        Version = "v1",
        Description = "GCPE Media Hub 2.0"
    });
});

builder.Services.AddAuthentication("BasicAuthentication")
    .AddScheme<AuthenticationSchemeOptions, BasicAuthenticationHandler>("BasicAuthentication", null);

builder.Services.AddAuthorization();

// Add CORS for development and production
builder.Services.AddCors(options =>
{
    options.AddDefaultPolicy(
        policy =>
        {
            if (builder.Environment.IsDevelopment())
            {
                policy.WithOrigins("http://localhost:5173", "http://localhost:5229", "http://localhost:7145")
                      .AllowAnyHeader()
                      .AllowAnyMethod()
                      .AllowCredentials();
            }
            else
            {
                policy.WithOrigins("http://dev.digitalhub.gcpe.gov.bc.ca", "https://dev.digitalhub.gcpe.gov.bc.ca")
                      .AllowAnyHeader()
                      .AllowAnyMethod()
                      .AllowCredentials();
            }
        });
    
    // Add a more permissive policy for production debugging
    options.AddPolicy("ProductionCors", policy =>
    {
        policy.WithOrigins("http://dev.digitalhub.gcpe.gov.bc.ca", "https://dev.digitalhub.gcpe.gov.bc.ca", "http://142.34.142.70")
              .AllowAnyHeader()
              .AllowAnyMethod()
              .AllowCredentials();
    });
});

var app = builder.Build();

using (var scope = app.Services.CreateScope())
{
    var services = scope.ServiceProvider;
    var context = services.GetRequiredService<GcpeMediaHubAPIContext>();
    await context.Database.MigrateAsync();
    try
    {
        var enableSeeding = builder.Configuration.GetValue<bool>("DatabaseSeeding:EnableSeeding", false);

        // Only seed if database is empty and seeding is enabled
        if (enableSeeding)
        {
            DbInitializer.SeedAll(context);
        }
    }
    catch (Exception ex)
    {
        var logger = services.GetRequiredService<ILogger<Program>>();
        logger.LogError(ex, "An error occurred while seeding the database.");
        // Continue without seeding if there are issues
    }
}

if (app.Environment.IsDevelopment())
{
    // Additional development-only features can go here
}

app.UseSwagger();
app.UseSwaggerUI();

app.UseHttpsRedirection();
app.UseFileServer();
app.UseRouting();

app.UseHttpsRedirection();

// Serve static files from wwwroot (frontend build)
app.UseStaticFiles();

// Add default files support (index.html)
app.UseDefaultFiles();

// Use appropriate CORS policy
if (app.Environment.IsDevelopment())
{
    app.UseCors();
}
else
{
    app.UseCors("ProductionCors");
}
app.UseAuthentication();
app.UseAuthorization();

app.MapControllers();
// Fallback to index.html for SPA routing
app.MapFallbackToFile("index.html");

app.Run();
