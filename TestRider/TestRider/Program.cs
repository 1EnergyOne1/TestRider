using TestRider.Data;
using TestRider.Controllers;
using Microsoft.EntityFrameworkCore;
using Microsoft.OpenApi.Models;
using TestRider.Data;

var builder = WebApplication.CreateBuilder(args);

// Подключение к PostgreSQL
builder.Services.AddDbContext<UserContext>(options =>
    options.UseNpgsql(builder.Configuration.GetConnectionString("PostgresConnection")));

// Настраиваем поддержку OpenAPI/Swagger
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(c =>
{
    c.SwaggerDoc("v1", new OpenApiInfo { Title = "Users API", Version = "v1" });
});

var app = builder.Build();

// Вывод интерфейса Swagger в режиме Development
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

// Маршрутизация для обработки GET-запросов
app.MapGet("/api/users", async (UserContext db) =>
    {
        var users = await db.Users.ToListAsync();
        return Results.Ok(users); // Возвращаем список всех пользователей
    })
    .WithName("GetAllUsers")
    .WithOpenApi(); // Создаем документацию через Swagger

app.Run();