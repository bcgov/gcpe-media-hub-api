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

var app = builder.Build();

using (var scope = app.Services.CreateScope())
{
    var services = scope.ServiceProvider;
    var context = services.GetRequiredService<GcpeMediaHubAPIContext>();
    await context.Database.MigrateAsync();
    DbInitializer.SeedAll(context);
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

app.MapControllers();

app.Run();
