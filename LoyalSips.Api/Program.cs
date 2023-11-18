using LoyalSips.Api.LoyalSips.Domain.Repositories;
using LoyalSips.Api.LoyalSips.Domain.Services;
using LoyalSips.Api.LoyalSips.Mapping;
using LoyalSips.Api.LoyalSips.Persistence.Repositories;
using LoyalSips.Api.LoyalSips.Services;
using LoyalSips.Api.Security.Authorization.Handlers.Implementations;
using LoyalSips.Api.Security.Authorization.Handlers.Interfaces;
using LoyalSips.Api.Security.Domain.Repositories;
using LoyalSips.Api.Security.Persistence.Repositories;
using LoyalSips.Api.Shared.Persistence.Contexts;
using LoyalSips.API.Shared.Persistence.Repositories;
using Microsoft.EntityFrameworkCore;
using Microsoft.OpenApi.Models;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(c =>
{
    c.SwaggerDoc("v1", new OpenApiInfo { Title = "Your API", Version = "v1" });
});

// Add Database Connection
var connectionString = builder.Configuration.GetConnectionString("DefaultConnection");
builder.Services.AddDbContext<AppDbContext>(
    options => options.UseMySQL(connectionString)
        .LogTo(Console.WriteLine, LogLevel.Information)
        .EnableSensitiveDataLogging()
        .EnableDetailedErrors());


// Security Injection Configuration
builder.Services.AddScoped<IJwtHandler, JwtHandler>();
builder.Services.AddScoped<IUserRepositoryy, UserRepositoryy>();
// Add lowercase routes
builder.Services.AddRouting(options => options.LowercaseUrls = true);

// Dependency Injection Configuration
//user
//bar - pub
builder.Services.AddScoped<IBarRepository, BarRepository>();
builder.Services.AddScoped<IBarService, BarService>();

//registro 
builder.Services.AddScoped<IRegistroPointRepository, RegistroRepository>();
builder.Services.AddScoped<IRegistroService, RegistroService>();

//unit of work
builder.Services.AddScoped<IUnitOfWork, UnitOfWork>();

//support
builder.Services.AddScoped<ISupportRepository, SupportRepository>();
builder.Services.AddScoped<ISupportService, SupportService>();

// inventory
builder.Services.AddScoped<IInventoryRepository, InventoryRepository>();
builder.Services.AddScoped<IInventoryService, InventoryService>();


// AutoMapper Configuration
builder.Services.AddAutoMapper(
    typeof(ModelToResourceProfile),
    typeof(ResourceToModelProfile));

// Add CORS configuration
builder.Services.AddCors(options =>
{
    options.AddDefaultPolicy(builder =>
    {
        builder.AllowAnyOrigin()
            .AllowAnyHeader()
            .AllowAnyMethod();
    });
});

var app = builder.Build();

// Validation for ensuring Database Objects are created
using (var scope = app.Services.CreateScope())
using (var context = scope.ServiceProvider.GetService<AppDbContext>())
{
    context.Database.EnsureCreated();
}

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();
app.UseAuthorization();

// Use CORS middleware
app.UseCors();

app.MapControllers();
app.Run();
