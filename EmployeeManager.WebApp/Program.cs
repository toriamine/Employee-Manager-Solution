using EmployeeManager.Core.Data;
using EmployeeManager.Core.Services;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Подключаем Razor Pages
builder.Services.AddRazorPages();

// Подключаем PostgreSQL
builder.Services.AddDbContext<ApplicationDbContext>(options =>
    options.UseNpgsql("Host=localhost;Port=5432;Database=employee_db;Username=postgres;Password=2001lk"));

// Подключаем EmployeeService
builder.Services.AddScoped<EmployeeService>();

// Контроллеры (API)
builder.Services.AddControllers();

var app = builder.Build();

app.UseRouting();
app.UseAuthorization();

app.MapControllers();     // API
app.MapRazorPages();      // Razor UI

app.Run();