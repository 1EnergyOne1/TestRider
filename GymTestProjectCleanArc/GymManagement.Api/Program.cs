using GymManagement.Application;
using GymManagement.Infrastructure;
using Microsoft.OpenApi.Models;

var builder = WebApplication.CreateBuilder(args);

// Добавляем сервисы в контейнер
builder.Services.AddControllers();                   // Поддержка контроллеров
builder.Services.AddEndpointsApiExplorer();
builder.Services
    .AddApplication()
    .AddInfrastructure();
// Конечные точки API Explorer
builder.Services.AddSwaggerGen(c =>
{
    c.SwaggerDoc("v1", new OpenApiInfo { Title = "My API", Version = "v1" });
});                                                 // Генерация документации API (Swagger)

var app = builder.Build();

// Настройка HTTP-конвейера запросов
if (app.Environment.IsDevelopment())                // Только для режима разработки
{
    app.UseSwagger();                                // Подключение Swagger UI
    app.UseSwaggerUI(c =>                            // Настройка Swagger UI
    {
        c.SwaggerEndpoint("/swagger/v1/swagger.json", "My API V1");
    });
}

//app.UseHttpsRedirection();                          // Переадресация на HTTPS
app.MapControllers();                               // Маршрутизация контроллеров

app.Run();                                          // Запуск приложения