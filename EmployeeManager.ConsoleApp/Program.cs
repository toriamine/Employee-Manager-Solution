using EmployeeManager.Core.Models;
using EmployeeManager.Core.Services;
using EmployeeManager.Core.Data;
using Microsoft.EntityFrameworkCore;

namespace EmployeeManager.ConsoleApp
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var optionsBuilder = new DbContextOptionsBuilder<ApplicationDbContext>();
            optionsBuilder.UseNpgsql("Host=localhost;Port=5432;Database=employee_db;Username=postgres;Password=2001lk");
            var dbContext = new ApplicationDbContext(optionsBuilder.Options);
            var service = new EmployeeService(dbContext);

            while (true)
            {
                Console.WriteLine("\n1. Добавить сотрудника");
                Console.WriteLine("2. Показать всех сотрудников");
                Console.WriteLine("3. Найти по отделу");
                Console.WriteLine("4. Удалить сотрудника");
                Console.WriteLine("5. Выход");
                Console.Write("Выберите действие: ");
                var choice = Console.ReadLine();

                switch (choice)
                {
                    case "1":
                        Console.Write("Введите имя: ");
                        var name = Console.ReadLine();
                        Console.Write("Введите возраст: ");
                        var age = int.Parse(Console.ReadLine());
                        Console.Write("Введите отдел: ");
                        var department = Console.ReadLine();

                        service.AddEmployee(new Employee { Name = name, Age = age, Department = department });
                        Console.WriteLine("Сотрудник добавлен.");
                        break;

                    case "2":
                        var all = service.GetAllEmployees();
                        foreach (var e in all)
                            Console.WriteLine($"{e.Id}: {e.Name}, {e.Age} лет, отдел {e.Department}");
                        break;

                    case "3":
                        Console.Write("Введите название отдела: ");
                        var dep = Console.ReadLine();
                        var found = service.FindByDepartment(dep);
                        foreach (var e in found)
                            Console.WriteLine($"{e.Id}: {e.Name}, {e.Age} лет");
                        break;

                    case "4":
                        Console.Write("Введите ID сотрудника: ");
                        var id = int.Parse(Console.ReadLine());
                        if (service.RemoveEmployee(id))
                            Console.WriteLine("Сотрудник удален.");
                        else
                            Console.WriteLine("Сотрудник не найден.");
                        break;

                    case "5":
                        return;

                    default:
                        Console.WriteLine("Неверный ввод. Попробуйте ещё раз.");
                        break;
                }
            }
        }
    }
}