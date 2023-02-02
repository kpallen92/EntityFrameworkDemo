using EntityFrameworkDemo.Data;
using EntityFrameworkDemo.Domain.Services;
using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// CONFIGURE SERVICES
// Base services
builder.Services.AddControllers();
builder.Services.AddRouting(options => { options.LowercaseUrls = true; });
builder.Services.AddHealthChecks();

// Swagger
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

// Domain layer dependencies
builder.Services.AddTransient<CompanyService>();
builder.Services.AddTransient<EmployeeService>();

// Entity Framework
const string sqlTemplate =
    "Server=tcp:{0},{1};Database={2};User ID={3};Password={4};Encrypt={5};Persist Security Info=False;MultipleActiveResultSets=False;TrustServerCertificate=False;Connection Timeout=30;";

var connectionString = string.Format(sqlTemplate, builder.Configuration["DbHost"],
    builder.Configuration["DbPort"], builder.Configuration["DbCatalog"],
    builder.Configuration["DbUser"], builder.Configuration["DbPassword"],
    builder.Configuration["EncryptDbTraffic"]);

builder.Services.AddDbContext<DemoContext>(options => options.UseSqlServer(connectionString));

// BUILD
var app = builder.Build();

// CONFIGURE
// Entity Framework auto-migrations
using var scope = app.Services.CreateScope();
var services = scope.ServiceProvider;
var context = services.GetRequiredService<DemoContext>();
context.Database.Migrate();

// Swagger
app.UseSwagger();
app.UseSwaggerUI();

app.MapHealthChecks("/status");
app.UseHttpsRedirection();
app.UseExceptionHandler("/error");
app.UseRouting();
app.UseAuthorization();
app.MapControllers();

// RUN APPLICATION
app.Run();